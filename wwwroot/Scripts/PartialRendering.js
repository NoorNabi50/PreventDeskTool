
$('.Rendercomponent').click(function () {
    debugger;
    const Endpointurl = $(this).attr('endpoint');
    const PartialComponentbody = $('#partialComponentbody');
    if (Endpointurl) {
        AjaxRequest(Endpointurl, 'GET', null, (data) => {

            if (data) {
                $(PartialComponentbody).empty();
                $(PartialComponentbody).append(data);

                $('#datatable').DataTable();
            }

            else {
                console.log("Data mein kuch nhi aahya");
                return
            }
        })
    }

});


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