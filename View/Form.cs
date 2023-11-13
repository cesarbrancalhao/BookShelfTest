@model Bookshelf.Book
@{
	Layout = null;
}

<!DOCTYPE html>

<html lang="en">
	<head>
		<meta charset="utf-8">
		<meta http-equiv="X-UA-Compatible" content="IE=edge">
		<meta name="Bookshelf" content="width=device-width, initial-scale=1">
		<title>BookShelf</title>

		<!-- CSS Includes -->
		<link rel="stylesheet" href="//netdna.bootstrapcdn.com/bootstrap/3.1.1/css/bootstrap.min.css">
		
		<style type="text/css">

			.field-validation-error {
				color: #ff0000;
			}

		</style>
	</head>
	
	<body>
		<div class="container">
			<div class="col-md-6 col-md-offset-3">
				<h1>Average bookstan moment</h1>
	
				@using (Html.BeginForm())
				{
					<div class="form-group">
						@Html.LabelFor(m => m.BookName)
						@Html.TextBoxFor(model => model.BookName, new {@class="form-control"}) 
						@Html.ValidationMessageFor(model => model.BookName)
					</div>
				
					<div class="form-group">
						@Html.LabelFor(m => m.BookNumPages)
						@Html.TextBoxFor(model => model.BookNumPages, new {@class="form-control"}) 
						@Html.ValidationMessageFor(model => model.BookNumPages)
					</div>
				
					<div class="form-group">
						@Html.LabelFor(m => m.ISBN)
						@Html.TextBoxFor(model => model.ISBN, new {@class="form-control"}) 
						@Html.ValidationMessageFor(model => model.ISBN)
					</div>
				
					<button type="button" class="btn btn-success submit">Ask</button>
				}
	
				<br/><br/>
				<div class="alert alert-warning fade">
					<strong><span class="alert-content"></span></strong>
				</div>
			</div>
		</div>

		<script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
		<script src="//netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js"></script>
	
		<script src="//ajax.aspnetcdn.com/ajax/jquery.validate/1.11.1/jquery.validate.min.js"></script>
		<script src="//ajax.aspnetcdn.com/ajax/mvc/4.0/jquery.validate.unobtrusive.min.js"></script>
		
		<script type="text/javascript">
		
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

		</script>
	</body>
</html>
