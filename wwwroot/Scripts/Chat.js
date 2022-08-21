const messageElem = $('#MessageTxt');

let chatlistConatiner = $('.direct-chat-messages');



$('.SendMessage').click(() => {
    SendMessage();
})



messageElem.keypress(function (e) {
    debugger;
    if(e.keyCode == 13)
       SendMessage();
})

function SendMessage() {
    debugger;
    if (messageElem.val() == '')
        return;

    const model = {
        MessageText: messageElem.val()
    }

    AjaxRequest('/Chat/SaveChat', 'POST', model, data => {

        if (data) {
            $('#NoMessagesYet').hide();
            messageElem.val('');
            chatlistConatiner.append(`<div class="direct-chat-msg right">
                                        <div class="direct-chat-infos clearfix">
                                            <span class="direct-chat-name float-right">Me</span>
                                            <span class="direct-chat-timestamp float-left">${data.messageDate}</span>
                                        </div>

                                        <img class="direct-chat-img" src="/assets/dist/img/user1-128x128.jpg" alt="Message User Image">

                                        <div class="direct-chat-text">
                                      ${data.messageText}
                                        </div>
                                        <!-- /.direct-chat-text -->
                                    </div>`);
            chatlistConatiner.scrollTop(chatlistConatiner[0].scrollHeight);
           
        }
    })

}