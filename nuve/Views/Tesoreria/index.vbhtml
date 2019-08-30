@ModelType nuve.Helpers.Menu

@Code
    ViewData("Title") = "Tesorería"
End Code

@section scripts
    <script src="~/Scripts/TesoScripts/Index.js?v=@String.Concat(Today.Day, Today.Month, Today.Year, TimeOfDay.Hour, TimeOfDay.Minute, TimeOfDay.Second)"></script>
End Section

<h2>Tesorería</h2>

<div class="lead">
    <div class="ContenedorFlexbox">
        @Html.Raw(Model.sMenu)
    </div>     
</div>
