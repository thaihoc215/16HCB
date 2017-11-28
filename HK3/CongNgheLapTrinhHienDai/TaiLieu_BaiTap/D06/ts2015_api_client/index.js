$(function() {
    // alert('msg');

    $.ajax({
        url: 'http://localhost:3000/products',
        dataType: 'json',
        timeout: 10000
    }).done(function(data) {
        // console.log(data);

        var source = $('#product-template').html();
        var template = Handlebars.compile(source);
        var html = template(data);

        // console.log(html);
        $('#products').html(html);
    });
});

$('#btnAdd').on('click', function() {
    var _code = $('#txtCode').val();
    var _name = $('#txtName').val();
    var _price = $('#txtPrice').val();

    var product = {
        code: _code,
        name: _name,
        price: _price
    };

    $.ajax({
        url: 'http://localhost:3000/products',
        type: 'POST',
        dataType: 'json',
        timeout: 10000,
        contentType: 'application/json',
        data: JSON.stringify(product)
    }).done(function(data) {
        product.id = data;

        var arr = [];
        arr.push(product);

        var source = $('#product-template').html();
        var template = Handlebars.compile(source);
        var html = template(arr);
        $('#products').append(html);
    });
});