function obtenerHistorial() {
    var start_time = new Date().getTime();
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
        .done(function (data, status, jqXHR) {
            var request_time = new Date().getTime() - start_time;
            var txtStatus = document.getElementById("txtStatus");
            txtStatus.innerText = "Éxito al procesar la solicitud: " + jqXHR.status + " " + jqXHR.statusText + " en un tiempo de: "+request_time;
                 })
        .fail(function (jqXHR,status,errorThrow) {
            var txtStatus = document.getElementById("txtStatus");
            txtStatus.innerText = "Error al procesar la solicitud:" + jqXHR.status+" "+jqXHR.statusText;
        });
}

function obtenerMockup() {
    var start_time = new Date().getTime();
    $.ajax({
        url: "https://apim-demo-fepade.azure-api.net/test",
        beforeSend: function (xhrObj) {
            //// Request headers
            xhrObj.setRequestHeader('Access-Control-Allow-Headers', '*');
            xhrObj.setRequestHeader("Ocp-Apim-Subscription-Key", "4904bf8d34dc49d4a671536e76d328c8");
        },
        type: "GET",
        // Request body
        data: "",
    })
        .done(function (data, status, jqXHR) {
            var request_time = new Date().getTime() - start_time;
            var txtStatus = document.getElementById("txtMock");
            txtStatus.innerText = "Éxito al procesar la solicitud: " + jqXHR.status + " " + jqXHR.statusText + " en un tiempo de: " + request_time;
            var txtData = document.getElementById("txtData");    
            txtData.innerText = JSON.stringify(data);
            //data.TransactionHistory.forEach(function (current, index, array) {
            //    console.log(current);
            //    txtData.innerText = current;
            //});
        })
        .fail(function (jqXHR, status, errorThrow) {
            var txtStatus = document.getElementById("txtMock");
            txtStatus.innerText = "Error al procesar la solicitud:" + jqXHR.status + " " + jqXHR.statusText;
        });
}