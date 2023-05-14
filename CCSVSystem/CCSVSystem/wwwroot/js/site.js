// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    console.log("Entro");
    var PlaceHolderElement = $('#ContenedorModal');
    $('button[data-toggle="ajax-modal"]').click(function (event) {
        var url = $(this).data('url');
        console.log(url);
        var decodedurl = decodeURIComponent;
        console.log(decodedurl);
        $.get(url).done(function (data) {
            console.log("llego 1");
            PlaceHolderElement.html(data);
            PlaceHolderElement.find('.modal').modal('show');
        })
    })

    PlaceHolderElement.on('click', '[data-save="modal"]', function (event) {
        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr('action');
        var index = $(this).data('index');
        var disabled = form.find(':input:disabled').removeAttr('disabled');
        var sendData = form.serialize();
        disabled.attr('disabled', 'disabled');

        $.post(actionUrl, sendData).done(function (data) {

            var newBody = $('.modal-body', data);
            PlaceHolderElement.find('.modal-body').replaceWith(newBody);

            console.log(data);
            var isValid = data.success;
            console.log(isValid);
            
           if (isValid) {
               PlaceHolderElement.find('.modal').modal('hide');
               Swal.fire({
                   icon: 'success',
                   title: '¡Guardado con éxito!',
                   showConfirmButton: false,
                   timer: 1500
               }).then((result) => {
                   top.location.href = index;
               })                                                          
            };
           

        })
    })
})


