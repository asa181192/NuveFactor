﻿<nav class="navbar navbar-trans navbar-inverse bg-inverse fixed-top" role="navigation" style='height: 60px'>
	<div class="navbar-header">
		<button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#navbar-collapsible">
			<span class="sr-only">Toggle navigation</span>
			<span class="icon-bar"></span>
			<span class="icon-bar"></span>
			<span class="icon-bar"></span>
		</button>
		<a class="navbar-brand" href="#">
			<img alt="Brand" src="/Images/logo_blanco.png" style="max-width:100px; margin-top: -9px;">
		</a>
	</div>
	<div class="navbar-collapse collapse">
		<ul class="nav navbar-nav navbar-right">
			<li>
				<a class="navbar-brand" href='@Url.Action("welcome", "Home")'>
					<img id="imghome" alt="Brand" src="/Images/menu/home_vg.png" style="max-width:45px; margin-top: -8px;">
				</a>
			</li>
			<li>
				<a class="navbar-brand" href='@Url.Action("contrasena_cambio", "Account")'>
					<img id="imgpassword" alt="Brand" src="/Images/menu/password_vg.png" style="max-width:45px; margin-top: -8px; margin-left: -25px;">
				</a>
			</li>
			<li>
				<a class="navbar-brand" href='@Url.Action("configuracion", "Home")'>
					<img id="imgconfig" alt="Brand" src="/Images/menu/config_vg.png" style="max-width:45px; margin-top: -8px; margin-left: -25px;">
				</a>
			</li>
			<li>
        @Using Html.BeginForm("LogOff", "Account", FormMethod.Post, New With {.id = "logoutForm", .class = "navbar-brand"})
          @Html.AntiForgeryToken()
          @<a href="javascript:document.getElementById('logoutForm').submit()">
              <img id="imglogout" alt="Brand" src="/Images/menu/logout_vg.png" style="max-width:45px; margin-top: -8px; margin-left: -25px;">
            </a>
        End Using
			</li>
			<li>
				<a class="navbar-brand" href='@Url.Action("consulta", "clientes", New With {.cliente = 126908})'>
					<img id="imgmenu" alt="Brand" src="/Images/menu/menu_vg.png" style="max-width:45px; margin-top: -8px; margin-left: -25px;">
				</a>
			</li>
		</ul>
		<form class="navbar-form navbar-left">
			<div class="form-group" style="display:inline;">
				<div class="input-group" style="margin-top: 4px;">
					<input type="text" class="form-control" placeholder="Buscar en clientes (nombre, RFC, CURP, #) en contrato (#), en crédito (#), en proveedores (nombre, #), en promotores (nombre, #)">
					<span class="input-group-addon" style='width:8%'><span class="glyphicon glyphicon-search"></span></span>
				</div>
			</div>
		</form>
	</div>
</nav>
		
<script type='text/javascript'>
	$(document).on('mouseover', '#imghome', function (e) {
	  $(this).attr('src', '/Images/menu/home_vb.png');
	});
	$(document).on('mouseout', '#imghome', function (e) {
	  $(this).attr('src', '/Images/menu/home_vg.png');
	});

	$(document).on('mouseover', '#imgpassword', function (e) {
	  $(this).attr('src', '/Images/menu/password_vb.png');
	});
	$(document).on('mouseout', '#imgpassword', function (e) {
	  $(this).attr('src', '/Images/menu/password_vg.png');
	});

	$(document).on('mouseover', '#imgconfig', function (e) {
	  $(this).attr('src', '/Images/menu/config_vb.png');
	});
	$(document).on('mouseout', '#imgconfig', function (e) {
	  $(this).attr('src', '/Images/menu/config_vg.png');
	});

	$(document).on('mouseover', '#imglogout', function (e) {
	  $(this).attr('src', '/Images/menu/logout_vb.png');
	});
	$(document).on('mouseout', '#imglogout', function (e) {
	  $(this).attr('src', '/Images/menu/logout_vg.png');
	});

	$(document).on('mouseover', '#imgmenu', function (e) {
	  $(this).attr('src', '/Images/menu/menu_vb.png');
	});
	$(document).on('mouseout', '#imgmenu', function (e) {
	  $(this).attr('src', '/Images/menu/menu_vg.png');
	});
</script>