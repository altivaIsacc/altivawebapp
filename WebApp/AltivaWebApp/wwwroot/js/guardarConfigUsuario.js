
function guardarConfigUsuario(idUsuario) {
    var config = {
        idUsuario: idUsuario,
        tema: localStorage.getItem('tema'),
        idioma: localStorage.getItem('idioma')
    };

    $.ajax({
        type: "POST",
       
        url: '../Cambiar-Configuracion',
        data: config,
        success: function (data) {
            console.log(data.data);
        },
        error: function (err, scnd) {
            console.log(err.statusText);
            $('#errorDiv').attr('hidden', false);
        }
    });
}