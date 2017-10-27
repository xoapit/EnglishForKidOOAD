$(document).on("click", ".view-Feedback", function () {
    var feedbackId = $(this).data('feedback-id');
    $(".modal-body #viewFeedbackId").val(feedbackId);
    $('#myModalDetailFeedback input[name="detailFeedbackTitle"]').val($(this).closest("tr").find("td:nth-child(2)").text());
    $('#myModalDetailFeedback input[name="detailFeedbackSender"]').val($(this).closest("tr").find("td:nth-child(3)").text());
    $('#myModalDetailFeedback input[name="detailFeedbackTime"]').val($(this).closest("tr").find("td:nth-child(4)").text());
    $('#myModalDetailFeedback textarea[name="detailFeedbackContent"]').val($(this).closest("tr").find("td:nth-child(5)").text());
    loadFeedbackHistories();
    $('#btnMinusFeedbackReplyHistory').trigger('click');
});

$(document).on("click", ".delete-Feedback", function () {
    var feedbackId = $(this).data('feedback-id');
    $(".modal-body #deleteFeedbackId").val(feedbackId);
});

$(document).ready(function () {
    $('#btnDeleteFeedback').click(function () {
        var urlDelete = "/Feedback/Delete";
        var idFeedback = $('#deleteFeedbackId').val();

        $.ajax({
            type: 'post',
            url: urlDelete,
            data: {
                id: idFeedback
            },
            success: function (response) {
                if (response !== false) {
                    $('#deleteMessage').text("You deleted the feedback successfully!");
                }
                else {
                    $('#deleteMessage').text("Can not delete the feedback!");
                }
                $('#deleteMessageBox').fadeIn(1000);
                setTimeout(function () {
                    location.reload();
                }, 1000);
            },
            fail: function (response) {
                $('#deleteMessage').text("Can not delete the feedback!");
            }
        });
    });

    sendEmailToReplyFeedback();
});

function sendEmailToReplyFeedback() {
    $('#btnSendEmail').click(function () {
        var urlAdd = "/Feedback/AddFeedbackReplyHistory";
        var feedbackId = $(".modal-body #viewFeedbackId").val();
        var subjectFeedbackReply = $(".modal-body #subjectFeedbackReply").val();
        var contentFeedbackReply = $(".modal-body #contentFeedbackReply").val();
        
        $.ajax({
            type: 'post',
            url: urlAdd,
            data: {
                FeedbackID: feedbackId,
                Subject: subjectFeedbackReply,
                Content: contentFeedbackReply,
            },
            success: function (response) {
                if (response !== false) {
                    $('#sendEmailMessage').text("You send the email successfully!");
                }
                else {
                    $('#sendEmailMessage').text("Can not send the email!");
                }
                setTimeout(function () {
                    location.reload();
                }, 1000);
            },
            fail: function (response) {
                $('#sendEmailMessage').text("Can not send the email!");
            }
        });
    });
}

function guid() {
    return s4() + s4() + '-' + s4() + '-' + s4() + '-' +
        s4() + '-' + s4() + s4() + s4();
}

function s4() {
    return Math.floor((1 + Math.random()) * 0x10000)
        .toString(16)
        .substring(1);
}