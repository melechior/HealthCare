'use strict';
var formAuthenticationPass = document.querySelector('#formAuthentication');
if (formAuthenticationPass) {
    var fvPass = FormValidation.formValidation(formAuthenticationPass, {
        fields: {
            'oldPassword': {
                validators: {
                    notEmpty: {
                        message: 'لطفا رمز کنونی را وارد نمایید'
                    },
                    stringLength: {
                        min: 3,
                        max: 30,
                        message: 'رمز باید بیشتر از 3 و کمتر از 30 حرف باشد',
                    },
                }
            },
            'newPassword': {
                validators: {
                    notEmpty: {
                        message: 'رمز عبور الزامی است'
                    },
                    stringLength: {
                        min: 8,
                        message: 'رمز عبور باید حداقل 8 کاراکتر داشته باشد'
                    },
                    regexp: {
                        regexp: /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/,
                        message: 'رمز عبور باید شامل حداقل یک حرف بزرگ، یک حرف کوچک، یک عدد و یک کاراکتر خاص باشد'
                    },
                    callback: {
                        message: 'رمز عبور نباید یک کلمه رایج باشد',
                        callback: function (input) {
                            // این تابع باید لیستی از کلمات رایج را بررسی کند و اگر رمز عبور در این لیست وجود داشت، false برگرداند.
                            // مثلاً:
                            const commonPasswords = ['password', '123456', 'qwerty'];
                            return !commonPasswords.includes(input.value);
                        }
                    }
                }
            },
            'confirmPassword': {
                validators: {
                    notEmpty: {
                        message: 'لطفا رمز عبور تاییدی را وارد کنید'
                    },
                    stringLength: {
                        min: 8,
                        message: 'رمز عبور باید حداقل 8 کاراکتر داشته باشد'
                    },
                    regexp: {
                        regexp: /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/,
                        message: 'رمز عبور باید شامل حداقل یک حرف بزرگ، یک حرف کوچک، یک عدد و یک کاراکتر خاص باشد'
                    },
                    // identical: {
                    //     compare: function() {
                    //         return $("#confirmPassword").val() === $("#newPassword").val();
                    //     },
                    //     message: 'رمزهای عبور یکسان نیستند'
                    // }
                }
            },
        },
        plugins: {
            trigger: new FormValidation.plugins.Trigger(),
            bootstrap5: new FormValidation.plugins.Bootstrap5(),
            autoFocus: new FormValidation.plugins.AutoFocus()
        },
        init: instance => {
            instance.on('plugins.message.placed', function (e) {
                if (e.element.parentElement.classList.contains('input-group')) {
                    e.element.parentElement.insertAdjacentElement('afterend', e.messageElement);
                }
            });
        }
    });
}

$("#btn-change-password").click(function () {
    fvPass.validate()
        .then(function (status) {
            if (status === "Valid") {
                $.ajax({
                    url: "/ChangePass/Change/",
                    type: "post",
                    data: {
                        "OldPassword": $("#oldPassword").val(),
                        "NewPassword": $("#newPassword").val(),
                        "confirmPassword": $("#confirmPassword").val(),
                    },
                    success: function (res) {
                        toastr.remove();
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
                                    window.location.reload();
                                }
                            );
                        }
                    },
                    error: function (xhr) {
                        toastr.error("خطای داخلی ، با واحد فنی تماس بگیرید");
                    }
                });
            }
        });
});