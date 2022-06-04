$(document).ready(function (e) {

    $('#TotalPrice').text(getTotal());

    let cookiePrefix = "dopping"

    $('#Cart .add').click(function (e) {
        let count = $(this).siblings('.count');
        addDopping(count);
    });

    $('#Cart .remove').click(function (e) {
        let count = $(this).siblings('.count');
        removeDopping(count);
    });

    $('#CreateOrderBtn').click(function (e) {
        e.preventDefault();
    });

    function addDopping(localCount) {
        localCount.parent('.btns').css('border-color', '#E68891');
        localCount.css('color', '#E68891');
        localCount.text(parseInt(localCount.text()) + 1);
    }

    function removeDopping(localCount) {
        localCount.text(localCount.text() == '0' ? '0' : parseInt(localCount.text()) - 1);
        localCount.parent('.btns').css('border-color', localCount.text() == '0' ? 'black' : '#E68891');
        localCount.css('color', localCount.text() == '0' ? 'black' : '#E68891');
    }

    function getTotal() {
        let sum = 0;

        $('.total-price').each(function (e) {
            sum += parseInt($(this).text())
        });
        return sum;
    }
})