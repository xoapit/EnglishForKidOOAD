$(document).on("click", ".view-Feedback", function () {
    var feedbackId = $(this).data('feedback-id');
    $(".modal-body #deleteFeedbackId").val(feedbackId);
    $('#myModalDetailFeedback input[name="deleteFeedbackTitle"]').val($(this).closest("tr").find("td:nth-child(2)").text());
    $('#myModalDetailFeedback input[name="deleteFeedbackSender"]').val($(this).closest("tr").find("td:nth-child(3)").text());
    $('#myModalDetailFeedback input[name="deleteFeedbackTime"]').val($(this).closest("tr").find("td:nth-child(4)").text());
    $('#myModalDetailFeedback textarea[name="deleteFeedbackContent"]').val($(this).closest("tr").find("td:nth-child(5)").text());
});

$(document).ready(function () {
    $('#btnDeleteFeedback').click(function () {
        var url = "/Admin/Feedback/Delete";
        $.post(url, {
            Id: $('#deleteFeedbackId').val()
        }, function (data) {
            $('#deleteMessage').text("You deleted the feedback successfully!");
            $('#deleteMessageBox').fadeIn(1000);
            setTimeout(function () {
                location.reload();
            }, 1000);
        })
    })
});