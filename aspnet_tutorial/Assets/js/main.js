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

//Calculate the total
$(function () {
    $('#Qty').on('keyup', function () {
        var qty = $(this).val();
        var unitPrice = $('.unit-price').val();
        var total = qty * unitPrice;
        $('#Total').val(total);
    });
});