function getChartData(days) {
    var url = "/Admin/Home/GetChartData?days=" + days;
    $.ajax({
        type: 'get',
        url: url,
        data: {
        },
        success: function (data) {
            initChart(data);
        },
        fail: function (data) {
        }
    });
}

$(document).ready(function () {
    getChartData(14);
})

function initChart(chartData) {
    var ctx = document.getElementById("myChart").getContext('2d');
    $("#titleChart").text("Time: " + chartData.Labels[0] + " - " + chartData.Labels[chartData.Labels.length - 1] + ", " + (new Date()).getFullYear());
    var myChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: chartData.Labels,
            datasets: [{
                label: '# of Lessons',
                data: chartData.Lessons,
                backgroundColor: [
                    'rgba(255, 99, 132, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(255, 206, 86, 0.2)',
                    'rgba(75, 192, 192, 0.2)',
                    'rgba(153, 102, 255, 0.2)',
                    'rgba(255, 159, 64, 0.2)'
                ],
                borderColor: [
                    'rgba(255,99,132,1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(255, 206, 86, 1)',
                    'rgba(75, 192, 192, 1)',
                    'rgba(153, 102, 255, 1)',
                    'rgba(255, 159, 64, 1)'
                ],
                borderWidth: 1
            }, {
                label: '# of Users',
                data: chartData.Users,
                backgroundColor: [
                    'rgba(255, 99, 132, 0.2)',
                    'rgba(215, 162, 235, 0.2)',
                    'rgba(255, 206, 86, 0.2)',
                    'rgba(125, 192, 192, 0.2)',
                    'rgba(201, 102, 255, 0.2)',
                    'rgba(255, 159, 64, 0.2)'
                ],
                borderColor: [
                    'rgba(25,99,132,1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(25, 206, 86, 1)',
                    'rgba(50, 192, 192, 1)',
                    'rgba(13, 102, 255, 1)',
                    'rgba(55, 159, 64, 1)'
                ],
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }],
            }
        }
    });
}