$(document).ready(function () {

    let productCount = $('#ProductCount');

    $('.add').click(function (e) {
        let count = $(this).siblings('.count');
        addProduct(count);
    });

    $('.remove').click(function (e) {
        let count = $(this).siblings('.count');
        removeProduct(count);
    });

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
});