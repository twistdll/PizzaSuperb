$(document).ready(function (e) {

    $('#TotalPrice').text(getTotal());

    let cookiePrefix = "dopping"

    $('#OrderForm').validate({
        rules: {
            Email: {
                required: true,
                email: true
            },
            Password: {
                required: true
            },
            Address: {
                required: true
            }
        }
    });

    $('#Cart .add').click(function (e) {
        let count = $(this).siblings('.count');
        addDopping(count);
        Cookies.set(cookiePrefix + count.attr('name'), count.text(), { expires: 2 });
        $('#TotalPrice').text(getTotal());
    });

    $('#Cart .remove').click(function (e) {
        let count = $(this).siblings('.count');
        removeDopping(count);
        Cookies.set(cookiePrefix + count.attr('name'), count.text(), { expires: 2 });
        $('#TotalPrice').text(getTotal());
    });

    $('#CreateOrderBtn').click(function (e) {
        e.preventDefault();
        
        if ($('#OrderForm').valid()) {
            let email = $('input[name="Email"]').val();
            let password = $('input[name="Password"]').val();
            let address = $('input[name="Address"]').val();

            $.ajax({
                url: window.CreateOrderUrl,
                type: "POST",
                data: JSON.stringify({
                    Email: email,
                    Password: password,
                    Address: address
                }),
                contentType: "application/json",
                beforeSend: function (e) {
                    $('#CreateOrderBtn').text('');
                    $('#CreateOrderBtn .spinner-border').css('display','inline-block');
                    $('#CreateOrderBtn').prop('disabled',true);
                },
                success: function (data) {
                    $('#CreateOrderBtn').text('Order was made. Wait for delivery.');
                },
                error: function (data) {
                    $('#CreateOrderBtn').prop('disabled', false);
                    $('#CreateOrderBtn').text('Make order');
                    alert('Error while processing your order. Maybe you have active deliveries. Please contact us by smth.');
                },
                complete: function (data) {
                    $('#CreateOrderBtn .spinner-border').hide();
                }
            });
        }
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

        let sum = 0.0;

        $('.total-price').each(function (e) {
            sum += parseInt($(this).text())
        });

        $('.dopping-item').each(function (e) {
            console.log(parseFloat($(' .price', this).text()));
            console.log(parseInt($(' .count', this).text()));
            sum += (parseFloat($(' .price', this).text().replace(',','.')) * parseInt($(' .count', this).text()))
        });

        return sum;
    }
})