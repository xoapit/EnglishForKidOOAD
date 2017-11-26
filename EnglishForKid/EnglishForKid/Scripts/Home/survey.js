$(document).ready(function () {
    LoadSurvey();
});

function LoadSurvey() {
    var url = "/Home/GetActiveSurvey";
    $.ajax({
        type: 'post',
        url: url,
        data: {
        },
        success: function (res) {
            var data = JSON.parse(res);
            var content = data.Content;
            var codeHtml = '<div><strong>' + content + "</strong></div>";
            codeHtml += '<input hidden type="text" id="questionID" value="' + data.ID + '"></input>';
            for (var i = 0; i < data.AnswerSurveys.length; i++) {
                var checked = '';
                if (i == 0) {
                    checked = 'checked';
                }
                codeHtml += '<div class="radio"><input class="radio-answer" data-answer-id="' + data.AnswerSurveys[i].ID + '" type="radio"' + checked + ' name="optradio">' + data.AnswerSurveys[i].Answer + '</div>';
            }
            codeHtml += '<button id="btnSendAnswer" onClick="PostAnswer()" class="btn btn-danger pull-right"> OK </button>'
            $('#survey').html(codeHtml);
        },
        fail: function (data) {
            alert("Can not get comments. Error!!!");
        }
    });
}

function PostAnswer() {
    var questionId = $('#questionID').val();
    var answerId = '';
    var result = $('.radio-answer').each(function () {
        if ($(this).is(":checked")) {
            answerId = $(this).data('answer-id');
        }
    });

    var url = "/Home/PostResult";
    $.ajax({
        type: 'post',
        url: url,
        data: {
            QuestionSurveyID: questionId,
            AnswerID: answerId
        },
        success: function (data) {
            setTimeout(function () {
            }, 500);
            location.reload();
        },
        fail: function (data) {
        }
    });
};