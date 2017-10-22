function loadViewCount() {

    var urlGetFeedbackHistories = "/Home/GetCount";
    $.ajax({
        type: 'post',
        url: urlGetFeedbackHistories,
        data: {
            
        },
        success: function (data) {
            var json = $.parseJSON(data);
            $("#viewCountMonth").html(json.Year);
        },
        fail: function (data) {
           
        }
    });
}
$(document).ready(function () {
    loadViewCount();
});



