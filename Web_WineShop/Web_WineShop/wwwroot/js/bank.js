$(function () {
    var container = $('#bank-name')
    fetch('/api/Bank')
        .then(respone => respone.json())
        .then(data => {
            console.log(data);
            $(container).empty();
            $(container).append('<option value="" disabled selected>Select your bank</option>');
            for (var bank of data) {
                $(container).append(`<option value="${bank.name}" data-id="${bank.id}">${bank.name}</option>`)
            }
        })
});
