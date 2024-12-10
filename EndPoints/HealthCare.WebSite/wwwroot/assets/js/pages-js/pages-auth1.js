'use strict';
const formAuthentication = document.querySelector('#formAuthentication');
const lockForm = $("#login_form_layout");
//const lockForm= $("#btnLogin");
document.addEventListener('DOMContentLoaded', function (e) {
    (function () {
        // Form validation for Add new record
        if (formAuthentication) {
            const fv = FormValidation.formValidation(formAuthentication, {
                fields: {
                    username: {
                        validators: {
                            notEmpty: {
                                message: 'لطفا نام کاربری را وارد کنید'
                            },
                            stringLength: {
                                min: 5,
                                message: 'نام کاربری باید بیشتر از 5 کارکتر باشد'
                            }
                        }
                    },
                    email: {
                        validators: {
                            notEmpty: {
                                message: 'ایمیل را وارد کنید'
                            },
                            emailAddress: {
                                message: 'فرمت ایمیل صحیح نیست'
                            }
                        }
                    },
                    'NatinalId-username': {
                        validators: {
                            notEmpty: {
                                message: ' نام کاربری / کدملی را وارد کنید'
                            },
                            stringLength: {
                                min: 5,
                                message: 'نام کاربری باید بیشتر از 5 کارکتر باشد'
                            }
                        }
                    },
                    password: {
                        validators: {
                            notEmpty: {
                                message: 'رمز ورود را وارد کنید'
                            },
                            stringLength: {
                                min: 4,
                                message: 'رمز ورود باید بیشتر از 4 کارکتر باشد'
                            }
                        }
                    },
                    'confirm-password': {
                        validators: {
                            notEmpty: {
                                message: 'تایید رمز را وارد کنید'
                            },
                            identical: {
                                compare: function () {
                                    return formAuthentication.querySelector('[name="password"]').value;
                                },
                                message: 'رمز و تاییدش یکسان نیستند'
                            },
                            stringLength: {
                                min: 6,
                                message: 'رمز ورود باید بیشتر از 6 کارکتر باشد'
                            }
                        }
                    },
                    terms: {
                        validators: {
                            notEmpty: {
                                message: 'لطفا قوانین را بپذیرید'
                            }
                        }
                    }
                },
                plugins: {
                    trigger: new FormValidation.plugins.Trigger(),
                    bootstrap5: new FormValidation.plugins.Bootstrap5({
                        eleValidClass: '',
                        rowSelector: '.mb-3'
                    }),
                    submitButton: new FormValidation.plugins.SubmitButton(),

                    defaultSubmit: new FormValidation.plugins.DefaultSubmit(),
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

            const loginButton = document.getElementById('btnLogin');
            loginButton.addEventListener('click', function () {
                fv.validate().then(function (status) {
                    if ($(".is-invalid").length === 0) {
                        lockForm.block({
                            onUnblock: function () {
                                $("#password").val("").focus();
                            },
                            message:
                                '<div class="d-flex justify-content-center"><p class="mb-0">لطفا منتظر بمانید...</p> <div class="sk-wave m-0"><div class="sk-rect sk-wave-rect"></div> <div class="sk-rect sk-wave-rect"></div> <div class="sk-rect sk-wave-rect"></div> <div class="sk-rect sk-wave-rect"></div> <div class="sk-rect sk-wave-rect"></div></div> </div>',
                            //timeout: 10000,
                            css: {
                                backgroundColor: 'transparent',
                                color: '#fff',
                                border: '0'
                            },
                            overlayCSS: {
                                opacity: 0.5
                            }
                        });
                        $.ajax({
                            url: "/Login/EnterLogin/",
                            //dataType: "json",
                            data: {
                                username: $("#NatinalId-username").val(),
                                password: $("#password").val()
                            },
                            type: "POST",
                            success: function (res) {
                                lockForm.unblock();
                                if (res.failed) {
                                    toast(res.resultMessages);
                                } else {
                                    window.location.href = "/Details";
                                }
                            },
                            error: function (xhr) {
                                lockForm.unblock();
                                toastr.error("خطای داخلی ، با واحد فنی تماس بگیرید", 'خطا');
                            }
                        });
                    }
                });
            });
        }

        //  Two Steps Verification
        const numeralMask = document.querySelectorAll('.numeral-mask');

        // Verification masking
        if (numeralMask.length) {
            numeralMask.forEach(e => {
                new Cleave(e, {
                    numeral: true
                });
            });
        }
    })();
});
