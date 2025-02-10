var lockForm = $("#blockUiForm");
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
            }
        ],
        order: [[2, 'desc']],
        dom: '<"card-header flex-column flex-md-row"<"head-label text-center"><"dt-action-buttons text-end pt-3 pt-md-0"B>><"row"<"col-sm-12 col-md-6"l><"col-sm-12 col-md-6 d-flex justify-content-center justify-content-md-end"f>>t<"row"<"col-sm-12 col-md-6"i><"col-sm-12 col-md-6"p>>',
        displayLength: 10,
        lengthMenu: [10, 25, 50, 75, 100],
        buttons: [
            {
                text: '<i class="ti ti-printer me-md-1"></i><span class="d-md-inline-block d-none">چاپ گزارش</span>',
                className: 'btn btn-primary waves-effect waves-light',
                action: function (e, dt, button, config) {
                    lockForm.block({
                        message: '<div class="spinner-border text-white" role="status"></div>',
                        timeout: 1000,
                        css: {
                            backgroundColor: 'transparent',
                            border: '0'
                        },
                        overlayCSS: {
                            opacity: 0.5
                        }
                    });
                    
                    $.ajax({
                        url: "/Details/Print/",
                        type: "POST",
                        success: function (res) {
                            lockForm.unblock();
                            if (res.failed) {
                                toast(res.resultMessages);
                            } else {
                                Swal.fire({
                                    icon: 'success',
                                    title: 'ذخیره شد!',
                                    text: 'ردیف مورد نظر شما با موفقیت ذخیره شد.',
                                    confirmButtonText: 'باشه',
                                    customClass: {
                                        confirmButton: 'btn btn-success waves-effect waves-light'
                                    }
                                }).then(
                                    function () {
                                        lockForm.unblock();
                                        let a = document.createElement("a"); //Create <a>
                                        a.href = "data:application/pdf;base64," + res.fileSource; //Image Base64 Goes here
                                        a.download = res.fileName; //File name Here
                                        a.click();
                                    }
                                );
                            }
                        },
                        error: function (xhr) {
                            lockForm.unblock();
                            toastr.error("خطای داخلی ، با واحد فنی تماس بگیرید", 'خطا');
                        }
                    });
                }
            }
        ],
        destroy: true,
        responsive: {
            details: {
                display: $.fn.dataTable.Responsive.display.modal({
                    header: function (row) {
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