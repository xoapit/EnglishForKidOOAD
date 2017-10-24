$(document).on("click", ".view-Account", function () {
    var idAccount = $(this).data('id');
    loadAccount(idAccount);
});

function loadAccount(idAccount) {
    $('#viewAccount').html("");

    var urlGetAccount = "/Admin/Student/Details";
    $.ajax({
        type: 'post',
        url: urlGetAccount,
        data: {
            id: idAccount,
        },
        success: function (data) {
            data = data.trim();
            $('#viewAccount').html(data);  
        },
        fail: function (data) {
            $('#viewAccount').html("Loading....");
        }
    });
}




