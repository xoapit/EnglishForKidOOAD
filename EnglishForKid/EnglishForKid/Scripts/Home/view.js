function loadViewCount() {

    var urlGetFeedbackHistories = window.location.origin+ "/Home/GetCount";
    $.ajax({
        type: 'post',
        url: urlGetFeedbackHistories,
        data: {
            
        },
        success: function (data) {
            var json = $.parseJSON(data);
            $("#viewCountMonth").html(json.Month);
            $("#viewCountToday").html(json.Day);
        },
        fail: function (data) {
           
        }
    });
}

function getLinkImages() {
    //var urlLesson = "Home/GetCount";
    //$.ajax({
    //    type: 'post',
    //    url: urlLesson,
    //    data: {

    //    },
    //    success: function (data) {
    //        var json = $.parseJSON(data);
    //        document.getElementById("img1").innerHTML += '<img src="' + json[1].Image + '">';
    //    }
    //});
}
$(document).ready(function () {
    getLinkImages();
    loadViewCount();
});



