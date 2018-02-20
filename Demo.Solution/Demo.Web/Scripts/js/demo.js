function obtenerHistorial() {
    var params = {
        // Request parameters
    };

    $.ajax({
        url: "https://apim-demo-fepade.azure-api.net/testcache/api/Demo",
        beforeSend: function (xhrObj) {
            //// Request headers
            xhrObj.setRequestHeader('Access-Control-Allow-Headers', '*');
            xhrObj.setRequestHeader("Ocp-Apim-Subscription-Key", "4904bf8d34dc49d4a671536e76d328c8");
        },
        type: "GET",
        // Request body
        data: "",
    })
        .done(function (data) {
            alert("success");
        })
        .fail(function () {
            alert("error");
        });
}