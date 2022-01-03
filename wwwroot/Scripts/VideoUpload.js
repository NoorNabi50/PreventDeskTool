
$('#partialComponentbody').delegate('#uploadvideo', 'click', function () {
    debugger;
    const validfomrats = ['mp4', 'avi', 'mkv'];
    const uploadedfile = $('#videofile')[0].files[0];
    if (!uploadedfile) {
        PopUpAlert('Please Select File', 'warning', 'Error');
        return;
    }
    const [filename, fileExtension] = uploadedfile.name.split('.');
    const isValidFormat = validfomrats.some(x => fileExtension.includes(x));
    if(!isValidFormat) {
            PopUpAlert("Please Select Valid Video Format", 'warning', 'Invalid Format');
            $('#videoform').reset();
            return;
     }
    let formData = new FormData();
    formData.append('video', $('#videofile')[0].files[0]);
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
                    <div class="col-sm-6">
                        <a href="#" data-title="">
                            <video id="showvideo" class="${data.VideoId}" controls width="600" height="290">
                                <source id="videosrc" src="/Videos/${data.videoPath}" type="video/mp4" />
                            </video>
                        </a>
                           <center>
                          <button id="AddanomBtn" class="btn btn-success">Add Anomaly <i class="fas fa-plus"></i></button>
                       </center> <br>
                 </div>
                  <div class="col-sm-5">
                     <div class="card card-primary">
                    <div class="card-header">
                      <h3 class="card-title">Anomalies Detected</h3>
                  </div>
                     <div class="AnomalyContainer"></div>
                    
                  </div>
                </div>`;
        $(container).append(markup);
         videoElem = document.getElementById('showvideo');
         videoElem.load();
        $('.totalvideos').text(data.totalVideos);
    }

}


$('#partialComponentbody').delegate('#AddanomBtn', 'click', function () {
    debugger;
    const TimeInterval = Math.round(videoElem.currentTime)+' seconds';
    $('.AnomalyContainer').append(`<input type="text" value="${TimeInterval}" class="form-control"/>`)
});