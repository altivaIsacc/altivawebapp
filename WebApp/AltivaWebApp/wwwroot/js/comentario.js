
function GetComentarios(referencia, idRefernecia) {

    var comentarioModel = {
        mensaje: '',
        tipoMensaje: 'CO',
        tipoReferencia: referencia,
        id: idRefernecia
    };
    $.ajax({
        type: "POST",
        url: '@Url.Action("Nuevo-Comentario", "Mensajes")',
        data: comentarioModel,
        success: function (data) {
            $('#comentarios').html(data);
        },
        error: function (err, scnd) {
            console.log(err.statusText);

        }

    });
}



