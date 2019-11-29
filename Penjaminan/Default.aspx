<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Penjaminan._Default" %>

<!DOCTYPE html>
<html lang="en-US">
<head>
	<title>Penjaminan</title>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<link rel="icon" type="image/png" href="/kbi.ico"/>

	<link rel="stylesheet" type="text/css" href="/Scripts/vendor/bootstrap/css/bootstrap.min.css">
	<link rel="stylesheet" type="text/css" href="/Scripts/fonts/font-awesome-4.7.0/css/font-awesome.min.css">
	<link rel="stylesheet" type="text/css" href="/Scripts/fonts/iconic/css/material-design-iconic-font.min.css">
	<link rel="stylesheet" type="text/css" href="/Scripts/vendor/animate/animate.css">
	<link rel="stylesheet" type="text/css" href="/Scripts/vendor/css-hamburgers/hamburgers.min.css">
	<link rel="stylesheet" type="text/css" href="/Scripts/vendor/animsition/css/animsition.min.css">
	<link rel="stylesheet" type="text/css" href="/Scripts/vendor/select2/select2.min.css">
	<link rel="stylesheet" type="text/css" href="/Scripts/vendor/daterangepicker/daterangepicker.css">
	<link rel="stylesheet" type="text/css" href="/Scripts/css/util.css">
	<link rel="stylesheet" type="text/css" href="/Scripts/css/main.css">
</head>
<body>
	
	<div class="limiter">
		<div class="container-login100">
			<div class="wrap-login100">
				<form method="post" class="login100-form" autocomplete="off" runat="server">
					<span class="login100-form-title p-b-48">
						<img src="/Scripts/img/kbi.png" alt="" />
					</span>

					<div class="wrap-input100 validate-input" data-validate = "Valid email is: a@b.c">
						<input class="input100" type="text" id="txtUsername" runat="server">
						<span class="focus-input100" data-placeholder="Email"></span>
					</div>

					<div class="wrap-input100 validate-input" data-validate="Enter password">
						<span class="btn-show-pass">
							<i class="zmdi zmdi-eye"></i>
						</span>
						<input class="input100" type="password" id="txtPassword" runat="server">
						<span class="focus-input100" data-placeholder="Password"></span>
					</div>

					<div class="container-login100-form-btn">
						<div class="wrap-login100-form-btn">
							<div class="login100-form-bgbtn" ></div>
							<asp:Button type="submit" class="buttonasp slogin100-form-btn" runat="server" onclick="btnLogin_Click" Text="Login"/>
						</div>
					</div>
				</form>
			</div>
		</div>
	</div>
	
	<div id="dropDownSelect1"></div>
	
	<script src="/Scripts/vendor/jquery/jquery-3.2.1.min.js"></script>
	<script src="/Scripts/vendor/animsition/js/animsition.min.js"></script>
	<script src="/Scripts/vendor/bootstrap/js/popper.js"></script>
	<script src="/Scripts/vendor/bootstrap/js/bootstrap.min.js"></script>
	<script src="/Scripts/vendor/select2/select2.min.js"></script>
	<script src="/Scripts/vendor/daterangepicker/moment.min.js"></script>
	<script src="/Scripts/vendor/daterangepicker/daterangepicker.js"></script>
	<script src="/Scripts/vendor/countdowntime/countdowntime.js"></script>
	<script src="/Scripts/js/main.js"></script>

</body>
</html>