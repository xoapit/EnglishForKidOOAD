$(document).ready(function () {
    hideExtraAnswer();
});

function hideExtraAnswer() {
    var answerItems = $('.answerContent').each(function () {
        var i = 0;
        $(this).children('div').each(function () {
            if (i > 2) $(this).hide();
            i++;
        });
    });
}

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

function showAnswerTo(index) {
    for (var i = 0; i <= 6; i++) {
        if (i <= index) {
            $('.answerContent').find("div:nth-child(" + i + ")").show();
        }
    }
}

$(document).on("click", ".view-Question", function () {
    var feedbackId = $(this).data('feedback-id');
    $(".modal-body #viewFeedbackId").val(feedbackId);
    $('#myModalDetailFeedback input[name="detailFeedbackTitle"]').val($(this).closest("tr").find("td:nth-child(2)").text());
});

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




