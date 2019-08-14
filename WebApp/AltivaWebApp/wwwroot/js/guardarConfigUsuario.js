
function guardarConfigUsuario(idUsuario, url) {
    var config = {
        idUsuario: idUsuario,
        tema: localStorage.getItem('tema'),
        idioma: localStorage.getItem('idioma')
    };

    $.ajax({
        type: "POST",
       
        url: url,
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