// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


function startTime() {
    var now = new Date();
    var strDateTime = [[AddZero(now.getDate()),
    AddZero(now.getMonth() + 1),
    now.getFullYear()].join("/"),
    [AddZero(now.getHours(":")),
    AddZero(now.getMinutes())].join(":"),
    [AddZero(now.getSeconds())].join(":"),
    now.getHours() >= 12 ? "PM" : "AM"].join(" ");

    document.getElementById("datetime").innerHTML = strDateTime;

    var strDate = [[AddZero(now.getDate()),
    AddZero(now.getMonth() + 1),
    now.getFullYear()].join("/")];

    document.getElementById("date").innerHTML = strDate;


    var t = setTimeout(startTime, 500);
}
function AddZero(num) {
    return (num >= 0 && num < 10) ? "0" + num : num + "";
}



