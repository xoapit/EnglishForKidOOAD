$(document).on("click", ".add-lesson", function () {
    AddNewLesson();
});

$(document).on("click", ".view-lesson", function () {
    var lessonID = $(this).data('lesson-id');
    loadLesson(lessonID);
});

$(document).on("click", ".update-lesson", function () {
    var lessonID = $(this).data('lesson-id');
    loadUpdateLesson(lessonID);
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


function loadUpdateLesson(LessonID) {
    $('#updateLessonId').val(LessonID);

    var urlGetLesson = "/Teacher/Lesson/Edit";
    $.ajax({
        type: 'get',
        url: urlGetLesson,
        data: {
            id: LessonID,
        },
        success: function (data) {
            data = data.trim();
            $('#updateLesson').html(data);
        },
        fail: function (data) {
            $('#updateLesson').html("Loading....");
        }
    });
}

$(document).on("click", "#btnUpdateLesson", function () {
    updateLesson();
});

function updateLesson() {
    var LessonID = $("updateLessonID").val();
    var Title = $("#updateLessonTitle").val();
    var Level = $("#updateLessonLevel").val();
    var Picture = $("#updateLessonPicture").val();
    var Category = $("#updateLessonCategory").val();
    var Content = $("#updateLessonContent").val();
    var Exercise = $("#updatedLessonExercisse").val();
    var Answer = $("#updateLessonAnswer").val();
    var Discussion = $("#updateLessonDiscussion").val();

    var urlUpdateLesson = "/Teacher/Lesson/Edit/" + LessonID;
    $.ajax({
        type: 'post',
        url: urlUpdateLesson,
        data: {
            lessonID: LessonID,
            title: Title,
            levelID: Level,
            image: Picture,
            content: Content,
            exercise: Exercise,
            answer: Answer,
            dicussion: Discussion
        },
        success: function (data) {
            if (data) {
                $('#sendEmailMessage').text("You have updated successfully!");
                setTimeout(function () {
                    location.reload();
                }, 1000);
            } else {
                $('#sendEmailMessage').text("Can not update!!!");
            }

        },
        fail: function (data) {
            $('#sendEmailMessage').html("Can not update!!!");
        }
    });
}

function AdddNewLesson() {
    $('#btnAddLesson').click(function () {

        var LessonID = $("addLessonID").val();
        var Title = $("#addLessonTitle").val();
        var Level = $("#addLessonLevel").val();
        var Picture = $("#addLessonPicture").val();
        var Category = $("#addLessonCategory").val();
        var Content = $("#addLessonContent").val();
        var Exercise = $("#addLessonExercisse").val();
        var Answer = $("#addLessonAnswer").val();
        var Discussion = $("#addLessonDiscussion").val();

        var urlAddLesson = "/Teacher/Lesson/Creat/";
        $.ajax({
            type: 'post',
            url: urlAddLesson,
            data: {
                lessonID: LessonID,
                title: Title,
                levelID: Level,
                image: Picture,
                content: Content,
                exercise: Exercise,
                answer: Answer,
                dicussion: Discussion
            },
            success: function (data) {
                if (data) {
                    $('#sendEmailMessage').text("You have added successfully!");
                    setTimeout(function () {
                        location.reload();
                    }, 1000);
                } else {
                    $('#sendEmailMessage').text("Can not add!!!");
                }

            },
            fail: function (data) {
                $('#sendEmailMessage').html("Can not add!!!");

            }
        });

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
