const messageElem = $('#MessageTxt');

let chatlistConatiner = $('.direct-chat-messages');
var chatuserid = 0;


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
        MessageText: messageElem.val(),
        UserId: chatuserid
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

$(partialcomponentbody).delegate(".OpenChat", 'click', function () {

    chatuserid = $(this).attr('id');


    AjaxRequest("/Chat/GetChatsByUserId", 'GET', { UserId: chatuserid }, (data) => {
        if (data && data.length > 0) {
            console.log(data);
            $('#chatusername').text('').text('Chat with '+$(this).data('username'));
            chatlistConatiner.empty();
            for (let item of data) {

                if (item.messageBy == "AdminUser") {
                    chatlistConatiner.append(`<div class="direct-chat-msg">
            <div class="direct-chat-infos clearfix">
                <span class="direct-chat-name float-right">
                    Me
                </span>
                <span class="direct-chat-timestamp float-left">${item.messageDate}</span>
            </div>

            

                <div class="direct-chat-text">
                    ${item.messageText}
                </div>

        </div>`);
                }
                else {
                    chatlistConatiner.append(`<div class="direct-chat-msg right">
            <div class="direct-chat-infos clearfix">
                <span class="direct-chat-name float-left"></span>
                <span class="direct-chat-timestamp float-right">${item.messageDate}</span>
            </div>


                <div class="direct-chat-text">
                      ${item.messageText}
                </div>

        </div>`)
                }

            }

            $('#chatmodal').click();

        }

        else {
            chatlistConatiner.append(`<p class="text-center" id="NoMessagesYet">No Messages Yet..</p>`);
        }
    })

})