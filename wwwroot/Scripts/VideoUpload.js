$('#partialComponentbody').delegate('#uploadvideo', 'click', function () {
    debugger;
    const validfomrats = ['mp4', 'avi', 'mkv'];
    const uploadedfile = $('#videofile')[0].files[0];
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

function RenderUploadedVideoUi(data) {
    debugger;
    const container = $('.videouploadedContainer');

    if (data) {
        PopUpAlert("Video Uploaded Successfully", 'success', 'SAVED');
        $(container).empty();
        const markup = `<div class="row">
                    <div class="col-sm-4">
                        <a href="#" data-title="">
                            <video id="showvideo" controls width="400" height="260">
                                <source id="videosrc" src="/Videos/${data.videoPath}" type="video/mp4" />
                            </video>
                        </a>
                    </div>
                </div>`;
        $(container).append(markup);
        const videoelem = document.getElementById('showvideo');
        videoelem.load();
        $('.totalvideos').text(data.totalVideos);
    }

}
