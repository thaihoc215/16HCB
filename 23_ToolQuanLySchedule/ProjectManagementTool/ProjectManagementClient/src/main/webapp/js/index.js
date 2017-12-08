$('#btnUpdate').on('click', function () {
    alert("DB update");
});

$(document).ready(function () {

    var dataJson = [{ project_id: "AA001", project_name: "○○管理システム" },
    { project_id: "AB002", project_name: "□□検索システム" }]; 
    // $.ajax({
    //   type: 'GET',
    //   url: pjDataUrl,
    //   data: { get_param: 'value' },
    //   dataType: 'json',
    //   success: function (data) {
    //     console.log(data);
    //   }
    // });
    //call api get json data from database
    dataBefore = [
            ['XX.XX.XX.XX.XX', 'ＮＮＮＮＮＮＮＮ', 'ＮＮ', 'ＮＮ', 'ＮＮ', 'XXXX', 'XXXX', 'MM/DD', 'MM/DD', 'ＮＮＮＮ', 'XXXX',
                'MM/DD', 'MM/DD', 'XXXX', 'XXXX', 'ＮＮＮＮＮＮＮＮＮＮ'
            ],
            ['XX.XX.XX.XX.XX', 'ＮＮＮＮＮＮＮＮ', 'ＮＮ', 'ＮＮ', 'ＮＮ', 'XXXX', 'XXXX', 'MM/DD', 'MM/DD', 'ＮＮＮＮ', 'XXXX',
                'MM/DD', 'MM/DD', 'XXXX', 'XXXX', 'ＮＮＮＮＮＮＮＮＮＮ'
            ],
            ['XX.XX.XX.XX.XX', 'ＮＮＮＮＮＮＮＮ', 'ＮＮ', 'ＮＮ', 'ＮＮ', 'XXXX', 'XXXX', 'MM/DD', 'MM/DD', 'ＮＮＮＮ', 'XXXX',
                'MM/DD', 'MM/DD', 'XXXX', 'XXXX', 'ＮＮＮＮＮＮＮＮＮＮ'
            ],
            ['XX.XX.XX.XX.XX', 'ＮＮＮＮＮＮＮＮ', 'ＮＮ', 'ＮＮ', 'ＮＮ', 'XXXX', 'XXXX', 'MM/DD', 'MM/DD', 'ＮＮＮＮ', 'XXXX',
                'MM/DD', 'MM/DD', 'XXXX', 'XXXX', 'ＮＮＮＮＮＮＮＮＮＮ'
            ],
            ['XX.XX.XX.XX.XX', 'ＮＮＮＮＮＮＮＮ', 'ＮＮ', 'ＮＮ', 'ＮＮ', 'XXXX', 'XXXX', 'MM/DD', 'MM/DD', 'ＮＮＮＮ', 'XXXX',
                'MM/DD', 'MM/DD', 'XXXX', 'XXXX', 'ＮＮＮＮＮＮＮＮＮＮ'
            ],
            ['XX.XX.XX.XX.XX', 'ＮＮＮＮＮＮＮＮ', 'ＮＮ', 'ＮＮ', 'ＮＮ', 'XXXX', 'XXXX', 'MM/DD', 'MM/DD', 'ＮＮＮＮ', 'XXXX',
                'MM/DD', 'MM/DD', 'XXXX', 'XXXX', 'ＮＮＮＮＮＮＮＮＮＮ'
            ],
            ['XX.XX.XX.XX.XX', 'ＮＮＮＮＮＮＮＮ', 'ＮＮ', 'ＮＮ', 'ＮＮ', 'XXXX', 'XXXX', 'MM/DD', 'MM/DD', 'ＮＮＮＮ', 'XXXX',
                'MM/DD', 'MM/DD', 'XXXX', 'XXXX', 'ＮＮＮＮＮＮＮＮＮＮ'
            ],
            ['XX.XX.XX.XX.XX', 'ＮＮＮＮＮＮＮＮ', 'ＮＮ', 'ＮＮ', 'ＮＮ', 'XXXX', 'XXXX', 'MM/DD', 'MM/DD', 'ＮＮＮＮ', 'XXXX',
                'MM/DD', 'MM/DD', 'XXXX', 'XXXX', 'ＮＮＮＮＮＮＮＮＮＮ'
            ],
        ],
        //get hansontable DOM
        container = document.getElementById('example'),
        hot;

        var tmp = [];
    //create Hansontable
    hot = new Handsontable(container, {
        data: data,
        colHeaders: [
            '作業番号',
            '作業内容',
            '区分',
            '分類',
            '担当',
            '計画工数',
            '出来高',
            '開始日',
            '終了日',
            '進捗率',
            '出来高',
            '開始日',
            '終了日',
            '実績工数',
            '累積工数',
            '備考'
        ],
        contextMenu: true,
        manualColumnResize: true,
        manualRowResize: true,
        stretchH: 'all'
    });


    function bindDumpButton() {

        Handsontable.Dom.addEvent(document.body, 'click', function (e) {
            alert("hansontable dumb");
            var element = e.target || e.srcElement;

            if (element.nodeName == "BUTTON" && element.name == 'dump') {
                var name = element.getAttribute('data-dump');
                var instance = element.getAttribute('data-instance');
                var hot = window[instance];
                console.log('data of ' + name, hot.getData());
            }
        });
    }
    bindDumpButton();

});