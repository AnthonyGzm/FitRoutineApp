// Función para mostrar un modal con contenido cargado por AJAX
function showInPopup(url, title) {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
        }
    });
}

// Función para manejar el envío de formularios por AJAX
function jQueryAjaxPost(form) {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $('#view-all').html(res.html);
                    $('#form-modal .modal-body').html('');
                    $('#form-modal .modal-title').html('');
                    $('#form-modal').modal('hide');
                    // Recargar la página
                    location.reload();
                } else {
                    $('#form-modal .modal-body').html(res.html);
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
        // Prevenir el envío predeterminado del formulario
        return false;
    } catch (ex) {
        console.log(ex);
    }
}

// Función para manejar el diálogo de eliminación
(function (modalDeleteDialog) {
    var methods = {
        "openModal": openModal,
        "deleteItem": deleteItem
    };

    var item_to_delete;

    /**
     * Abre un modal por nombre de clase o ID.
     *
     * @param {string} modalName - Nombre de la clase o ID del modal.
     * @param {boolean} classOrId - Indica si modalName es una clase (true) o un ID (false).
     * @param {string} sourceEvent - Nombre de la clase o ID del evento desencadenante.
     * @param {string} deletePath - Ruta para eliminar el ítem.
     * @param {boolean} eventClassOrId - Indica si sourceEvent es una clase (true) o un ID (false).
     */
    function openModal(modalName, classOrId, sourceEvent, deletePath, eventClassOrId) {
        var textEvent;
        if (classOrId) {
            textEvent = "." + modalName;
        } else {
            textEvent = "#" + modalName;
        }

        $(textEvent).click((e) => {
            item_to_delete = e.currentTarget.dataset.id;
            deleteItem(sourceEvent, deletePath, eventClassOrId);
        });
    }

    /**
     * Ruta para eliminar un ítem.
     *
     * @param {string} sourceEvent - Nombre de la clase o ID del evento desencadenante.
     * @param {string} deletePath - Ruta para eliminar el ítem.
     * @param {boolean} eventClassOrId - Indica si sourceEvent es una clase (true) o un ID (false).
     */
    function deleteItem(sourceEvent, deletePath, eventClassOrId) {
        var textEvent;
        if (eventClassOrId) {
            textEvent = "." + sourceEvent;
        } else {
            textEvent = "#" + sourceEvent;
        }
        $(textEvent).click(function () {
            window.location.href = deletePath + item_to_delete;
        });
    }

    modalDeleteDialog.sc_deleteDialog = methods;

})(window);
