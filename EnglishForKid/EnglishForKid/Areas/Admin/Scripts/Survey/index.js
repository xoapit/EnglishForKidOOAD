$(document).ready(function () {
    hideExtraAnswer();
});


$(document).ready(function () {
    $('.detailQuestion').click(function () {
        var urlDetail = "/Survey/GetQuestion";
        var idQuestion = $(this).data('question-id');

        $("#formDetailQuestion").empty();

        $.ajax({
            type: 'get',
            url: urlDetail,
            data: {
                id: idQuestion
            },
            success: function (response) {

                var json = response;

                $("#formDetailQuestion").append("<div class=\"form-group row\"><label id=\"contentQuestionSurvey\" style=\"color:slateblue;\">Content: " + json.questionSurvey.Content + "</label></div>");

                for (var i = 0; i < json.questionSurvey.AnswerSurveys.length; i++) {
                    $("#formDetailQuestion").append("<div class=\"form-group row\"><label class=\"col-md-2 col-xs-12 text-left\">Answer " + (i + 1) + ":</label><div class=\"col-md-10 col-xs-12\"><label class=\"col-md-10 col-xs-12 text-left\">" + json.questionSurvey.AnswerSurveys[i].Answer + "</label></div></div>");
                }
            },
            fail: function (response) {
                $("#formDetailQuestion").append("<div class=\"form-group row\"><label id=\"contentQuestionSurvey\" style=\"color:slateblue;\">No Data. Please Reload.</label></div>");
            }
        });
    });

    var jsonUpdateQuestion;

    $('.updateQuestion').click(function () {

        var urlDetail = "/Survey/GetQuestion";
        var idQuestion = $(this).data('question-id');

        $('#answerContent').empty();

        $.ajax({
            type: 'get',
            url: urlDetail,
            data: {
                id: idQuestion
            },
            success: function (response) {

                var json = response;
                var jsonUpdateQuestion = response;

                $('#contentUpdate').val(json.questionSurvey.Content);
                $('#updateQuestion').val(json.questionSurvey.ID);

                for (var i = 0; i < json.questionSurvey.AnswerSurveys.length; i++) {
                    $('#answerContent').append("<div class=\"form-group row\"><label class=\"col-md-2 col-xs-12 text-left\">Answer " + (i + 1) + "</label><div class=\"col-md-10 col-xs-12\"><input type=\"text\" class=\"form-control\" id=\"answerUpdate" + i + "\" value=\"" + json.questionSurvey.AnswerSurveys[i].Answer + "\"></div></div>");
                }
            },
            fail: function (response) {
                $('#answerContent').text("No data. Please reload.");
            }
        });
    });

    updateQuestion();

    $('.activeQuestion').click(function () {
        var urlDetail = "/Survey/UpdateQuestion";
        var idQuestion = $(this).data('question-id');

        $.ajax({
            type: 'get',
            url: urlDetail,
            data: {
                id: idQuestion
            },
            success: function (response) {

                var json = response;
                console.log(json);
                console.log(json.questionSurvey.AnswerSurveys[0]);
                $("#contentQuestionSurvey").text("Content: " + json.questionSurvey.Content);

                for (var i = 0; i < json.questionSurvey.AnswerSurveys.length; i++) {
                    $("#formDetailQuestion").append("<div class=\"form-group row\"><label class=\"col-md-2 col-xs-12 text-left\">Answer " + (i + 1) + ":</label><div class=\"col-md-10 col-xs-12\"><label class=\"col-md-10 col-xs-12 text-left\">" + json.questionSurvey.AnswerSurveys[i].Answer + "</label></div></div>");
                }
            },
            fail: function (response) {
                $('#deleteMessage').text("Can not delete the feedback!");
            }
        });
    });

    $('.deleteQuestion').click(function () {
        var urlDetail = "/Survey/UpdateQuestion";
        var idQuestion = $(this).data('question-id');

        $.ajax({
            type: 'get',
            url: urlDetail,
            data: {
                id: idQuestion
            },
            success: function (response) {

                var json = response;
                console.log(json);
                console.log(json.questionSurvey.AnswerSurveys[0]);
                $("#contentQuestionSurvey").text("Content: " + json.questionSurvey.Content);

                for (var i = 0; i < json.questionSurvey.AnswerSurveys.length; i++) {
                    $("#formDetailQuestion").append("<div class=\"form-group row\"><label class=\"col-md-2 col-xs-12 text-left\">Answer " + (i + 1) + ":</label><div class=\"col-md-10 col-xs-12\"><label class=\"col-md-10 col-xs-12 text-left\">" + json.questionSurvey.AnswerSurveys[i].Answer + "</label></div></div>");
                }
            },
            fail: function (response) {
                $('#deleteMessage').text("Can not delete the feedback!");
            }
        });
    });


    

    $('#quantity').change(function () {
        hideExtraAnswer();
        var index = $(this).val();
        showAnswerTo(index);
    });
    $('#quantity1').change(function () {
        hideExtraAnswer();
        var index = $(this).val();
        showAnswerTo(index);
    });

    

    $(document).on("click", ".view-Question", function () {
        var feedbackId = $(this).data('feedback-id');
        $(".modal-body #viewFeedbackId").val(feedbackId);
        $('#myModalDetailFeedback input[name="detailFeedbackTitle"]').val($(this).closest("tr").find("td:nth-child(2)").text());
    });

});

function updateQuestion() {
    $('#updateQuestion').click(function () {
        var urlUpdate = "/Survey/UpdateQuestion";
        var idQuestion = $('#updateQuestion').val();
        var content = $('#contentUpdate').val();

        var answers = [];

        var inputCount = document.getElementById('answerContent').getElementsByTagName('input').length;

        for (i = 0; i < inputCount; i++) {
            answers.push($('#answerUpdate' + i).val());
        }

        $.ajax({
            type: 'post',
            url: urlUpdate,
            data: {
                id: idQuestion,
                content: content,
                answers: answers
            },
            success: function (res) {
                setTimeout(function () { }, 1000);
                location.reload();
            },
            fail: function (response) {
            }
        });
        location.reload();
    });
}

function loadDetailSurveyQuestion(id) {
    $('#bodyDetailSurveyQuestion').html("");

    var urlDetailSurveyQuestion = "/Feedback/DetailSurveyQuestionByID";
    var idDetailSurveyQuestion = id;
    $.ajax({
        type: 'post',
        url: urlDetailSurveyQuestion,
        data: {
            id: idDetailSurveyQuestion,
        },
        success: function (data) {
            var json = $.parseJSON(data);
            var tr;
            for (var i = 0; i < json.length; i++) {
                tr = $('<div/>');
                tr.append("<textarea class='form-control' readonly style='background-color:white'>" + json.Content + "</textarea>");
                $('#detailQuestionContent').append(tr);
            }
        },
        fail: function (data) {

        }
    });
}

function hideExtraAnswer() {
    var answerItems = $('.answerContent').each(function () {
        var i = 0;
        $(this).children('div').each(function () {
            if (i > 2) $(this).hide();
            i++;
        });
    });
}

function showAnswerTo(index) {
    for (var i = 0; i <= 6; i++) {
        if (i <= index) {
            $('.answerContent').find("div:nth-child(" + i + ")").show();
        }
    }
}