$(function () {
    var container = $('#bank-name')
    fetch('/api/Banks')
        .then(respone => respone.json())
        .then(data => {
            $(container).empty();
            $(container).append('<option value="" disabled selected>Select your bank</option>');
            for (var bank of data) {
                $(container).append(`<option value="${bank.Name}" data-id="${bank.Id}">${bank.Name}</option>`)
            }
        })
});
