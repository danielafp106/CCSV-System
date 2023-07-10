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

            var isValid = data.success;
            //averiguar como arreglar lo del reinicio de la pantalla
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

    if (!isNaN(stock) && !isNaN(total) && stock !=0 && total != 0) {
        preciounidad.value = (total / stock).toFixed(2);
    }
    else {
        preciounidad.value = 0.00;
    }
}

function calculoTotalComprado() {
    var stock = document.getElementById("stock").value;
    var total = document.getElementById("total");
    var preciounidad = document.getElementById("preciounidad").value;

    if (!isNaN(stock) && !isNaN(preciounidad) && stock != 0 && preciounidad != 0) {
        total.value = (stock * preciounidad).toFixed(2);
    }
    else {
        total.value = 0.00;
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

function SeleccionarProducto(id,flag) {
    var inputProd = document.getElementById("idProd");
    var inputProd2 = document.getElementById("idProd2");
    if (flag) {
        inputProd.value = "";
        inputProd2.value = "";
    }
    else {
        inputProd.value = id;
        inputProd2.value = id;
    }
  
}

function ReiniciarSelect() {
    var select = document.getElementById("selectBox");
    select.value = -1;
}

function InputsProductos(flag) {
    var p1 = document.getElementById("p1");
    var p2 = document.getElementById("p2");
    var p3 = document.getElementById("p3");
    if (flag) {
        p1.value = "ID";
        p2.value = "ID";
        p3.value = "ID";
    }
    else {
        p1.value = "";
        p2.value = "";
        p3.value = "";
    }
}


function AgregarStock() {
    var stockM = document.getElementById("stockModelos");
    var selectM = document.getElementById("selectModelos");
    var divM = document.getElementById("listadoModelos");
    var indexI = document.getElementById("contadorModelos");

    var stock = document.getElementById("stock");

    var index = parseInt(indexI.value);
    var stockcurrent = document.getElementById(selectM.value);
    //var last = '<div class="col-4" style="margin-top:2px;"> </div>';
    if (selectM.value != -1 && parseInt(stockM.value) != '' && parseInt(stockM.value) != 0)
    {
        if (stockcurrent != null)
        {
            stockcurrent.value = parseInt(stockcurrent.value) + parseInt(stockM.value);
        }
        else
        {
            divM.insertAdjacentHTML('beforeend', AddModelsHTML(selectM.options[selectM.selectedIndex].text, 'MARCA' + selectM.value,0,index));
            divM.insertAdjacentHTML('beforeend', AddModelsHTML(stockM.value, selectM.value, 1, index));
            divM.insertAdjacentHTML('beforeend', AddModelsHTML('', selectM.value, 3, index));
            indexI.value = index + 1;
        }
        stock.value = parseInt(stock.value) + parseInt(stockM.value);
        calculoTotalComprado();
        stockM.value = '';
        selectM.value = -1;
        
    }
   
   
}

function AddModelsHTML(valor, id, n, i) {
    if (n == 0) {
        var t = '<div class="col-4" style="margin-top:2px;">' +           
            '<input type="text" class="form-control" value="' + valor + '" id="' + id + '" readonly/>' +
            ' </div>';
    }
    else if (n == 1) {
        var t = '<div class="col-4" style="margin-top:2px;">' +
            '<input type="text" class="form-control visually-hidden" id="ID-'+id+'" value="' + id + '" readonly name="detalleProductosModelos[' + i + '].idModelo"/>' +
            '<input type="number" class="form-control" value="' + valor + '" id="' + id + '" name="detalleProductosModelos[' + i +'].stockProductoModelo" readonly/>' +
            ' </div>';
    }
    else {
        var t = '<div class="col-4" style="margin-top:2px;">' +
            '<button type="button" class="btn btn-danger" id="EliminarM' + id +'" onclick="DeleteModelsHTML(\'' + id + '\')">' +
            '<i class="bi bi-trash-fill"></i>'+
            '</button>'+
            ' </div>';
    }
    
    return t;                               
}

function DeleteModelsHTML(id) {
    var iStock = document.getElementById(id);
    var iMarca = document.getElementById("MARCA" + id);
    var iMarcaId = document.getElementById("ID-" + id);
    var iEliminar = document.getElementById("EliminarM" + id);
    var stock = document.getElementById("stock");

    stock.value = parseInt(stock.value) - parseInt(iStock.value);
    calculoTotalComprado();

    iStock.value = null;
    iMarca.value = null;
    iMarcaId.value = null;

    iStock.classList.add("visually-hidden");
    iMarca.classList.add("visually-hidden");
    iEliminar.classList.add("visually-hidden")

}
