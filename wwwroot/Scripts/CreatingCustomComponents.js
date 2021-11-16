
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
