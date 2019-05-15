function getImgFromUrl(logo_url) {
    var img = new Image();
    img.src = logo_url;
    return getBase64Image(img);

}
function getBase64Image(img) {

    var canvas = document.createElement("canvas");

    canvas.width = img.width;
    canvas.height = img.height;
    var ctx = canvas.getContext("2d");

    ctx.drawImage(img, 0, 0);

    var dataURL = canvas.toDataURL("image/jpeg");

    return dataURL;

}