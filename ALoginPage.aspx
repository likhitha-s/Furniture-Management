﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ALoginPage.aspx.cs" Inherits="My__First_App.ALogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

<form id="form1" runat="server">
 
  <div class="container">
    <label for="uname"><b>Username</b></label>
    <input type="text" placeholder="Enter Username" name="uname" />

    <label for="psw"><b>Password</b></label>
    <input type="password" placeholder="Enter Password" name="psw"/>

    <button type="submit">Login</button>
    <label>
      <input type="checkbox" checked="checked" name="remember"/> Remember me
    </label>
  </div>

  <div class="container" style="background-color:#f1f1f1">
    <button type="button" class="cancelbtn">Cancel</button>
    <span class="psw">Forgot <a href="#">password?</a></span>
  </div>
</form>


</body>
</html>
