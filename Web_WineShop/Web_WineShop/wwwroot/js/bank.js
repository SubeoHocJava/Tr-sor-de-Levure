$(function () {
    var container = $('#bank-name')
    fetch('/api/BankApi/GetAll')
        .then(respone => respone.json())
        .then(data => {
            $(container).empty();
            for (var bank of data) {
                $(container).append(`<option value="${bank.id}">${bank.name}</option>`)
            }
        })
        .catch(error => console.log(error));
    $('.set-default-btn').on('click', function () {
        const accountId = $(this).data("id");
        const userId = $(this).data("target");
        $.ajax({
            url: "/Profile/SetDefaultBank",
            type: "Post",
            data: JSON.stringify({
                id: userId,
                idBank: accountId
            }),
            contentType: "application/json; charset=utf-8",
            success: function (respone) {
                if (respone.success)
                    $("#bank-list").load(`/Profile/BankAccount/${userId}`)
                else console.log("Không tim thấy user")
            },
            error: function (xhr, status, error) {
                console.error("Error:", status, error);
                console.error("xhr: ", xhr)
            }
        })
    })
    $("#add-bank-btn").on('click', function () {
        var formData = $("#add-bank-form").serialize();
        $('#loading-spinner').removeClass('d-none');
        $(".text-danger").text("");
        $.ajax({
            url: '/Profile/AddBankAccount',
            type: "POST",
            data: formData,
            success: function (response) {
                if (response.success) {
                    $('#notfound-err').addClass('d-none');
                    $('#bank-list').append(`<div class="d-flex justify-content-between align-items-center border p-3 mb-2">
					<div>
						<p><strong>Bank:</strong> ${response.data.bankName}</p>
						<p><strong>Account Number:</strong> ${response.data.accountNo}</p>
					</div>
					<div>
						<button class="btn text-light btn-sm set-default-btn" style="background-color:#be9650"
								data-id="${response.data.bankAccId}" data-target="${response.data.userId}">
							Set Default
						</button>
					</div>
				</div>`);
                }
                else {
                    if (response.errors) {
                        $.each(response.errors, function (key, errorMessages) {
                            var field = $('input[name="' + key + '"]');
                            var errorElement = field.siblings('.text-danger');
                            if (errorElement.length > 0) {
                                errorElement.text(errorMessages[0]);
                            }
                        })
                    }
                    else if (response.message) {
                        $('#notfound-err').text(response.message)
                        $('#notfound-err').removeClass('d-none');
                    }
                }
                $('#loading-spinner').addClass('d-none');
            },
            error: function (xhr, status, error) {
                console.log("Error: " + error);
                console.log("Status: " + status);
                console.log("Response: " + xhr.responseText);
            }
        })
    })
});
