$(document).ready(function () {
    $("#btnSaveRole").click(function () {
        var isStudent = $("#isStudent").is(':checked');
        var isTeacher = $("#isTeacher").is(':checked');
        var isAdmin = $("#isAdmin").is(':checked');
        var userID = $("#userID").val();

        var url = "/Admin/Permission/Edit";
        $.ajax({
            type: 'post',
            url: url,
            data: {
                UserID: userID,
                IsStudent: isStudent,
                IsTeacher: isTeacher,
                IsAdmin: isAdmin
            },
            success: function (data) {
            },
            fail: function (data) {
            }
        });
    });
});