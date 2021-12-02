
$('.Rendercomponent').click(function () {
   debugger;
    const Endpointurl = $(this).attr('endpoint');
    const PartialComponentbody = $('#partialComponentbody');
    if (Endpointurl) {
        RenderPartial(Endpointurl, PartialComponentbody)
        return;
    }
});

