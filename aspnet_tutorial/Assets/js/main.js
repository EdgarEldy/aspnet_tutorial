// Get products by category id
$(function () {
    $('#CategoryId').on('change', function () {
        var id = $(this).val();
        //alert(id);
        $.get('/Orders/GetProducts', { id: id }, function (data) {
            $('#ProductId').empty();
            $.each(data, function (index, row) {
                $('#ProductId').append("<option value='" + row.Id + "'>" + row.ProductName + "</option>")
            });
            });
    });
});

//Getting unit price
$(function () {
    $('#ProductId').on('change', function () {
        var productId = $(this).val();
        $.get('/Orders/getUnitPrice', { productId: productId }, function (data) {
            $('.unit-price').val(data.UnitPrice);
        });
    });
});

//Calcute the total
$(function () {
    $('#qty').on('change', function () {
        var qty = $(this).val();
        var unit_price = $('.unit-price').val();
        var total = qty * unit_price;
        $('#total').val(total);
    });
});