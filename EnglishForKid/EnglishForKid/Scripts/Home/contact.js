

$(document).ready(function () {

    $("#btnContactUs").click(function () {
        var name = $("#contactName").val();
        var message = $("#contactMessage").val();
        var email = $("#contactEmail").val();
        var subject = $("#contactSubject").val();
        var url = "/Home/AddFeedback";
        $.ajax({
            type: 'post',
            url: url,
            data: {
                Message: message,
                Email: email,
                Subject: subject,
                Name: name
            },
            success: function (data) {
                location.reload();
            },
            fail: function (data) {
            }
        });
    });
});