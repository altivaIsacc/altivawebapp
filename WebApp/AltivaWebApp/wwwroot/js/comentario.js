
function GetComentarios(referencia, idRefernecia) {

    

    var comentarioModel = {
        mensaje: '',
        tipoMensaje: 'CO',
        tipoReferencia: referencia,
        id: idRefernecia
    };
    console.log(comentarioModel);

    $.ajax({
        type: "POST",
        url: '../../Mensajes/Nuevo-Comentario',
        data: comentarioModel,
        success: function (data) {
            $('#comentarios').html(data);
        },
        error: function (err, scnd) {

            alert("Lo sentimos, tuvimos un problema al procesar tu solicitud.");
            console.log(err.statusText);

        }

    });
}
