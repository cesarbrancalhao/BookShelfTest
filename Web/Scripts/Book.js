function openAlert(txt) {
    $('.alert-content').text(txt);
    $('.alert').addClass('in');
}

function closeAlert() {
    $('.alert').removeClass('in');
}

$(function(){
    var name = '@Model.BookName';

    if(name && name != '')
        openAlert(name);

    $('#BookName').change(closeAlert);
    $('#BookName').keyup(closeAlert);

    var pages = '@Model.BookNumPages';

    if(pages && pages == '')
        openAlert(pages);

    $('#BookNumPages').change(closeAlert);
    $('#BookNumPages').keyup(closeAlert);

    $('.submit').click(function(){
        if($('form').valid()) {
        
            $.ajax({
                url: '@Url.RouteUrl(new{ action="_listStrings", controller="BookController"})',
                data: {BookName: $('BookName').val(), BookNumPages: $('#BookNumPages').val(), ISBN: $('ISBN').val()},
                    type: 'POST',
                    dataType: 'json',
                    contentType: "application/json; charset=utf-8",
                    success: function(resp) {
                    openAlert(resp);
            }});
        }
        else {
            closeAlert();
        }
    });

});