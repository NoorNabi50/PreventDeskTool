
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

        else 
            console.log("Data mein kuch nhi aahya");
        
    })

}


//toast for alerts


function ToastAlert(message, type,color) {

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
        background: color

    })

}


function PopUpAlert(message,type,heading) {
    Swal.fire(
        heading,
        message,
        type
    )
} 



function AjaxRequest(URL, Type, obj, CallBack) {
    $.ajax({
        url: URL,
        datatype: 'JSON',
        type: Type,
        data: obj,
        beforeSend: function () {

        },
        complete: function () {  },
        success: CallBack,
        error: function (error) { RenderPartial('/Authentication/AccessDenied', $('#partialComponentbody')) }

    });
}

