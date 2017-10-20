$(document).on("click", ".view-Feedback", function () {
    $('#myModalDetailFeedback input[name="detailFeedbackTitle"]').val($(this).closest("tr").find("td:nth-child(2)").text());
    $('#myModalDetailFeedback input[name="detailFeedbackSender"]').val($(this).closest("tr").find("td:nth-child(3)").text());
    $('#myModalDetailFeedback input[name="detailFeedbackTime"]').val($(this).closest("tr").find("td:nth-child(4)").text());
    $('#myModalDetailFeedback textarea[name="detailFeedbackContent"]').val($(this).closest("tr").find("td:nth-child(5)").text());
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
                if (response != false) {
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
    })
});