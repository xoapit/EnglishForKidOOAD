$(document).on("click", ".add-lesson", function () {
    AddNewLesson();
});

$(document).on("click", ".view-lesson", function () {
    var lessonID = $(this).data('lesson-id');
    loadLesson(lessonID);
});

$(document).on("click", ".update-lesson", function () {
    var lessonID = $(this).data('lesson-id');
    loadLesson(lessonID);
});

$(document).on("click", ".delete-lesson", function () {
    var lessonID = $(this).data('lesson-id');
    $(".modal-body #deleteLessonId").val(lessonID);
});

$(document).ready(function () {
    $('#btnDeleteLesson').click(function () {
        var urlDelete = "/Teacher/Lesson/DeleteLesson";
        var idLesson = $('#deleteLessonId').val();

        $.ajax({
            type: 'post',
            url: urlDelete,
            data: {
                id: idLesson
            },
            success: function (response) {
                if (response !== false) {
                    $('#deleteMessage').text("You deleted the lesson successfully!");
                }
                else {
                    $('#deleteMessage').text("Can not delete the lesson!");
                }
                $('#deleteMessageBox').fadeIn(1000);
                setTimeout(function () {
                    location.reload();
                }, 1000);
            },
            fail: function (response) {
                $('#deleteMessage').text("Can not delete the lesson!");
            }
        });
    });
});

function loadLesson(lessonID) {
    $('#detailLesson').html("");

    var urlGetLesson = "/Teacher/Lesson/Details";
    $.ajax({
        type: 'post',
        url: urlGetLesson,
        data: {
            id: lessonID,
        },
        success: function (data) {
            data = data.trim();
            $('#detailLesson').html(data);
        },
        fail: function (data) {
            $('#detailLesson').html("Loading....");
        }
    });
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
