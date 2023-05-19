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
});

function NotClosed(id) {
    var fila = document.getElementById(id);
    fila.classList.remove("collapse");
    fila.classList.add("show");
}

function showHiddenElement(flag, id) {   
    var element = document.getElementById(id);
    if (flag) {
        element.classList.remove("visually-hidden");
    }
    else {
        element.classList.add("visually-hidden");
    }
}

function setDefaultDate(flag, id) {
    var dateDefault = new Date("2000-01-01");
    var element = document.getElementById(id);
    if (flag) {
        element.valueAsDate = null;
    }
    else {
        element.valueAsDate = dateDefault;
    }
}

function calculoPrecioUnidad() {
    var stock = document.getElementById("stock").value;
    var total = document.getElementById("total").value;
    var preciounidad = document.getElementById("preciounidad");
    console.log("se ejecuta" + stock + " " + total);

    if (!isNaN(stock) && !isNaN(total) && stock !=0 && total != 0) {
        console.log("entro true");
        preciounidad.value = (total / stock).toFixed(2);
    }
    else {
        console.log("entro false");
        preciounidad.value = 0.00;
    }
}

function desbloquearPU() {
    var preciounidad = document.getElementById("preciounidad");
    var lock = document.getElementById("spanlock");
    if (preciounidad.readOnly) {
        preciounidad.removeAttribute("readonly");
        lock.classList.remove("bi-lock-fill");
        lock.classList.add("bi-unlock-fill");
    }
    else {
        preciounidad.setAttribute("readonly", true);
        lock.classList.remove("bi-unlock-fill");
        lock.classList.add("bi-lock-fill");
    }

}
