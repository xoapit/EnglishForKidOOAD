$(document).ready(function () {
    $('#btnLogin').click(function () {
        username = $('#username').val();
        password = $('#password').val();
        rememberMe = false;
       
        urlLogin = "Account/Login";
        $.ajax({
            type: 'post',
            url: urlLogin,
            data: {
                username: username,
                password: password,
                rememberMe: rememberMe,
            },
            success: function (data) {
                //var json = $.parseJSON(data);
                var json = data;
                if (json["error"] === "invalid_grant") {
                    var des = json["error_description"];
                    $('#loginMessage').text(des);
                } else {
                    urlForward = json;
                    window.location.href = urlForward;
                }
            },
            fail: function (data) {
                    $('#loginMessage').val("Can not connect to server!");
            }
        });
    });
});