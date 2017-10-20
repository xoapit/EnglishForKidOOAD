function loadFeedbackHistories() {
    $('#bodyFeedbackReplyHistoryTable').html("");

    var urlGetFeedbackHistories = "/Feedback/FeedbackReplyHistoriesByFeedbackID";
    var idFeedbackReply = $(".modal-body #viewFeedbackId").val();
    $.ajax({
        type: 'post',
        url: urlGetFeedbackHistories,
        data: {
            id: idFeedbackReply,
        },
        success: function (data) {
            var json = $.parseJSON(data);
            var tr;
            for (var i = 0; i < json.length; i++) {
                tr = $('<tr/>');
                tr.append("<td>" + (i+1) + "</td>");
                tr.append("<td>" + json[i].Subject + "</td>");
                tr.append("<td>" + json[i].Content + "</td>");
                tr.append("<td>" + json[i].CreateAt + "</td>");
                $('#feedbackReplyHistoryTable').append(tr);
            }
        },
        fail: function (data) {
            var json = $.parseJSON(data);
            $(json).each(function (i, val) {
                $.each(val, function (k, v) {
                    console.log(k + " : " + v);
                });
            });
        }
    });
}




