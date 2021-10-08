$(document).ready(function () {

});

setTitle = (title) => { document.title = "Sweets - " + title; };
OpenToast = () => { $(".toast").toast('show'); };

function Alert(msg) {
    alert(msg);
}

const sleep = (s) => {
    return new Promise(resolve => setTimeout(resolve, (s * 1000)))
}

function ShowModal(modal) {
    $("#" + modal).modal("show");
    $("#" + modal).appendTo("body");
}

let handler;
window.Connection = {
    Initialize: function (interop) {

        handler = function () {
            interop.invokeMethodAsync("Connection.StatusChanged", navigator.onLine);
        }

        window.addEventListener("online", handler);
        window.addEventListener("offline", handler);

        handler(navigator.onLine);
    },
    Dispose: function () {

        if (handler != null) {

            window.removeEventListener("online", handler);
            window.removeEventListener("offline", handler);
        }
    }
};