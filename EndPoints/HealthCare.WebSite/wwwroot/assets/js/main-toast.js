function toast(resultMessages) {
    let toastrObj={
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }

    resultMessages.forEach((resultMessage)=>{
        if (resultMessage.messageType == -1) {
            toastr.error(resultMessage.message, "خطا", toastrObj);
        }
        else if (resultMessage.messageType == 0) {
            toastr.success(resultMessage.message, "موفق", toastrObj);
        }
        else if (resultMessage.messageType == 1) {
            toastr.error(resultMessage.message, "اخطار", toastrObj);
        }
        else if (resultMessage.messageType == 2) {
            toastr.error(resultMessage.message, "اطلاعیه", toastrObj);
        }
        else if(resultMessage.messageType==3){
            let a = document.createElement("a"); //Create <a>
            a.href = 'data:application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;base64,'+resultMessage.message; //Image Base64 Goes here
            a.download = "Report.xlsx"; //File name Here
            a.click();
        }
    });
}