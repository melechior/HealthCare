$(".customerItem").click(function () {
    $.ajax({
        url: "/Login/ChangeSelectedPersonId/"+$(this).attr("personalId"),
        type: "post",
        //dataType: "json",
        //data: JSON.stringify(sendData),
        //data: sendData,
        success: function (res) {
            debugger
            //toastr.remove();
            if (res.failed) {
                toast(res.resultMessages);
            } else {
                window.location.reload();
            }
        },
        error: function (xhr) {
            toastr.error("خطای داخلی ، با واحد فنی تماس بگیرید");
        }
    });
});

