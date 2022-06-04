$(document).ready(function (e) {

    $('#TotalPrice').text(getTotal());

    function getTotal() {
        let sum = 0;

        $('.total-price').each(function (e) {
            sum += parseInt($(this).text())
        });
        return sum;
    }
})