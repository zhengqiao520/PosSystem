var IndexPieChartData=function(legendData,data){
    this.Init=function(el)
    {
        var echart=echarts.init(document.getElementById(el))
        echart.setOption(chartOptions)
    }
   var chartOptions={
            title: {
                text: '品类销售数�?,
                subtext: '',
                x: 'left'
            },
        tooltip: {
            trigger: 'item',
            formatter: "{a} <br/>{b} : {c} ({d}%)"
        },
        legend: {
            data:legendData,
            orient: 'horizontal',
            left: 'center'
        },
        series: [
            {
                name: '品类销售数�?,
                type: 'pie',
                radius: '55%',
                center: ['50%', '60%'],
                data:data,
                itemStyle: {
                    emphasis: {
                        shadowBlur: 10,
                        shadowOffsetX: 0,
                        shadowColor: 'rgba(0, 0, 0, 0.5)'
                    }
                }
            }
        ]
   }
}