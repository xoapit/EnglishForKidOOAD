$(document).on("click", ".view-lesson", function () {
    var lessonID = $(this).data('lesson-id');
    $(".modal-body #viewLessonId").val(lessonID);
    $('#myModalDetailLesson input[name="detailLessonTitle"]').val($(this).closest("tr").find("td:nth-child(2)").text());
    $('#myModalDetailLesson select[name="detailLessonLevel"]').val($(this).closest("tr").find("td:nth-child(3)").text());
    $('#myModalDetailLesson input[name="detailLessonPicture"]').val($(this).closest("tr").find("td:nth-child(4)").text());
    $('#myModalDetailLesson select[name="detailLessonCategory"]').val($(this).closest("tr").find("td:nth-child(5)").text());
    $('#myModalDetailLesson textarea[name="detailLessonContent"]').val($(this).closest("tr").find("td:nth-child(6)").text());
    $('#myModalDetailLesson textarea[name="detailLessonExercise"]').val($(this).closest("tr").find("td:nth-child(7)").text());
    $('#myModalDetailLesson textarea[name="detailLessonAswer"]').val($(this).closest("tr").find("td:nth-child(8)").text());
    $('#myModalDetailLesson textarea[name="detailLessonDiscussion"]').val($(this).closest("tr").find("td:nth-child(9)").text());

    //loadFeedbackHistories();
    //$('#btnMinusFeedbackReplyHistory').trigger('click');
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
            Picture: function (response) {
                if (response !== false) {
                    $('#deleteMessage').text("You deleted the lesson Picturefully!");
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

function AddNewLesson() {
    $('#btnAddLesson').click(function() {
        var urlAdd = "/Teacher/Lesson/AddLesson";
        var Title = $(".modal-body #addLessonTitle").val();
        var Level = $(".modal-body #addLessonLevel").val();
        var Picture = $(".modal-body #addLessonPicture").val();
        var Category = $(".modal-body #addLessonCategory").val();
        var Content = $(".modal-body #addLessonContent").val();
        var Exercise = $(".modal-body #addLessonExercise").val();
        var Answer = $(".modal-body #addLessonAnswer").val();
        var Discussion = $(".modal-body #addLessonDiscussion").val();
        

        $.ajax({
            type: 'post',
            url: urlAdd,
            data: {
                Title : Title,
                LevelID : Level,
                Image : Picture,
                CategoryID : Category,
                Content : Content,
                Exercise : Exercise,
                Answer : answer,
                Discussion : Discussion,
            },
            success: function (response) {
                if (response !== false) {
                    $('#sendEmailMessage').text("You add a new lesson successfully!");
                }
                else {
                    $('#sendEmailMessage').text("Can not add a new lesson!");
                }
                setTimeout(function () {
                    location.reload();
                }, 1000);
            },
            fail: function (response) {
                $('#sendEmailMessage').text("Can not add a new lesson!");
            }
        });
    });
}

$(document).on("click", ".update-lesson", function () {
    var lessonID = $(this).data('lesson-id');
    $(".modal-body #updateLessonId").val(lessonID);
    $('#myModalUpdateLesson input[name="updateLessonTitle"]').val($(this).closest("tr").find("td:nth-child(2)").text());
    $('#myModalUpdateLesson select[name="updateLessonLevel"]').val($(this).closest("tr").find("td:nth-child(3)").text());
    $('#myModalUpdateLesson input[name="updateLessonPicture"]').val($(this).closest("tr").find("td:nth-child(4)").text());
    $('#myModalUpdatelLesson select[name="updateLessonCategory"]').val($(this).closest("tr").find("td:nth-child(5)").text());
    $('#myModalUpdateLesson textarea[name="updateLessonContent"]').val($(this).closest("tr").find("td:nth-child(6)").text());
    $('#myModalUpdateLesson textarea[name="updateLessonExercise"]').val($(this).closest("tr").find("td:nth-child(7)").text());
    $('#myModalUpdateLesson textarea[name="updateLessonAswer"]').val($(this).closest("tr").find("td:nth-child(8)").text());
    $('#myModalUpdateLesson textarea[name="updateLessonDiscussion"]').val($(this).closest("tr").find("td:nth-child(9)").text());
});

function UpdateNewLesson() {
    $('#btnUpdateLesson').click(function () {
        var urlUpdate = "/Teacher/Lesson/UpdateLesson";

        var Title = $(".modal-body #updateLessonTitle").val();
        var Level = $(".modal-body #updateLessonLevel").val();
        var Picture = $(".modal-body #updateLessonPicture").val();
        var Category = $(".modal-body #updateLessonCategory").val();
        var Content = $(".modal-body #updateLessonContent").val();
        var Exercise = $(".modal-body #updateLessonExercise").val();
        var Answer = $(".modal-body #updateLessonAnswer").val();
        var Discussion = $(".modal-body #updateLessonDiscussion").val();


        $.ajax({
            type: 'put',
            url: urlUpdate,
            data: {
                Title: Title,
                LevelID: Level,
                Image: Picture,
                CategoryID: Category,
                Content: Content,
                Exercise: Exercise,
                Answer: answer,
                Discussion: Discussion,
            },
            success: function (response) {
                if (response !== false) {
                    $('#sendEmailMessage').text("You have updated lesson successfully!");
                }
                else {
                    $('#sendEmailMessage').text("Can not update lesson!");
                }
                setTimeout(function () {
                    location.reload();
                }, 1000);
            },
            fail: function (response) {
                $('#sendEmailMessage').text("Can not update lesson!");
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