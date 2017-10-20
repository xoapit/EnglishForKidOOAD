function loadFeedbackHistories() {
    var urlGetFeedbackHistories = "/Feedback/FeedbackReplyHistoriesByFeedbackID";
    var idFeedbackReply = $(".modal-body #viewFeedbackId").val();
    $.ajax({
        type: 'post',
        url: urlGetFeedbackHistories,
        data: {
            id: idFeedbackReply,
        },
        success: function (data) {
            var json = data;
            Console.log(json);
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

    //$('#feedbackReplyHistoryTable').DataTable({
    //    dom: "Bfrtip",
    //    ajax:{
    //        type: 'POST',
    //        url: urlGetFeedbackHistories,
    //        data: {
    //            id: idFeedbackReply,
    //        },
    //        success: function (data) {
    //            var json = $.parseJSON(data);
    //            $(json).each(function (i, val) {
    //                $.each(val, function (k, v) {
    //                    console.log(k + " : " + v);
    //                });
    //            });
    //        }
    //    },
    //    columns: [
    //        { data: "ID" },
    //        { data: "Subject" },
    //        { data: "Content" },
    //        { data: "CreateAt" },
    //    ],
    //});
    //var json = $.parseJSON(j);
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

