function openAlert(txt) {
    $('.alert-content').text(txt);
    $('.alert').addClass('in');
}

function closeAlert() {
    $('.alert').removeClass('in');
}

$(function () {
    $('#BookNumPages').removeAttr('placeholder');

    $('.submit').click(function () {
        if ($('form').valid()) {
            var book = {
                BookName: $('#BookName').val(),
                BookNumPages: $('#BookNumPages').val(),
                ISBN: $('#ISBN').val()
            };

            $.ajax({
                url: '@Url.Action("GetBook", "Book")',
                data: JSON.stringify(book),
                type: 'POST',
                dataType: 'json',
                contentType: "application/json; charset=utf-8",
                success: function (resp) {
                    openAlert(resp);
                }
            });
        } else {
            closeAlert();
        }
    });

    $('#BookName').change(closeAlert);
    $('#BookName').keyup(closeAlert);

    $('#BookNumPages').change(closeAlert);
    $('#BookNumPages').keyup(closeAlert);

    $('#ISBN').change(closeAlert);
    $('#ISBN').keyup(closeAlert);
});