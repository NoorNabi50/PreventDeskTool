const partialcomponentbody = $('#partialComponentbody');
let url;
let redirecturl;
let id;
let formid;


//Delete 
$(partialcomponentbody).delegate(".Deletebtn", "click", function () {
    debugger;
    url = $(this).attr('endpoint');
    redirecturl = $(this).attr('redirecturlpoint');
    id = $(this).attr('Id');

    AjaxRequest(url, 'POST', { id }, (data) => {

        if (data == 'Success') {
            RenderPartial(redirecturl, partialcomponentbody);
            ToastAlert('Deleted', 'success','teal');
        }
        else 
            console.log(data);
        
    })

})

//Save & update

$(partialcomponentbody).delegate('.Savedata', 'click', function () {
    debugger;
    formid = $(this).closest('form').attr('id');
    formid = '#' + formid;
    url = $(formid).attr('endpoint');
    redirecturl = $(formid).attr('redirecturlpoint');

    AjaxRequest(url, 'POST',  $(formid).serialize() , (data) => {

        if (data == 'Success') {
            RenderPartial(redirecturl, partialcomponentbody);
            ToastAlert('Saved', 'success','teal');
        }

        else {
            RenderPartial(redirecturl, partialcomponentbody);
            ToastAlert('Failed', 'warning','#e12e1c');
        }
    })

})

//Open form partial page

$(partialcomponentbody).delegate('.Rendercomponent', 'click', function () {
    url = $(this).attr('endpoint');
    RenderPartial(url, partialcomponentbody);
})





