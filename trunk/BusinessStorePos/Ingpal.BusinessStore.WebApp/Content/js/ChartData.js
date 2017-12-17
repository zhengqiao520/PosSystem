var IndexChartData = function (xData, data, charType) {
    var chartOptions = {};
    this.Init=function(el)
    {
       echarts.init(document.getElementById(el)).setOption(chartOptions)
    }
    if (charType == "categoryPieChart") {
        chartOptions = {
            title: {
                //text: '品类销售数据',
                subtext: '',
                x: 'left'
            },
            tooltip: {
                trigger: 'item',
                formatter: "{a} <br/>{b} : {c} ({d}%)"
            },
            legend: {
                data: xData,
                orient: 'horizontal',
                left: 'center'
            },
            series: [
                {
                    name: '品类销售数据',
                    type: 'pie',
                    radius: '55%',
                    center: ['50%', '60%'],
                    data: data,
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
    else if (charType == "rankStoreBarChart") {
        chartOptions = {
            title: {
                text: '销售数据（单位：元）',
                left: 'center',
                top: 1,
                textStyle: {
                    fontSize: 12,
                    fontFamily: "Microsoft YaHei",
                }
            },
            color: ['#b72f2f'],
            tooltip: {
                trigger: 'axis',
                axisPointer: {
                    type: 'shadow'
                }
            },
            legend: {
                orient: 'vertical',
                x: 'right',
                data: ['当日销售数据']
            },
            grid: {
                left: '3%',
                right: '4%',
                bottom: '3%',
                containLabel: true
            },
            xAxis: [
                {
                    type: 'category',
                    data: xData,
                    axisTick: {
                        alignWithLabel: true
                    }
                }
            ],
            yAxis: [
                {
                    type: 'value',
                    boundaryGap: true,
                    scale: true
                }
            ],
            series: [
                {
                    smooth: true,
                    symbol: 'none',
                    sampling: 'average',
                    name: '销售额',
                    type: 'bar',
                    data: data,
                    itemStyle: {
                        normal: {
                            color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                offset: 0,
                                color: '#CA3A37'
                            },
                            {
                                offset: 1,
                                color: '#CA3A37'

                            }
                            ]), label: { show: true, position: 'top' }
                        }
                    }
                }
            ]
        };
    }

}

function InitBarSaleChart() {
    var option_category = {
        title: {
            text: '销售数据（单位：元）',
            left: 'center',
            top: 1,
            textStyle: {
                fontSize: 12,
                fontFamily: "Microsoft YaHei",
            }
        },
        color: ['#b72f2f', 'yellow'],
        tooltip: {
            trigger: 'axis',
            axisPointer: {
                type: 'shadow'
            }
        },
        legend: {
            orient: 'vertical',
            x: 'right',
            data: ['上周', '本周']
        },
        grid: {
            left: '3%',
            right: '4%',
            bottom: '3%',
            containLabel: true
        },
        xAxis: [
            {
                type: 'category',
                data: ['周一', '周二', '周三', '周四', '周五', '周六', '周日'],
                axisTick: {
                    alignWithLabel: true
                }
            }
        ],
        yAxis: [
            {
                type: 'value',
                boundaryGap: true,
                scale: true
            }
        ],
        series: [
            {
                smooth: true,
                symbol: 'none',
                sampling: 'average',
                name: '上周',
                type: 'bar',
                data: SaleSummary.PreSaleSummary,
                itemStyle: {
                    normal: {
                        color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                            offset: 0,
                            color: '#CA3A37'
                        },
                        {
                            offset: 1,
                            color: '#CA3A37'

                        }
                        ]), label: { show: true, position: 'top' }
                    }
                }
            },
            {
                smooth: true,
                symbol: 'none',
                sampling: 'average',
                name: '本周',
                type: 'bar',
                data: SaleSummary.LastSaleSummary,
                itemStyle: {
                    normal: {
                        color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                            offset: 0,
                            color: '#6BAFBD'
                        },
                        {
                            offset: 1,
                            color: '#6BAFBD'
                        }
                        ]),label : {show: true, position: 'top'}
                    }
                }
            }
        ]
    };
    var myChart3 = echarts.init(document.getElementById('salarychart'));
    myChart3.setOption(option_category);
}

function SetPosPayTypeData() {
    var t0 = [], t1 = [];
    jQuery(PosPayTypeSummary).each(function (s, t) {
        t0.push(t.PayType);
        t1.push(t.GoodsAmount);
    });
    var options = {
        title: {
            text: '支付金额（单位：元）',
            left: 'center',
            top: 1,
            textStyle: {
                fontSize: 12,
                fontFamily: "Microsoft YaHei",
            }
        },
        color: ['#b72f2f'],
        tooltip: {
            trigger: 'axis',
            axisPointer: {
                type: 'shadow'
            }
        },
        grid: {
            left: '3%',
            right: '4%',
            bottom: '14%',
            containLabel: true
        },
        xAxis: [
            {
                type: 'category',
                data: t0,
                axisTick: {
                    alignWithLabel: true
                }
                , axisLabel: {
                    interval: 0,
                    rotate: 40
                }
            }
        ],
        yAxis: [
            {
                type: 'value',
                data: '支付金额（元）',
                axisTick: {
                    alignWithLabel: true
                }
            }
        ],
        series: [
            {
                smooth: true,
                symbol: 'none',
                sampling: 'average',
                name: '',
                type: 'bar',
                data: t1,
                itemStyle: {
                    normal: {
                        color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                            offset: 0,
                            color: '#CA3A37'
                        },
                        {
                            offset: 1,
                            color: '#6BAFBD'
                        }
                        ]), label: { show: true, position: 'top' }
                        ,shadowColor: 'rgba(0, 0, 0, 0.4)',
                    shadowBlur: 20
                    }
                }
            }
        ]
    };
    var paytypeChart = echarts.init(document.getElementById('paytypechart'));
    paytypeChart.setOption(options);
}