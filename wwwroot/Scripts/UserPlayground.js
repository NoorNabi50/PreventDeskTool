var speechObj;
var gameProgresscounter = 0;
var currentVideo;

$(document).ready(function () {
    speechObj = new SpeechSynthesisUtterance();
    speechObj.rate = 0.7;
    speechObj.pitch = 1;
    speechObj.voice = window.speechSynthesis.getVoices()[2];
    $('#loggedInUser').text($('#userloggedIn').text());
    speechObj.text = $('#readText').text().replace(/\n|\r/g, "").trim();
    window.speechSynthesis.speak(speechObj);
  
})

$('#partialComponentbody').delegate('#Next1', 'click', NextStep1Method);

function NextStep1Method() {
    window.speechSynthesis.cancel();
    $('#playgroundBody').empty();
    LoadVideo();
}
    
function LoadVideo() {

    AjaxRequest('/PlayGround/GetVideo', 'GET', { level: gameProgresscounter }, data => {
      
        if (data) {
           
            $('#playgroundBody').empty().append(`
                      <div id="HeadingSection">
                       <h3  class="text-center"><span class="text-bold text-success mb-10" id="Level">Level ${gameProgresscounter + 1}</span></h3>
                   <h2 class="text-center text-bold text-danger"><span id="Instruction">Watch Video Carefully!!!</span>
                    </h2>
                    </div>
                   <div id="ContentSection">
                   <video id="PlayergroundVideo" class="${data.videoId}" width="100%" height="290">
                            <source id="Videosrc" src="/Videos/${data.videoPath}" type="video/mp4" />
                    </video>
                  </div>
                <center>
                    <div id="ButtonsSection">
                    <button type="button" class="btn btn-primary" id="PlayVideo">Play</button>
                    <button type="button" class="btn btn-info" id="PauseVideo">Pause</button>
                   </div>
                </center>
                    
               `);
            currentVideo = document.getElementById('PlayergroundVideo');
            currentVideo.load();
            PlaySpeech(`It is Level ${gameProgresscounter + 1}......... Please Remember Video will be played Once
                      Use the below two buttons to control the Video ... `);
        }

        else {
            $('#playgroundBody').empty().append(`
                      <div id="HeadingSection">
                           <h2 class="text-center text-bold text-danger"><span id="Instruction">The Game is Over!!!</span>
                    </h2></div>`);
            PlaySpeech(`...............${$('#Instruction').text()}...We will notify you once the your progress report is generated......Thanks`);
        }
    })
}

$('#playgroundBody').delegate('#PlayVideo', 'click', () => {
    currentVideo.play()
    window.speechSynthesis.cancel();

})
$('#playgroundBody').delegate('#PauseVideo', 'click', () => currentVideo.pause())


document.addEventListener('ended', GetVideoMCqs, true);

function GetVideoMCqs() {
    debugger;
    const VideoId = $('#PlayergroundVideo').attr('class');
    AjaxRequest('PlayGround/GetVideoMCqsDetailById', 'GET', { VideoId }, function (data) {
        console.log(data);
        if (data) {
            $('#HeadingSection').empty().append(`<h3 class="text-center"><span class="text-bold text-success mb-10" id="Level">Level ${gameProgresscounter + 1}</span></h3>
<h5 class="text-bold text-danger"><span id="Instruction">${data.video}
                    </h2>`);
            $('#ContentSection').empty();
            data.videoMcQsOptions.forEach((option,index)=>
            {
                $('#ContentSection').append(`<div class="quiz" id="quiz" data-videoid="${ VideoId }"  data-toggle="buttons">
                <label class="element-animation1 text-left btn btn-lg btn-danger btn-block">
                    <input type="radio" class="Selectoption mr-5" value="${option.optionId}">${option.optionText}</label>
                 </div>`);
           })
            PlaySpeech(` It is Level ${gameProgresscounter + 1} ${data.video}`);
            $('#ButtonsSection').empty().append(`<button type="button" class="btn btn-primary" id="SaveMcqs">Save</button>`)
          

        }
    })
 }



$('#playgroundBody').delegate('#SaveMcqs', 'click', function () {
    gameProgresscounter++;
    var progress = {

    }
    AjaxRequest("/PlayGround/SaveProgress", 'POST',);
    LoadVideo();
})




function PlaySpeech(message) {
    speechObj.text = `Dear ${$('#userloggedIn').text()} ..!  ${message}} `;
    window.speechSynthesis.speak(speechObj);
}


$('#playgroundBody').delegate('.Selectoption', 'click', function () {
    debugger;
    let countercheck = 0;
    $('.Selectoption').each((i, elem) => {
        debugger;
        if ($(elem).is(':checked'))
            countercheck++
    })
    if (countercheck > 2) {
        $('.Selectoption').prop('checked', false);
        PopUpAlert("Only two options are required", 'warning', 'Error');

    }

})
