
$(document).ready(function () {

    var areaChartData = {
        labels: ['2015-16', '2016-17', '2017-18', '2018-19', '2019-20'],
        datasets: [
            {
                label: 'Killed',
                backgroundColor: '#FD2000',
                pointHighlightFill: '#FD2000',
                data: [4448, 5047, 5948, 5932, 5436]
            },
            {
                label: 'Injured',
                backgroundColor: '#FCBC2D',
                pointHighlightFill: '#FCBC2D',
                data: [11544, 12696, 14489, 13219, 12317]
            },
        ]
    }

    var areaChartOptions = {
        maintainAspectRatio: false,
        responsive: true,
        legend: {
            display: false
        },
        scales: {
            xAxes: [{
                gridLines: {
                    display: false,
                }
            }],
            yAxes: [{
                gridLines: {
                    display: false,
                }
            }]
        }
    }


    var barChartCanvas = $('#barChart').get(0).getContext('2d')
    var barChartData = $.extend(true, {}, areaChartData)
    var temp0 = areaChartData.datasets[0]
    var temp1 = areaChartData.datasets[1]
    barChartData.datasets[0] = temp1
    barChartData.datasets[1] = temp0

    var barChartOptions = {
        responsive: true,
        maintainAspectRatio: false,
        datasetFill: false
    }

    new Chart(barChartCanvas, {
        type: 'bar',
        data: barChartData,
        options: barChartOptions
    });
}); 

