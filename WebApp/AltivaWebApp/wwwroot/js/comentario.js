function GetComentarios(referencia, idRefernecia, urlComentarios = '../../Mensajes/Nuevo-Comentario') {
    var comentarioModel = {
        mensaje: '',
        tipoMensaje: 'CO',
        tipoReferencia: referencia,
        id: idRefernecia
    };
    $.ajax({
        type: "POST",
        url: urlComentarios,
        data: comentarioModel,
        success: function (data) {
            $('#comentarios').html(data);
        },
        error: function (err, scnd) {
            console.log(err.statusText);
        }
    });
}


