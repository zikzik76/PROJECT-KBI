<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EntryMitraPemegangSaham.aspx.cs" Inherits="Penjaminan.Penjaminan.EntryMitraPemegangSaham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script>
        $(document).ready(function () {

            // Format mata uang.           
            $('.duit').mask('000.000.000', { reverse: true });
            
        });
        function backAdd() {
            window.location.replace(window.location.origin + '/Penjaminan/EntryMitra?eType=add');
        }

        function backEdit() {
            window.location.replace(window.location.origin + '/Penjaminan/EntryMitra?eType=edit');
        }
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <nav class="navbar navbar-expand-lg navbar-transparent navbar-absolute fixed-top ">
        <div class="container-fluid">
            <div class="navbar-wrapper">
                <a class="navbar-brand" href="#pablo"><asp:Label runat="server" ID="lblMenu" Text="" /></a>
            </div>
            <button class="navbar-toggler" type="button" data-toggle="collapse" aria-controls="navigation-index" aria-expanded="false" aria-label="Toggle navigation">
                <span class="sr-only">Toggle navigation</span>
                <span class="navbar-toggler-icon icon-bar"></span>
                <span class="navbar-toggler-icon icon-bar"></span>
                <span class="navbar-toggler-icon icon-bar"></span>
            </button>
            <div class="collapse navbar-collapse justify-content-end">
                <form class="navbar-form">
                    <div class="input-group no-border">
                        <input type="text" value="" class="form-control" placeholder="Search...">
                        <button type="submit" class="btn btn-white btn-round btn-just-icon">
                            <i class="material-icons">search</i>
                            <div class="ripple-container"></div>
                        </button>
                    </div>
                </form>
                <ul class="navbar-nav">
                    <li class="nav-item">
                        <a class="nav-link" href="#pablo">
                            <i class="material-icons">dashboard</i>
                            <p class="d-lg-none d-md-block">
                            Stats
                            </p>
                        </a>
                    </li>
                    <li class="nav-item dropdown">
                        <a class="nav-link" href="http://example.com" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <i class="material-icons">notifications</i>
                            <span class="notification">5</span>
                            <p class="d-lg-none d-md-block">
                            Some Actions
                            </p>
                        </a>
                        <div class="dropdown-menu dropdown-menu-right" aria-labelledby="navbarDropdownMenuLink">
                            <a class="dropdown-item" href="#">Mike John responded to your email</a>
                            <a class="dropdown-item" href="#">You have 5 new tasks</a>
                            <a class="dropdown-item" href="#">You're now friend with Andrew</a>
                            <a class="dropdown-item" href="#">Another Notification</a>
                            <a class="dropdown-item" href="#">Another One</a>
                        </div>
                    </li>
                    <li class="nav-item dropdown">
                        <a class="nav-link" href="#pablo" id="navbarDropdownProfile" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <i class="material-icons">person</i>
                            <p class="d-lg-none d-md-block">
                            Account
                            </p>
                        </a>
                        <div class="dropdown-menu dropdown-menu-right" aria-labelledby="navbarDropdownProfile">
                            <a class="dropdown-item" href="#">Profile</a>
                            <a class="dropdown-item" href="#">Settings</a>
                            <div class="dropdown-divider"></div>
                            <a class="dropdown-item" href="/logout">Log out</a>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
    <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="card ">
                        <div class="card-header card-header-rose card-header-text">
                            <div class="card-text">
                                <h4 class="card-title">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</h4>
                            </div>
                        </div>
                        <div class="card-body ">
                            <form method="post" class="form-horizontal" autocomplete="off" runat="server">
                                <input type="hidden" id="txtId" value="" runat="server">
                                <div class="row">
                                    <label class="col-sm-2 col-form-label">Nama</label>
                                    <div class="col-sm-10">
                                        <div class="form-group">
                                            <input type="text" class="form-control" id="txtName" value="" runat="server">
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <label class="col-sm-2 col-form-label">Jumlah Lembar Saham</label>
                                    <div class="col-sm-10">
                                        <div class="form-group">
                                            <input type="number" class="form-control" id="txtJumlahSaham" value="" runat="server">
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <label class="col-sm-2 col-form-label">Total</label>
                                    <div class="col-sm-10">
                                        <div class="form-group">
                                            <input type="text" class="duit form-control" id="txtTotal" value="" runat="server">
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <label class="col-sm-2 col-form-label">Persentase</label>
                                    <div class="col-sm-10">
                                        <div class="form-group">
                                            <input type="text" class="form-control" id="txtPersentase" value="" runat="server">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPersentase"
                                                        ErrorMessage="Required" ForeColor="Red" Display="Dynamic" ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                                    <!-- Your Regular Expression Validator -->
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                                        ControlToValidate="txtPersentase" ValidationGroup="Insert" ForeColor="Red"
                                                        runat="server" Display="Dynamic"
                                                        ErrorMessage="'Premium' must be decimal"
                                                        ValidationExpression="^\d+([,\.]\d{1,2})?$">
                                            </asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                </div>                                                                
                                <div class="row">
                                    <label class="col-sm-2 col-form-label label-checkbox">&nbsp;</label>
                                    <div class="col-sm-10 checkbox-radios">
                                        <div class="form-check form-check-inline">
                                            <asp:Button type="submit" class="btn btn-success btn-round" onclick="btnSubmit_Click" Text="Save" runat="server"/>
                                            <button type="reset" class="btn btn-warning btn-round">Reset</button>
                                            <button type="button" class="btn btn-danger btn-round" onclick="javascript:backAdd();">Cancel</button>
                                        </div>
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
