$(document).ready(function () {

    let productCount = $('#ProductCount');
    productCount.text(getSumCount() == 0 ? '' : getSumCount());

    btnsInit();

    $('#SearchText').change(function (e) {
        let name = $(this).val();
        getSearchedProducts(name);
    });

    $('#ClearBtn').click(function (e) {
        $('#SearchText').val('');
        productCount.text(parseInt(productCount.text()) - getReduceValue());
        if (productCount.text() == '0')
            productCount.text('');

        let cookiePrefix = 'product';
        clearCookies(cookiePrefix);
        getSearchedProducts('');
    });

    //not client-side for purpose.
    function getSearchedProducts(name) {

        $('.product').remove();

        $.ajax({
            url: window.GetProductsByNameUrl + name,
            type: "GET",
            dataType: 'html',
            beforeSend: function () {
                $('.product').remove();
                $('.spinner-border').css('display', 'block');
            },
            success: function (data) {
                $('.products').html(data);
                $('.spinner-border').css('display', 'none');
                btnsInit();
            }
        });
    }

    function btnsInit() {
        let cookiePrefix = 'product';

        $('.add').click(function (e) {
            let count = $(this).siblings('.count');
            addProduct(count);
            Cookies.set(cookiePrefix + count.attr('name'), count.text(), { expires: 2 });
        });

        $('.remove').click(function (e) {
            let count = $(this).siblings('.count');
            removeProduct(count);
            Cookies.set(cookiePrefix + count.attr('name'), count.text(), { expires: 2 });
        });
    }

    function addProduct(localCount) {
        localCount.parent('.btns').css('border-color', '#E68891');
        localCount.css('color', '#E68891');
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

    function clearCookies(cookiePrefix) {
        let productNames = $('.count').filter(
            function (e) {
                return parseInt($(this).text()) > 0
            });

        productNames.each(function (e) {
            Cookies.remove(cookiePrefix + $(this).attr('name'));
        });
    }

    function getSumCount() {
        let sum = 0;
        $('.count').each(function (e) {
            sum += parseInt($(this).text())
        });
        return sum;
    }

    function getReduceValue() {
        let value = 0;
        $('.count')
            .filter(
                function (e) {
                    return parseInt($(this).text()) > 0
                })
            .each(
                function (e) {
                    value += parseInt($(this).text())
                });

        return value;
    }
});