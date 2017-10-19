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