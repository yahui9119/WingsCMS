var IsFirstClick = {};
            var chart;
        function CreateHighcharts(insertdiv, title, subtitle, Xtitle, Ytitle, tooltip, Xvalue, Yvalue) {
            
chart = new Highcharts.Chart({
                chart: {
                    renderTo: insertdiv
                },
                title: {
                    text: title,
                    x: -20 //center
                },
                subtitle: {
                    text: subtitle,
                    x: -20
                },
                xAxis: {
                    categories: Xvalue, //X轴数据
                    title: { text: Xtitle }
                },
                yAxis: {//Y轴数据
                    title: {
                        text: Ytitle
                    },
                    plotLines: [{
                        value: 0,
                        width: 1,
                        color: '#808080'
                    }]
                },
                tooltip: {
                    formatter: function () {
                        return '<b>' + this.series.name + '</b><br/>' +
                        this.x + ': ' + this.y + tooltip;
                    }
                },
                legend: {
                    layout: 'vertical',
                    align: 'right',
                    verticalAlign: 'top',
                    x: -10,
                    y: 100,
                    borderWidth: 0
                },
                series: [{
                    name: subtitle,
                    data: Yvalue
                }]
            });
        }