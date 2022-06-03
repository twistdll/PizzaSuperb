$(document).ready(function () {

    let productCount = $('#ProductCount');
    let cookieIdentifier = 'product';
    btnsInnit();

    //not client-side for purpose.
    $('#SearchText').change(function (e) {
        let name = $(this).val();
        getSearchedProducts(name);       
    });

    $('#ClearBtn').click(function (e) {
        $('#SearchText').val('');
        clearCookies();
        getSearchedProducts('');
    });

    function getSearchedProducts(name) {

        $('.product').remove();

        $.ajax({
            url: window.GetProductsByNameUrl + name,
            type: "GET",
            dataType: 'html',
            beforeSend: function () {
                productCount.text('');
                $('.product').remove();
                $('.spinner-border').css('display', 'block');
            },
            success: function (data) {
                $('.products').html(data);
                $('.spinner-border').css('display', 'none');
                btnsInnit();
            }
        });
    }

    function btnsInnit() {
        $('.add').click(function (e) {
            let count = $(this).siblings('.count');           
            addProduct(count);
            Cookies.set(cookieIdentifier + count.attr('name'), count.text(), {expires: 2});
        });

        $('.remove').click(function (e) {
            let count = $(this).siblings('.count');
            removeProduct(count);
            Cookies.set(cookieIdentifier + count.attr('name'), count.text(), { expires: 2 });
        });
    }

    function addProduct(localCount) {
        localCount.parent('.btns').css('border-color', '#E68891');
        localCount.css('color','#E68891');
        localCount.text(parseInt(localCount.text()) + 1);
        productCount.text(productCount.text() == '' ? 1 : parseInt(productCount.text()) + 1);
    }

    function removeProduct(localCount) {

        if (localCount.text() != '0' && productCount.text() != '' && productCount.text() != '1')
            productCount.text(parseInt(productCount.text()) - 1);
        else if (localCount.text() != '0' && productCount.text() == '1')
            productCount.text('');

        localCount.text(localCount.text() == '0' ? '0' : parseInt(localCount.text()) - 1);
        localCount.parent('.btns').css('border-color', localCount.text() == '0' ? 'black' : '#E68891');
        localCount.css('color', localCount.text() == '0' ? 'black' : '#E68891');
    }

    function clearCookies() {
        let productNames = $('.count').filter(
            function (e) {
                return parseInt($(this).text()) > 0
            });

        productNames.each(function (e) {
            Cookies.remove($(this).attr('name'));
        });
    }
});