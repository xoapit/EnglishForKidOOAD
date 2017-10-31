$(document).ready(function () {
    var lessonID = GetURLParameter("id");
    LoadComments(lessonID);

    $("#btnSendComment").click(function () {
        var content = $("#commentContent").val();
        var lessonID = GetURLParameter("id");
        var url = "/Lesson/AddComment";
        $.ajax({
            type: 'post',
            url: url,
            data: {
                Content: content,
                LessonID: lessonID
            },
            success: function (data) {
                setTimeout(function () {
                }, 500);
                LoadComments(lessonID);
                $("#commentContent").val("");
            },
            fail: function (data) {
                alert("Can not add comment. Error!!!");
            }
        });
    });
});

function LoadComments(lessonId) {
    var url = "/Lesson/GetComments";
    $.ajax({
        type: 'post',
        url: url,
        data: {
            LessonID: lessonId
        },
        success: function (data) {
            $("#listComments").html(data);
        },
        fail: function (data) {
            alert("Can not get comments. Error!!!");
        }
    });
}

function GetURLParameter(sParam) {
    var sPageURL = window.location.search.substring(1);
    var sURLVariables = sPageURL.split('&');
    for (var i = 0; i < sURLVariables.length; i++) {
        var sParameterName = sURLVariables[i].split('=');
        if (sParameterName[0] == sParam) {
            return decodeURIComponent(sParameterName[1]);
        }
    }
}