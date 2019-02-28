function getCart() {
    $.getJSON(apiUrl + "cart",
        function (data) {
            refreshCart(data);
        });
}

function updateCart() {
    var data = getCurrentCart();

    $.ajax({
        url: apiUrl + "cart/update",
        method: 'POST',
        data: JSON.stringify(data),
        contentType: "application/json",
        success: function (data) {
            refreshCart(data);
        }
    });
}

function getCurrentCart() {
    var data = [];

    $("div.cart div.content div.row").each(function (i, jRow) {
        data.push({ id: $(jRow).find(".id").text(), rentalPeriod: $(jRow).find(".rentalPeriod input").val() });
    });
    return data;
}

function refreshCart(data) {
    var jContent = $("div.cart div.content").empty();
    for (var i in data) {
        //if (!data.hasOwnProperty(item)) continue;

        var jRow = $("<div/>").addClass("row");
        jRow.append($("<div/>").addClass("id collapse").append($("<span/>").text(data[i].id)));
        jRow.append($("<div/>").addClass("col-3 name").append($("<span/>").text(data[i].name)));
        jRow.append($("<div/>").addClass("col-2 type").append($("<span/>").text(data[i].type)));
        jRow.append($("<div/>").addClass("col-2 points").append($("<span/>").text(data[i].loyaltyPoints)));
        jRow.append($("<div/>").addClass("col-2 rentalPeriod").append($("<input type='number'/>").val(data[i].rentalPeriod)));
        jRow.append($("<div/>").addClass("col-2 price").append($("<span/>").text(data[i].price)));

        jContent.append(jRow);
    }
}

function checkout() {
    var data = getCurrentCart();
    $.ajax({
        url: apiUrl + "cart/checkout",
        method: 'POST',
        data: JSON.stringify(data),
        contentType: "application/json",
        success: function () {
            window.location = "/Orders";
        }
    });
}

$(document).ready(function () {
    getCart();
});