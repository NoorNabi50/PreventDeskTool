
$('.Rendercomponent').click(function () {
    const Endpointurl = $(this).attr('endpoint');
    window.speechSynthesis.cancel();
    const PartialComponentbody = $('#partialComponentbody');
   
    if (Endpointurl) {
        RenderPartial(Endpointurl, PartialComponentbody)
        return;
    }
});

