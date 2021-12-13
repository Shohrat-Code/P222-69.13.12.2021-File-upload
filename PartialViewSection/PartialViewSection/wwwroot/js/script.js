$(document).ready(function () {

    $('.selectTwo').select2();

    ClassicEditor
        .create(document.querySelector('#editor'))
        .catch(error => {
            console.error(error);
        });

});