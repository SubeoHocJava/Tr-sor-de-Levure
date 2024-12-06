document.addEventListener("DOMContentLoaded", function () {
    // Validation rules
    const validationRules = {
        friend_name: {
            required: true,
            required_err_msg: "Name required",
            rules: [{
                rule: "length",
                min: 1,
                max: 255,
                err_msg: "Length must be between 1 and 255 characters"
            }]
        },
        friend_email: {
            required: true,
            required_err_msg: "Email required",
            rules: [{
                rule: "email",
                err_msg: "Please enter a valid email address"
            }]
        },
        your_name: {
            required: true,
            required_err_msg: "Your name is required",
            rules: [{
                rule: "length",
                min: 1,
                max: 255,
                err_msg: "Length must be between 1 and 255 characters"
            }]
        },
        your_email: {
            required: true,
            required_err_msg: "Your email is required",
            rules: [{
                rule: "email",
                err_msg: "Please enter a valid email address"
            }]
        },
        g_recaptcha_response: {
            required: true,
            required_err_msg: "Please complete the reCAPTCHA"
        }
    };

    const form = document.getElementById("wishlist_friend_form");

    // Add real-time validation
    Object.keys(validationRules).forEach((fieldName) => {
        const inputField = form.querySelector(`[name="${fieldName}"]`);
        if (inputField) {
            inputField.addEventListener("input", function () {
                validateField(inputField, validationRules[fieldName]);
            });
        }
    });

    form.addEventListener("submit", function (e) {
        e.preventDefault();
        const errors = validateForm(form, validationRules);

        // Clear previous errors
        clearErrors(form);

        if (Object.keys(errors).length === 0) {
            form.submit();
        } else {
            showErrors(errors, form);
        }
    });
});

// Validate a single field
function validateField(input, rules) {
    const errorElement = input.nextElementSibling;
    const errors = [];

    if (rules.required && !input.value.trim()) {
        errors.push(rules.required_err_msg);
    }

    if (rules.rules) {
        rules.rules.forEach((rule) => {
            if (rule.rule === "length") {
                const length = input.value.trim().length;
                if (length < rule.min || length > rule.max) {
                    errors.push(rule.err_msg);
                }
            } else if (rule.rule === "email") {
                if (!validateEmail(input.value)) {
                    errors.push(rule.err_msg);
                }
            }
        });
    }

    if (errors.length > 0) {
        errorElement.textContent = errors[0];
        errorElement.style.display = "block";
    } else {
        errorElement.style.display = "none";
    }
}

// Validate the entire form
function validateForm(form, rules) {
    const errors = {};

    for (const [field, settings] of Object.entries(rules)) {
        const input = form.querySelector(`[name="${field}"]`);
        if (!input) continue;

        const fieldErrors = [];
        if (settings.required && !input.value.trim()) {
            fieldErrors.push(settings.required_err_msg);
        }

        if (settings.rules) {
            for (const rule of settings.rules) {
                if (rule.rule === "length") {
                    const length = input.value.trim().length;
                    if (length < rule.min || length > rule.max) {
                        fieldErrors.push(rule.err_msg);
                    }
                } else if (rule.rule === "email") {
                    if (!validateEmail(input.value)) {
                        fieldErrors.push(rule.err_msg);
                    }
                }
            }
        }

        if (fieldErrors.length > 0) {
            errors[field] = fieldErrors[0];
        }
    }

    return errors;
}

// Helper to clear errors
function clearErrors(form) {
    const errorElements = form.querySelectorAll(".checkout-select-message--error");
    errorElements.forEach((errorElement) => {
        errorElement.style.display = "none";
    });
}

// Helper to show errors
function showErrors(errors, form) {
    for (const [field, message] of Object.entries(errors)) {
        const input = form.querySelector(`[name="${field}"]`);
        if (input) {
            const errorElement = input.nextElementSibling;
            errorElement.textContent = message;
            errorElement.style.display = "block";
        }
    }
}

// Email validation helper
function validateEmail(email) {
    const regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return regex.test(email);
}
