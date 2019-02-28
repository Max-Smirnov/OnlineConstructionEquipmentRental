$(document).ready(function () {
    $.getJSON(apiUrl + "equipment",
        function (data) {
            var jContent = $("div.equipment div.content").empty();
            for (var i in data) {
                //if (!data.hasOwnProperty(item)) continue;

                var jRow = $("<div/>").addClass("row");
                jRow.append($("<div/>").addClass("col-7").append($("<span/>").text(data[i].name)));
                jRow.append($("<div/>").addClass("col-2").append($("<span/>").text(data[i].type)));
                jRow.append($("<div/>").addClass("col-2").append($("<span/>").text(data[i].loyaltyPoints)));
                jRow.append($("<div/>").addClass("col-1").append(
                    $("<input type='button' class='btn' onclick='addToCart(" + data[i].id + ");' value='Add To Cart' />")));

                jContent.append(jRow);
            }
        });
});

function addToCart(id) {
    $.ajax({
        url: apiUrl + "cart",
        method: 'POST',
        data: JSON.stringify(id),
        contentType: "application/json",
        success: function (result) {
            getCart();
        }
    });
}

function deleteToCart(id) {
    $.ajax({
        url: apiUrl + "cart/" + id,
        type: 'DELETE',
        contentType: "application/json",
        success: function (result) {
            getCart();
        }
    });
}