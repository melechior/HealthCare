$(document).ready(function () {
    $('#damage_file_id').DataTable({
        ajax: {
            type: "POST",
            url: "/Details/PersonageList",
            complete: function (response) {
            }
        },
        serverSide: true,
        columns: [
            {data: ''},
            {data: 'contractNumber'},
            {data: 'fullname'},
            {data: 'receiptNumber'},
            {data: 'damageItemName'},
            {data: 'persianDamageDate'},
            {data: 'requestedAmount', render: $.fn.dataTable.render.number(',', '.', 0, '')},
            {data: 'damageFileStateName'},
            {data: ''}
        ],
        columnDefs: [
            {
                className: 'control',
                orderable: false,
                targets: 0,
                searchable: false,
                render: function (data, type, full, meta) {
                    return '';
                }
            },
            {
                targets: 1,
                searchable: true,
                visible: true
            },
            {
                responsivePriority: 1,
                targets: 1
            },
            {
                // Actions
                targets: -1,
                title: 'عملیات',
                orderable: false,
                searchable: false,
                render: function (data, type, full, meta) {
                    let buttons = "";
                    // '<a href="javascript:ViewDamageFileDetailFiles(' + full["id"] + ');" class="btn btn-sm btn-icon item-edit" data-bs-toggle="tooltip" title="مشاهده اسناد"><i class="text-primary ti ti-eye"></i></a>' +
                    // '<a href="javascript:ViewCommentDamageFileDetailFiles(' + full["id"] + ')" class="btn btn-sm btn-icon item-edit" data-bs-toggle="tooltip" title="مشاهده گردش"><i class="text-primary ti ti-timeline"></i></a>' +
                    // '<a href="javascript:NotificationDamageFileDetail(' + full["id"] + ')" class="btn btn-sm btn-icon item-edit" data-bs-toggle="tooltip" title="ثبت توضیحات"><i class="text-primary ti ti-notification"></i></a>';
                    if (full['damageFileState'] === 10) {
                        buttons += '<a href="javascript:show_payment(' + full["id"] + ')" class="btn btn-sm btn-icon item-edit" data-bs-toggle="tooltip" title="مشاهده پرداخت"><i class="text-primary ti ti-report-money"></i></a>';
                    }
                    // else {
                    //     buttons += '<a href="javascript:goToDefect(' + full["id"] + ')" class="btn btn-sm btn-icon item-edit" data-bs-toggle="tooltip" title="ثبت نقص پرونده"><i class="text-primary ti ti-certificate-2-off"></i></a>' +
                    //         '<a href="javascript:goToReject(' + full["id"] + ')" class="btn btn-sm btn-icon item-edit" data-bs-toggle="tooltip" title="ثبت مردودی پرونده"><i class="text-primary ti ti-ban"></i></a>';
                    // }
                    return buttons;
                }
            }
        ],
        order: [[2, 'desc']],
        //dom: '<"card-header flex-column flex-md-row"<"head-label text-center"><"dt-action-buttons text-end pt-3 pt-md-0"B>><"row"<"col-sm-12 col-md-6"l><"col-sm-12 col-md-6 d-flex justify-content-center justify-content-md-end"f>>t<"row"<"col-sm-12 col-md-6"i><"col-sm-12 col-md-6"p>>',
        displayLength: 10,
        lengthMenu: [10, 25, 50, 75, 100],
        buttons: [
            // {
            //     text: '<i class="ti ti-plus me-sm-1"></i> <span class="d-none d-sm-inline-block">افزودن قرارداد</span>',
            //     className: 'create-new btn btn-primary waves-effect waves-light',
            // }
        ],
        destroy: true,
        dom: '<"row"<"col-sm-12 col-md-6"l><"col-sm-12 col-md-6 d-flex justify-content-center justify-content-md-end"f>>t<"row"<"col-sm-12 col-md-6"i><"col-sm-12 col-md-6"p>>',
        responsive: {
            details: {
                display: $.fn.dataTable.Responsive.display.modal({
                    header: function (row) {
                        debugger
                        var data = row.data();
                        return 'جزئیات ' + data['contractNumber'];
                    }
                }),
                type: 'column',
                renderer: function (api, rowIdx, columns) {
                    var data = $.map(columns, function (col, i) {
                        return col.title !== '' // ? Do not show row in modal popup if title is blank (for check box)
                            ? '<tr data-dt-row="' +
                            col.rowIndex +
                            '" data-dt-column="' +
                            col.columnIndex +
                            '">' +
                            '<td>' +
                            col.title +
                            ':' +
                            '</td> ' +
                            '<td>' +
                            col.data +
                            '</td>' +
                            '</tr>'
                            : '';
                    }).join('');
                    debugger
                    return data ? $('<table class="table"/><tbody />').append(data) : false;
                }
            }
        }
    });
});