//Delete Data


const partialcomponentbody = $('#partialComponentbody');

$(partialcomponentbody).delegate(".Deletebtn", "click", function () {
    debugger;
    const url = $(this).attr('endpoint');
    const redirecturl = $(this).attr('redirecturlpoint');
    const id = $(this).attr('Id');
    AjaxRequest(url, 'POST', { id }, (data) => {

        if (data == 'Success') {
            RenderPartial(redirecturl, partialcomponentbody);
            ToastAlert('Deleted', 'success');
        }
        else {
            console.log(data);
        }
    })

})


