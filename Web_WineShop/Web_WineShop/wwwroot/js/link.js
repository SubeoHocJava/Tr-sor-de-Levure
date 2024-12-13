/**
 * Link 
 */
document.getElementsByClassName('link')
Array.from(document.getElementsByClassName('link')).forEach(function (element) {
    element.addEventListener('click', function () {
        event.preventDefault();
        window.location.href = element.getAttribute('data-href');
    });
});


