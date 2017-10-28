function loadViewCount() {

    var urlGetFeedbackHistories = "/Home/GetCount";
    $.ajax({
        type: 'post',
        url: urlGetFeedbackHistories,
        data: {
            
        },
        success: function (data) {
            var json = $.parseJSON(data);
            $("#viewCountMonth").html(json.Year);
        },
        fail: function (data) {
           
        }
    });
}

function getLinkImages() {
    var urlLesson = "Home/GetCount";
    $.ajax({
        type: 'post',
        url: urlLesson,
        data: {

        },
        success: function (data) {
            var json = $.parseJSON(data);
            document.getElementById("img1").innerHTML += '<img src="' + json[1].Image + '">';
        }
    });
}
$(document).ready(function () {
    getLinkImages();
    loadViewCount();
});



