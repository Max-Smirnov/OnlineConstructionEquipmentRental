$(document).ready(function () {
    getOrders();
});

function getOrders() {
    $.getJSON(apiUrl + "orders",
        function (data) {
            refreshOrdersList(data);
        });
}


function refreshOrdersList(data) {
    var jContent = $("div.orders div.content").empty();
    for (var i in data) {
        //if (!data.hasOwnProperty(item)) continue;

        var jRow = $("<div/>").addClass("row");
        jRow.append($("<div/>").addClass("col-1 id").append($("<span/>").text(data[i].id)));
        jRow.append($("<div/>").addClass("col-2 itemsCount").append($("<span/>").text(data[i].itemsCount)));
        jRow.append($("<div/>").addClass("col-2 points").append($("<span/>").text(data[i].loyaltyPoints)));
        jRow.append($("<div/>").addClass("col-2 price").append($("<span/>").text(data[i].price)));
        jRow.append($("<div/>").addClass("col-1 invoice-button").append(
            $("<a class='btn' target='blank' href='" + apiUrl + "orders/invoice/" + data[i].id + "' >Invoice</a>")));

        jContent.append(jRow);
    }
}
