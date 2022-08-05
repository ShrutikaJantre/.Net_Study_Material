
		//hyper link

<a href="@Url.Action( "Edit","Ps", new { id = item.PId })">@item.PId</a>

         //textarea

@Html.TextAreaFor(model => model.Des, 10, 200, null);

          //drop down list

 @Html.DropDownListFor(model => model.CityId, (IEnumerable<SelectListItem>)ViewBag.Cities)
	 
			//readonly
			
 @Html.EditorFor(model => model.LoginName, new { htmlAttributes = new { @class = "form-control", @readonly = "readonly" } })
 
 
			//partial view
			
@Html.Partial("logoutView")

			//checkbox
			
@Html.CheckBoxFor(model => Model.isActive) Remember me


			//partial view code
			
@using (Html.BeginForm("Logout", "Persons", FormMethod.Post))
{
    <input type="submit" value="Logout" class="btn btn-default" />

}

			//navbar
			
<div class="navbar navbar-dark bg-success navbar-fixed-top">