
function GetComentarios(referencia, idRefernecia) {


    var comentarioModel = {
        mensaje: '',
        tipoMensaje: 'CO',
        tipoReferencia: referencia,
        id: idRefernecia
    };


    $.ajax({
        type: "GET",
        //headers: {
        //    "RequestVerificationToken": '@GetAntiXsrfRequestToken()'
        //},
        url: '/Mensajes/Nuevo-Comentario',
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
