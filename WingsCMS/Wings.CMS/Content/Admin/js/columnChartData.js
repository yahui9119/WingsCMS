var chart;
/**crender:图表存放容器;
ctitle:图表标题;
csubtitle:图表子标题;
cyAxis:y轴标题;
tdata:标题数据
cdata:内容数据**/
function ShowColumnChart(crender, ctitle, csubtitle, cyAxis, tdata, cdata) {
    chart = new Highcharts.Chart({
        chart: {
            renderTo: crender,
            type: 'column'
        },
        title: {
            text: ctitle
        },
        subtitle: {
            text: csubtitle
        },
        xAxis: {
            categories: eval("(" + tdata + ")")
        },
        yAxis: {
            min: 0,
            title: {
                text: cyAxis
            }
        },
        legend: {
            layout: 'vertical',
            backgroundColor: '#FFFFFF',
            align: 'left',
            verticalAlign: 'top',
            x: 100,
            y: 70,
            floating: true,
            shadow: true
        },
        tooltip: {
            formatter: function () {
                return '' +
                        this.x + ': ' + this.y + ' 人';
            }
        },
        plotOptions: {
            column: {
                pointPadding: 0.2,
                borderWidth: 0
            }
        },
        series: [{
            name: '等级人数',
            data: eval("(" + cdata + ")")//[49.9, 71.5, 106.4, 129.2, 144.0, 176.0]

        }]
    });
};