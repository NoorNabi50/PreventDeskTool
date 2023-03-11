$('#partialComponentbody').delegate('#uploadvideo', 'click', function () {
    debugger;
    const validfomrats = ['mp4', 'avi', 'mkv'];
    let uploadedfile = $('#videofile')[0].files[0];

    if (!uploadedfile) {
        PopUpAlert('Please Select File', 'warning', 'Error');
        return;
    }

    uploadedfile = uploadedfile.name.replace(/^.*[\\\/]/, '');
    uploadedfile = uploadedfile.split('.').pop().toLowerCase();

    const isValidFormat = validfomrats.some(x => uploadedfile.includes(x));

    if(!isValidFormat) {
            PopUpAlert("Please Select Valid Video Format", 'warning', 'Invalid Format');
            $('#videoform').reset();
            return;
     }
    let formData = new FormData();
    formData.append('videofile', $('#videofile')[0].files[0]);
    formData.append('DifficultyCategory', $('#difficultylevel').val());
    formData.append('VideoMcQsTitle', $("#McqsText").val());
         $.ajax(
             {
                 url: "/Videos/UploadVideo",
                 data: formData,

                processData: false,
                contentType: false,
                type: "POST",
                success: RenderUploadedVideoUi,
                Error: function (data) { console.log(data); }
            }
        );
    
})




let container,videoElem;
function RenderUploadedVideoUi(data) {
    debugger;
  container = $('#videouploadedContainer');
     if (data) {
        PopUpAlert("Video Uploaded Successfully", 'success', 'SAVED');
        $(container).empty();
         const markup = `<div class="row">
                      <div class="col-sm-2"></div>
                    <div class="col-sm-6">
                        <a href="#" data-title="">
                            <video style="border:1px solid white;" id="showvideo" class="${data.videoId}" controls width="100%" height="290">
                                <source id="videosrc" src="/Videos/${data.videoPath}" type="video/mp4" />
                            </video>
                        </a>
                           <center>
                       </center> <br>
                 </div>
                  <div class="col-sm-10">
                     <div class="card card-primary">
                    <div class="card-header">
                      <h3 class="card-title">Add Hazards</h3>
                  </div>
                     <div /*style="height:300px;overflow-y:scroll"*/ class="McqsQuestions">
                  <table class="table">
                  <thead>
                  <tr>
                 <th class="col-sm-10">Hazard Description</th>
                 <th>Weightage</th>
                 <th>Actions </th>
                 </tr>
                  <tr>
                 <th><input type="text" class="form-control" id="optiontextBox"></th>
                 <th><input type="text" class="form-control" id="percentagetextBox"></th>
                 <th><a href="#" class="btn btn-primary text-white" id="Addbtn"><i class="fas fa-plus"></i></a> </th>
                 </tr>

                 </thead>
         <tbody class="McqsTbody">

           </tbody>
                  </table>
                    </div>
                    
                  </div>
                </div>`;
         $(container).append(markup);
         videoElem = document.getElementById('showvideo');
         videoElem.load();
        $('.totalvideos').text(data.totalVideos);
    }

}


$('#partialComponentbody').delegate('#Addbtn', 'click', function () {
    debugger;
    $('tbody.McqsTbody').append(`<tr>
                 <td><input type="text" value="${$('#optiontextBox').val()}" readonly class="form-control optiontextBox"></td>
                 <td><input type="text" value="${$('#percentagetextBox').val()}" readonly class="form-control percentagetextBox"></td>
                 <td><a href="#" class="btn btn-danger text-white" id="Removebtn"><i class="fas fa-trash"></i></a> </td>
                 </tr>`);

    $('#optiontextBox').val('');
    $('#percentagetextBox').val('');
    window.scrollTo(0, document.body.scrollHeight);


});

$('#partialComponentbody').delegate('#Removebtn', 'click', function () {

    $(this).closest('tr').remove();
    window.scrollTo(0, document.body.scrollHeight);

});


$('#partialComponentbody').delegate('#SaveData', 'click', function () {
    debugger;
    const HasMcqs = $('tbody.McqsTbody tr').length;
    if (HasMcqs == 0) {
        PopUpAlert('Please Fill MCQs', 'warning', 'Error');
        return;
    }
    const data = CreateVideoMcqsObject();
    AjaxRequest('/VideoMcQs/SaveVideoMCqs', 'POST', { data}, (response) => {
        if (response != "Success") {
            ToastAlert('Failed', 'warning', '#e12e1c');
            return;
        }

        RenderPartial('/Videos/Index', $('#partialComponentbody'));

        ToastAlert('Saved', 'success', 'white');

    });
});




$('#partialComponentbody').delegate('.DeleteVideo', 'click', function () {
    debugger;
    const id = $(this).data('id');
    AjaxRequest("/Videos/DeleteVideo", 'GET', { id }, function (response) {
        if (response == 'Success') {
            RenderPartial('/Videos/Index', $('#partialComponentbody'));
            ToastAlert('Deleted', 'success', 'teal');
        }
        else {

            ToastAlert('Failed', 'warning', '#e12e1c');
            console.log(response);
        }
    })
})

function CreateVideoMcqsObject() {
    debugger;
    let objArr = [];
    $('tbody.McqsTbody tr').each(function () {

        objArr.push({
            OptionText : $(this).children().eq(0).find('.optiontextBox').val(),
            OptionPercentage: $(this).children().eq(1).find('.percentagetextBox').val(),
            VideoId: $('#showvideo').attr('class')
        })

    })

    return objArr;
}

