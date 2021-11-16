
//render partial view 
function RenderPartial(url, renderhere) {

    AjaxRequest(url, 'GET', null, (data) => {
        if (data) {
            $(renderhere).empty();
            $(renderhere).append(data);
            $('#datatable').DataTable({
                "responsive": "true"
            });
        }

        else {
            console.log("Data mein kuch nhi aahya");
            return
        }
    })

}


//toast for alerts


function ToastAlert(message, type) {

    const Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 3000,
        timerProgressBar: true,
        
    })

    Toast.fire({
        icon: type,
        title: message,
        width: 600,
        background:'teal'
    })

}



function AjaxRequest(URL, Type, obj, CallBack) {
    $.ajax({
        url: URL,
        datatype: 'JSON',
        type: Type,
        data: obj,
        beforeSend: function () {
            console.log('Loader started');
        },
        complete: function () { console.log('Loader finshed'); },
        success: CallBack,
        error: function () { console.log('Something went wrong'); }

    });
}
