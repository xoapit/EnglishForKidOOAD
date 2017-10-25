$(document).on("click", ".view-Account", function () {
    var idAccount = $(this).data('id');
    loadAccount(idAccount);
});

$(document).on("click", ".update-Account", function () {
    var idAccount = $(this).data('id');
    loadUpdateAccount(idAccount);
});

$(document).on("click", ".block-Account", function () {
    var idAccount = $(this).data('id');
    var status = $(this).data('status');
    $('#block-account-id').val(idAccount);
    $('#block-account-status').val(status);
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

function loadUpdateAccount(idAccount) {
    $('#update-accountId').val(idAccount);

    var urlGetAccount = "/Admin/Student/Edit";
    $.ajax({
        type: 'get',
        url: urlGetAccount,
        data: {
            id: idAccount,
        },
        success: function (data) {
            data = data.trim();
            $('#updateAccount').html(data);
        },
        fail: function (data) {
            $('#updateAccount').html("Loading....");
        }
    });
}

$(document).on("click", "#btnUpdateAccount", function () {
    updateAccount();
});


function updateAccount() {
    var idAccount = $('#update-account-id').val();
    var fullname = $('#update-fullname').val();
    var birthday = $('#update-birthday').val();
    var email = $('#update-email').val();
    var phone = $('#update-phone').val();
    var address = $('#update-address').val();
    var gender = $('#update-gender:checked').val();

    var urlUpdateAccount = "/Admin/Student/Edit/" + idAccount;
    $.ajax({
        type: 'post',
        url: urlUpdateAccount,
        data: {
            accountId: idAccount,
            fullname: fullname,
            birthday: birthday,
            email: email,
            phone: phone,
            address: address,
            gender: gender
        },
        success: function (data) {
            if (data) {
                $('#updateMessage').text("You have updated successfully!");
                setTimeout(function () {
                    location.reload();
                }, 1000);
            } else {
                $('#updateMessage').text("Can not update!!!");
            }

        },
        fail: function (data) {
            $('#updateMessage').html("Can not update!!!");
        }
    });
}

$(document).on("click", "#btn-block-account", function () {
    var idAccount = $('#block-account-id').val();
    var status = $('#block-account-status').val();

    var urlUpdateAccount = "/Admin/Student/Lock";
    $.ajax({
        type: 'post',
        url: urlUpdateAccount,
        data: {
            id: idAccount,
            status: status
        },
        success: function (data) {
            if (data) {
                $('#blockMessage').text("You have changed status successfully!");
                setTimeout(function () {
                    location.reload();
                }, 1000);
            } else {
                $('#blockMessage').text("Can not change status. Error!!!");
            }

        },
        fail: function (data) {
            $('#blockMessage').html("Can not change status. Error!!!");
        }
    });
});