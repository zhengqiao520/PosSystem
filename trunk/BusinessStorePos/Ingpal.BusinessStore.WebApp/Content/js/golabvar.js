var PosGlobal = {
    PayType: {
        "0": '微信',
        "1": "支付宝",
        "2": '银行卡',
        "3": '商场代收',
        "4": '现金'
    },
    formatDate(date) {
        var d = new Date(date),
         month = '' + (d.getMonth() + 1),
          day = '' + d.getDate(),
         year = d.getFullYear();
 
          if (month.length < 2) month = '0' + month;
          if (day.length < 2) day = '0' + day;
 
        return [year, month, day].join('-');
    }
}