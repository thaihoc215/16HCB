$(document).ready(function () {
    /**
     * server router get schedule
     */
    var pjDataUrl = "http://192.168.10.143:8080/ProjectManagementServer/ws/schedules?projectId=AA001",
        divisonDataUrl = "http://192.168.10.143:8080/ProjectManagementServer/ws/divisions?divisionKindCode=01",
        personDataUrl = "http://192.168.10.143:8080/ProjectManagementServer/ws/persons";
    /**
     * server router update records
     */
    var updateDataPjUrl = "http://192.168.10.143:8080/ProjectManagementServer/ws/save";

    var lstUpdate = {
        "status": 0,
        "record": []
    },
        lstInsert = {
            "status": 1,
            "record": []
        },
        lstDelete = {
            "status": 2,
            "record": []
        };

    /** 
     * Handsontable data
     */

    var dataTableTmp = [
        {
            "work_number": "",
            "work_content": "",
            "kbn": "", //division name
            "classification": "",
            "person_id": "",
            "planning_man_hours": "",
            "planning_volume": "",
            "planning_start_date": "",
            "planning_end_date": "",
            "progress_rate": "",
            "actual_volumn": "",
            "actual_start_date": "",
            "actual_end_date": "",
            "actual_man_hours": "",
            "cumulative_man_hours": "",
            "remarks": ""
        },
        {
            "work_number": "",
            "work_content": "",
            "kbn": "", //division name
            "classification": "",
            "person_id": "",
            "planning_man_hours": "",
            "planning_volume": "",
            "planning_start_date": "",
            "planning_end_date": "",
            "progress_rate": "",
            "actual_volumn": "",
            "actual_start_date": "",
            "actual_end_date": "",
            "actual_man_hours": "",
            "cumulative_man_hours": "",
            "remarks": ""
        },
        {
            "work_number": "",
            "work_content": "",
            "kbn": "", //division name
            "classification": "",
            "person_id": "",
            "planning_man_hours": "",
            "planning_volume": "",
            "planning_start_date": "",
            "planning_end_date": "",
            "progress_rate": "",
            "actual_volumn": "",
            "actual_start_date": "",
            "actual_end_date": "",
            "actual_man_hours": "",
            "cumulative_man_hours": "",
            "remarks": ""
        }
    ];
    var dataTable = [
        {
            "work_number": "",
            "work_content": "",
            "kbn": "", //division name
            "classification": "",
            "person_id": "",
            "planning_man_hours": "",
            "planning_volume": "",
            "planning_start_date": "",
            "planning_end_date": "",
            "progress_rate": "",
            "actual_volumn": "",
            "actual_start_date": "",
            "actual_end_date": "",
            "actual_man_hours": "",
            "cumulative_man_hours": "",
            "remarks": ""
        }
    ];
    var dataDivisions = [];
    var dataPersons = [];

    /**
     * Handsontable data before update
     */
    var dataBefore = JSON.parse(JSON.stringify(dataTable));
    //Setting up value got from server to handsontable
    {
        // $.ajax({
        //     type: 'GET',
        //     url: pjDataUrl,
        //     data: { get_param: 'value' },
        //     dataType: 'json',
        //     success: function (data) {
        //         dataTable = data; 
        //         dataBefore = JSON.parse(JSON.stringify(dataTable));
        //         hot.loadData(JSON.parse(JSON.stringify(dataTable)));
        //     }
        // });
    }

    //Call api get project data 
    { 
        function getDataServer() {
            return new Promise((resolve, reject) => {
                $.getJSON(pjDataUrl, (pjData) => {
                    console.log(pjData);
                    if (pjData != null) {
                        dataTable = pjData;
                        dataBefore = JSON.parse(JSON.stringify(dataTable));
                        resolve(dataTable);
                    }
                    else {
                        resolve(null);
                    }
                })
            });
        };

        getDataServer().then(rs1 => {
            return $.getJSON(divisonDataUrl, (divData) => {
                console.log(divData);
                if (divData != null) {
                    dataDivisions = divData;
                    return divData;
                }
                else {
                    return null;
                }
            });
        }).then(rs2 => {
            return $.getJSON(personDataUrl, (persData) => {
                console.log(persData);
                if (persData != null) {
                    dataPersons = persData;
                    return persData;
                }
                else {
                    return null;
                }
            });
        }).then(rs=>{
            hot = new Handsontable(container, {
                data: dataTable,
                // data: JSON.parse(JSON.stringify(data)),
                colHeaders: [
                    '作業番号', '作業内容', '区分', '分類',
                    '担当', '計画工数', '出来高', '開始日',
                    '終了日', '進捗率', '出来高', '開始日',
                    '終了日', '実績工数', '累積工数', '備考'
                ],
                columnSorting: true,
                contextMenu: true,
                manualColumnResize: true,
                manualRowResize: true,
                stretchH: 'all',
                cells : function (row, column) {
                    var cellMeta = {};

                    // if (row >= rowsCount) {
                    //     return cellMeta;
                    // }
 
                    if (column === 2) {
                        cellMeta.type = 'dropdown';
                        cellMeta.source = dataDivisions; 
 
                    } 
                    if (column === 4) {
                        cellMeta.type = 'dropdown';
                        cellMeta.source = dataPersons;

                    } 

                    return cellMeta;
                },
                afterChange: function (changes, src) {
                    if (src !== 'loadData') {
                        let rowChangeIdx = changes[0][0];
                        let oldValue = changes[0][2];
                        let newValue = changes[0][3];
                        if (oldValue != newValue) {

                            let rowChange = hot.getSourceDataAtRow(rowChangeIdx);
                            console.log(rowChange);
                            if (!checkNullOrEmpty(rowChange))
                                return;

                            if (dataBefore.length < hot.getData().length) {
                                console.log("insert");
                                lstInsert.record.push(rowChange);
                            } else if (dataBefore.length > hot.getData().length) {
                                console.log("delete")
                            } else {
                                // lstUpdate.push(
                                //   {
                                //     "status": 0, //update
                                //     "row": setRowRecord(rowChange)
                                //   });
                                lstUpdate.record.push(setRowRecord(rowChange));
                                console.log("update");
                            }
                            //clone data after send to server
                            dataBefore = JSON.parse(JSON.stringify(hot.getData()));
                        }
                    }
                },
                beforeRemoveRow: function (idx, amount) {
                    console.log('beforeRemove: index: %d, amount: %d', idx, amount);
                    let rowDelete = hot.getSourceDataAtRow(idx);
                    console.log(rowDelete);
                    lstDelete.record.push(rowDelete);
                    console.log("delete");
                }
            });
        });
    }  



    var container = document.getElementById('example');
    var hot;
    {
        // hot = new Handsontable(container, {
        //     data: dataTable,
        //     // data: JSON.parse(JSON.stringify(data)),
        //     colHeaders: [
        //         '作業番号', '作業内容', '区分', '分類',
        //         '担当', '計画工数', '出来高', '開始日',
        //         '終了日', '進捗率', '出来高', '開始日',
        //         '終了日', '実績工数', '累積工数', '備考'
        //     ],
        //     columnSorting: true,
        //     contextMenu: true,
        //     manualColumnResize: true,
        //     manualRowResize: true,
        //     stretchH: 'all',
        //     cells: function (row, column) {
        //         var cellMeta = {};
    
        //         // if (row >= rowsCount) {
        //         //     return cellMeta;
        //         // }
    
        //         if (column === 2) {
        //             cellMeta.type = 'dropdown';
        //             cellMeta.source = [
        //                 'Ben',
        //                 'Chris',
        //                 'Jessica'
        //             ];
    
        //         }
        //         if (column === 4) {
        //             cellMeta.type = 'dropdown';
        //             cellMeta.source = [
        //                 'Ben',
        //                 'Chris',
        //                 'Jessica'
        //             ];
    
        //         }
    
        //         return cellMeta;
        //     },
        //     afterChange: function (changes, src) {
        //         if (src !== 'loadData') {
        //             let rowChangeIdx = changes[0][0];
        //             let oldValue = changes[0][2];
        //             let newValue = changes[0][3];
        //             if (oldValue != newValue) {
    
        //                 let rowChange = hot.getSourceDataAtRow(rowChangeIdx);
        //                 console.log(rowChange);
        //                 if (!checkNullOrEmpty(rowChange))
        //                     return;
    
        //                 if (dataBefore.length < hot.getData().length) {
        //                     console.log("insert");
        //                     lstInsert.record.push(rowChange);
        //                 } else if (dataBefore.length > hot.getData().length) {
        //                     console.log("delete")
        //                 } else {
        //                     // lstUpdate.push(
        //                     //   {
        //                     //     "status": 0, //update
        //                     //     "row": setRowRecord(rowChange)
        //                     //   });
        //                     lstUpdate.record.push(setRowRecord(rowChange));
        //                     console.log("update");
        //                 }
        //                 //clone data after send to server
        //                 dataBefore = JSON.parse(JSON.stringify(hot.getData()));
        //             }
        //         }
        //     },
        //     beforeRemoveRow: function (idx, amount) {
        //         console.log('beforeRemove: index: %d, amount: %d', idx, amount);
        //         let rowDelete = hot.getSourceDataAtRow(idx);
        //         console.log(rowDelete);
        //         lstDelete.record.push(rowDelete);
        //         console.log("delete");
        //     }
        // });
    }
    

    /**
     * Check field not null before process
     * @param {object} rowData 
     */
    function checkNullOrEmpty(rowData) {
        if (rowData[0] && rowData[1] && rowData[2] && rowData[4])
            return true;
        return false;
    };

    /**
     * Set and parse JSon data of row to schedule record
     * @param {object} rowChange 
     */
    function setRowRecord(rowChange) {
        return JSON.parse(JSON.stringify({
            "work_number": rowChange[0],
            "work_content": rowChange[1],
            "kbn": rowChange[2], //division name
            "classification": rowChange[3],
            "person_id": rowChange[4],
            "planning_man_hours": rowChange[5],
            "planning_volume": rowChange[6],
            "planning_start_date": rowChange[7],
            "planning_end_date": rowChange[8],
            "progress_rate": rowChange[9],
            "actual_volumn": rowChange[10],
            "actual_start_date": rowChange[11],
            "actual_end_date": rowChange[12],
            "actual_man_hours": rowChange[13],
            "cumulative_man_hours": rowChange[14],
            "remarks": rowChange[15]
        }))
    }

    function bindDumpButton() {
        Handsontable.dom.addEvent(document.body, 'click', function (e) {
            var element = e.target || e.srcElement;
            if (element.nodeName == "BUTTON" && element.name == 'dump') {
                var name = element.getAttribute('data-dump');
                var instance = element.getAttribute('data-instance');
                var hot = window[instance];
                console.log('data of ' + name, hot.getData());
            }
        });
    };
    bindDumpButton();


    $('#btnUpdate').on('click', function () {
        /*$.get(restUrl, function (apiData) {
            var dt = apiData;
            // alert("total user " + apiData.items[0].total_users);
            console.log(apiData.items[0]);
        });*/
        //Call rest api update data
        dataAfter = hot.getData();
        var rsCompare = JSON.stringify(dataAfter) == JSON.stringify(dataBefore);
        console.log(JSON.parse(JSON.stringify(hot.getData())));

        //console.log(JSON.parse(lstUpdate, lstInsert, lstDelete));
        console.log(JSON.parse(JSON.stringify(lstUpdate)));
        lstUpdate.record = [];
        lstInsert.record = [];
        lstDelete.record = [];
    });
});

// var dataTable = [ 
    //   ['11.11', 'AAAAAA', 'AA', 'AA', 'AA', '1234', '1234', '12/12', '12/12', 'AAAA', '1234',
    //     '12/12', '12/12', '1234', '1234', 'AAAA'
    //   ],
    //   ['11.11', 'AAAAAA', 'AA', 'AA', 'AA', '1234', '1234', '12/12', '12/12', 'AAAA', '1234',
    //     '12/12', '12/12', '1234', '1234', 'AAAA'
    //   ], ['11.11', 'AAAAAA', 'AA', 'AA', 'AA', '1234', '1234', '12/12', '12/12', 'AAAA', '1234',
    //     '12/12', '12/12', '1234', '1234', 'AAAA'
    //   ], ['11.11', 'AAAAAA', 'AA', 'AA', 'AA', '1234', '1234', '12/12', '12/12', 'AAAA', '1234',
    //     '12/12', '12/12', '1234', '1234', 'AAAA'
    //   ], ['11.11', 'AAAAAA', 'AA', 'AA', 'AA', '1234', '1234', '12/12', '12/12', 'AAAA', '1234',
    //     '12/12', '12/12', '1234', '1234', 'AAAA'
    //   ], ['11.11', 'AAAAAA', 'AA', 'AA', 'AA', '1234', '1234', '12/12', '12/12', 'AAAA', '1234',
    //     '12/12', '12/12', '1234', '1234', 'AAAA'
    //   ], ['11.11', 'AAAAAA', 'AA', 'AA', 'AA', '1234', '1234', '12/12', '12/12', 'AAAA', '1234',
    //     '12/12', '12/12', '1234', '1234', 'AAAA'
    //   ],
    // ];