<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PreviewMitra.aspx.cs" Inherits="Penjaminan.Penjaminan.PreviewMitra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script>
       
        
        function hello(){
            window.location.replace(window.location.origin + '/Penjaminan/ViewMitra');
        }
        function download(id) {
            window.location.replace(window.location.origin + '/Penjaminan/PreviewMitra?eType=download&eID=' + id);

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
                        <a class="nav-link" href="#" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
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
    <!-- End Navbar -->
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
                            <form method="post" runat="server" class="form-horizontal" autocomplete="off">
                                <div class="row">
                                    <label class="col-sm-2 col-form-label">Nama Calon Mitra / Mitra</label>
                                    <div class="col-sm-10">
                                        <div class="form-group">
                                            <input type="text" class="form-control" id="txtCalonMitra" runat="server" value="" readonly="readonly">
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <label class="col-sm-2 col-form-label">Status Mitra</label>
                                    <div class="col-sm-10 checkbox-radios">
                                        <div class="form-check form-check-inline">
                                            <label class="form-check-label">
                                                <input class="form-check-input" type="radio" id="txtStatusB" runat="server" value="B" disabled> Baru
                                                <span class="form-check-sign">
                                                    <span class="check"></span>
                                                </span>
                                            </label>
                                        </div>
                                        <div class="form-check form-check-inline">
                                            <label class="form-check-label">
                                                <input class="form-check-input" type="radio" id="txtStatusE" runat="server" value="E" disabled> Existing
                                                <span class="form-check-sign">
                                                    <span class="check"></span>
                                                </span>
                                            </label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="card">
                                            <div class="card-header card-header-success card-header-icon">
                                                <div class="card-icon">
                                                    <i class="material-icons">assignment</i>
                                                </div>
                                                <h4 class="card-title">Bidang Usaha</h4>
                                            </div>
                                            <div class="card-body">
                                                <div class="table-responsive">
                                                    <table class="table">
                                                        <thead>
                                                            <tr>
                                                                <th class="text-center">#</th>
                                                                <th><strong>Bidang Usaha</strong></th>
                                                                <%--<th class="td-actions text-right" width="150px">Actions--%>
                                                               <%-- <% if (Session["tBidangUsahaList"] != null) { %>
                                                                <% int i = 0; %>
                                                                <% foreach (Penjaminan.Object.t_bidangusaha tbu in (List<Penjaminan.Object.t_bidangusaha>)Session["tBidangUsahaList"]) { %>
                                                                   <% i++; %>
                                                                    <button type="button" rel="tooltip" class="btn btn-success" onclick="javascript:addBidangUsaha(<%= tbu.fk_mitra %>);">                                                                                                                                        
                                                                        <i class="material-icons">add</i>
                                                                    </button>
                                                                    <% break; %>
                                                                     <% } %>
                                                                   
                                                               <% } %>
                                                               <%else { %>
                                                                    <button type="button" rel="tooltip" class="btn btn-success" onclick="javascript:addBidangUsaha(0);">                                                                                                                                        
                                                                        <i class="material-icons">add</i>
                                                                    </button>
                                                               <%} %>--%>
                                                                <%--</th>--%>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <% if (Session["tBidangUsahaList"] != null) { %>
                                                                <% int i = 0; %>
                                                                <% foreach (Penjaminan.Object.t_bidangusaha tbu in (List<Penjaminan.Object.t_bidangusaha>) Session["tBidangUsahaList"]) { %>
                                                                    <% i++; %>
                                                                    <tr>
                                                                        <td class="text-center"><%= i %></td>
                                                                        <td><%= tbu.name_bidangusaha %></td>
                                                                        <%--<td class="td-actions text-right">
                                                                            <button type="button" rel="tooltip" class="btn btn-success" onclick="javascript:editBidangUsaha(<%= tbu.fk_bidangusaha %>);">
                                                                                <i class="material-icons">edit</i>
                                                                            </button>
                                                                            <button type="button" rel="tooltip" class="btn btn-danger" onclick="javascript:deleteBidangUsaha(<%= tbu.fk_bidangusaha %>);">
                                                                                <i class="material-icons">delete</i>
                                                                            </button>
                                                                        </td>--%>
                                                                    </tr>
                                                                <% } %>
                                                            <% } %>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <label class="col-sm-2 col-form-label">Latar Belakang Perusahaan</label>
                                    <div class="col-sm-10">
                                        <div class="form-group">
                                            <textarea class="form-control" id="txtLatarBelakang" runat="server" value="" rows="6" readonly="readonly"></textarea>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="card">
                                            <div class="card-header card-header-success card-header-icon">
                                                <div class="card-icon">
                                                    <i class="material-icons">assignment</i>
                                                </div>
                                                <h4 class="card-title">Pekerjaan yang Telah dilakukan</h4>
                                            </div>
                                            <div class="card-body">
                                                <div class="table-responsive">
                                                    <table class="table">
                                                        <thead>
                                                            <tr>
                                                                <th class="text-center">#</th>
                                                                <th  class="text-center"><strong>Pekerjaan</strong></th>
                                                                <th  class="text-center"><strong>Lokasi</strong></th>
                                                                <th  class="text-center"><strong>Tanggal Pelaksanaan</strong></th>
                                                                <th  class="text-center"><strong>Nilai</strong></th>
                                                                <th  class="text-center"><strong>Tanggal Serah</strong></th>
                                                                <%--<th class="td-actions text-right" width="150px">Actions

                                                                <% if (Session["tWorkDoneList"] != null) { %>                                                               
                                                                <% foreach (Penjaminan.Object.WorkDone2 wd in (List<Penjaminan.Object.WorkDone2>) Session["tWorkDoneList"]) { %>
                                                                
                                                                    <button type="button" rel="tooltip" class="btn btn-success" onclick="javascript:addWorkDone(<%= wd.fk_mitra %>);">
                                                                        <i class="material-icons">add</i>
                                                                    </button>
                                                                    <% break; %>
                                                                     <% } %>
                                                            <% } %> 
                                                                     <%else { %>
                                                                     <button type="button" rel="tooltip" class="btn btn-success" onclick="javascript:addWorkDone(0);">
                                                                        <i class="material-icons">add</i>
                                                                    </button>
                                                               <%} %>
                                                                </th>--%>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <% if (Session["tWorkDoneList"] != null) { %>
                                                                <% int w = 0; %>
                                                                <% foreach (Penjaminan.Object.WorkDone2 wd in (List<Penjaminan.Object.WorkDone2>) Session["tWorkDoneList"]) { %>
                                                                    <% w++; %>
                                                                    <tr>
                                                                        <td class="text-center"><%= w %></td>
                                                                        <td  class="text-center"><%= wd.namapaket %></td>
                                                                        <td  class="text-center"><%= wd.lokasi %></td>
                                                                        <td  class="text-center"><%= wd.tanggalpelaksanaan %></td>
                                                                        <td  class="text-center"><%= wd.nilai %></td>
                                                                        <td  class="text-center"><%= wd.tanggalserah %></td>
                                                                        <%--<td class="td-actions text-right">
                                                                            <button type="button" rel="tooltip" class="btn btn-success" onclick="javascript:editWorkDone(<%= wd.id %>);">
                                                                                <i class="material-icons">edit</i>
                                                                            </button>
                                                                            <button type="button" rel="tooltip" class="btn btn-danger" onclick="javascript:deleteWorkDone(<%= wd.id %>);">
                                                                                <i class="material-icons">delete</i>
                                                                            </button>
                                                                        </td>--%>
                                                                    </tr>
                                                                <% } %>
                                                            <% } %>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="card">
                                            <div class="card-header card-header-success card-header-icon">
                                                <div class="card-icon">
                                                    <i class="material-icons">assignment</i>
                                                </div>
                                                <h4 class="card-title">Pekerjaan yang Sedang dilakukan</h4>
                                            </div>
                                            <div class="card-body">
                                                <div class="table-responsive">
                                                    <table class="table">
                                                        <thead>
                                                            <tr>
                                                                <th class="text-center">#</th>
                                                                <th  class="text-center"><strong>Pekerjaan</strong></th>
                                                                <th  class="text-center"><strong>Lokasi</strong></th>
                                                                <th  class="text-center"><strong>Tanggal Pelaksanaan</strong></th>
                                                                <th  class="text-center"><strong>Nilai</strong></th>
                                                                <th  class="text-center"><strong>Tanggal Serah</strong></th>
                                                                <%--<th class="td-actions text-right" width="150px">Actions
                                                                <% if (Session["tWorkProgressList"] != null) { %>
                                                                <% foreach (Penjaminan.Object.WorkProgress wp in (List<Penjaminan.Object.WorkProgress>) Session["tWorkProgressList"]) { %>
                                                                                                                                     
                                                                    <button type="button" rel="tooltip" class="btn btn-success" onclick="javascript:addWorkProgress(<%= wp.fk_mitra %>);">
                                                                        <i class="material-icons">add</i>
                                                                    </button>
                                                                 <% break; %>
                                                                 <% } %>
                                                            <% } %>
                                                                      <%else { %>
                                                                    <button type="button" rel="tooltip" class="btn btn-success" onclick="javascript:addWorkProgress(0);">
                                                                        <i class="material-icons">add</i>
                                                                    </button>
                                                               <%} %>
                                                                </th>--%>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <% if (Session["tWorkProgressList"] != null) { %>
                                                                <% int x = 0; %>
                                                                <% foreach (Penjaminan.Object.WorkProgress wd in (List<Penjaminan.Object.WorkProgress>) Session["tWorkProgressList"]) { %>
                                                                    <% x++; %>
                                                                    <tr>
                                                                        <td class="text-center"><%= x %></td>
                                                                        <td  class="text-center"><%= wd.namapaket %></td>
                                                                        <td  class="text-center"><%= wd.lokasi %></td>
                                                                        <td  class="text-center"><%= wd.tanggalpelaksanaan %></td>
                                                                        <td  class="text-center"><%= wd.nilai %></td>
                                                                        <td  class="text-center"><%= wd.tanggalserah %></td>
                                                                        <%--<td class="td-actions text-right">
                                                                            <button type="button" rel="tooltip" class="btn btn-success" onclick="javascript:editWorkProgress(<%= wd.id %>);">
                                                                                <i class="material-icons">edit</i>
                                                                            </button>
                                                                            <button type="button" rel="tooltip" class="btn btn-danger" onclick="javascript:deleteWorkProgress(<%= wd.id %>);">
                                                                                <i class="material-icons">delete</i>
                                                                            </button>
                                                                        </td>--%>
                                                                    </tr>
                                                                <% } %>
                                                            <% } %>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="card">
                                            <div class="card-header card-header-info card-header-icon">
                                                <div class="card-icon">
                                                    <i class="material-icons">assignment</i>
                                                </div>
                                                <h4 class="card-title">PIC</h4>
                                            </div>
                                            <div class="card-body">
                                                <div class="table-responsive">
                                                    <table class="table">
                                                        <thead>
                                                            <tr>
                                                                <th class="text-center">#</th>
                                                                <th class="text-center"><strong>Name</strong></th>
                                                                <th class="text-center"><strong>Jabatan</strong></th>
                                                                <th class="text-center" ><strong>No Telepon</strong></th>
                                                                <th class="text-center"><strong>Email</strong></th>
                                                                <%--<th class="td-actions text-right" width="150px">Actions
                                                                <% if (Session["tPicList"] != null) { %>
                                                                <% foreach (Penjaminan.Object.Pic pic in (List<Penjaminan.Object.Pic>) Session["tPicList"]) { %>                                                                   
                                                                    <button type="button" rel="tooltip" class="btn btn-success" onclick="javascript:addPic(<%= pic.fk_mitra %>);">
                                                                    <i class="material-icons">add</i>
                                                                    </button>
                                                                     <% break; %>
                                                                 <% } %>
                                                            <% } %>
                                                                     <%else { %>
                                                                    <button type="button" rel="tooltip" class="btn btn-success" onclick="javascript:addPic(0);">
                                                                    <i class="material-icons">add</i>
                                                                    </button>
                                                               <%} %>
                                                                </th>--%>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <% if (Session["tPicList"] != null) { %>
                                                                <% int c = 0; %>
                                                                <% foreach (Penjaminan.Object.Pic pic in (List<Penjaminan.Object.Pic>) Session["tPicList"]) { %>
                                                                    <% c++; %>
                                                                    <tr>
                                                                        <td class="text-center"><%= c %></td>
                                                                        <td class="text-center"><%= pic.name %></td>
                                                                        <td class="text-center"><%= pic.jabatan %></td>
                                                                        <td class="text-center"><%= pic.noTelepon %></td>
                                                                        <td class="text-center"><%= pic.email %></td>
                                                                        <%--<td class="td-actions text-right">
                                                                            <button type="button" rel="tooltip" class="btn btn-success" onclick="javascript:editPic(<%= pic.id %>);">
                                                                                <i class="material-icons">edit</i>
                                                                            </button>
                                                                            <button type="button" rel="tooltip" class="btn btn-danger" onclick="javascript:deletePic(<%= pic.id %>);">
                                                                                <i class="material-icons">delete</i>
                                                                            </button>
                                                                        </td>--%>
                                                                    </tr>
                                                                <% } %>
                                                            <% } %>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="card">
                                            <div class="card-header card-header-warning card-header-icon">
                                                <div class="card-icon">
                                                    <i class="material-icons">assignment</i>
                                                </div>
                                                <h4 class="card-title">Pemegang Saham</h4>
                                            </div>
                                            <div class="card-body">
                                                <div class="table-responsive">
                                                    <table class="table">
                                                        <thead>
                                                            <tr>
                                                                <th class="text-center">#</th>
                                                                <th class="text-center"><strong>Name</strong></th>
                                                                <th class="text-center"><strong>Jumlah Lembar Saham</strong></th>
                                                                <th class="text-center"><strong>Total</strong></th>
                                                                <th class="text-center""><strong>Persentase</strong></th>
                                                                <%--<th class="td-actions text-right" width="150px">Actions

                                                                    <% if (Session["tPemegangSahamList"] != null) { %>
                                                                    <% foreach (Penjaminan.Object.PemegangSaham ps in (List<Penjaminan.Object.PemegangSaham>) Session["tPemegangSahamList"]) { %>

                                                                    <button type="button" rel="tooltip" class="btn btn-success" onclick="javascript:addPemegangSaham(<%= ps.fk_mitra %>);">
                                                                    <i class="material-icons">add</i>
                                                                    </button>
                                                                      <% break; %>
                                                                     <% } %>
                                                            <% } %>
                                                                     <%else { %>
                                                                    <button type="button" rel="tooltip" class="btn btn-success" onclick="javascript:addPemegangSaham(0);">
                                                                    <i class="material-icons">add</i>
                                                                    </button>
                                                               <%} %>
                                                                </th>--%>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <% if (Session["tPemegangSahamList"] != null) { %>
                                                                <% int c = 0; %>
                                                                <% foreach (Penjaminan.Object.PemegangSaham ps in (List<Penjaminan.Object.PemegangSaham>) Session["tPemegangSahamList"]) { %>
                                                                    <% c++; %>
                                                                    <tr>
                                                                        <td class="text-center"><%= c %></td>
                                                                        <td  class="text-center"><%= ps.name %></td>
                                                                        <td  class="text-center"><%= ps.jumlah %></td>
                                                                        <td  class="text-center"><%= "Rp " +ps.total +",-" %></td>
                                                                        <td  class="text-center"><%= ps.persentase + " %" %></td>
                                                                        <%--<td class="td-actions text-right">
                                                                            <button type="button" rel="tooltip" class="btn btn-success" onclick="javascript:editPemegangSaham(<%= ps.id %>);">
                                                                                <i class="material-icons">edit</i>
                                                                            </button>
                                                                            <button type="button" rel="tooltip" class="btn btn-danger" onclick="javascript:deletePemegangSaham(<%= ps.id %>);">
                                                                                <i class="material-icons">delete</i>
                                                                            </button>
                                                                        </td>--%>
                                                                    </tr>
                                                                <% } %>
                                                            <% } %>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="card">
                                            <div class="card-header card-header-rose card-header-icon">
                                                <div class="card-icon">
                                                    <i class="material-icons">assignment</i>
                                                </div>
                                                <h4 class="card-title">Board of Director</h4>
                                            </div>
                                            <div class="card-body">
                                                <div class="table-responsive">
                                                    <table class="table">
                                                        <thead>
                                                            <tr>
                                                                <th class="text-center">#</th>
                                                                <th class="text-center"><strong>Name</strong></th>
                                                                <th class="text-center"><strong>Jabatan</strong></th>
                                                                <th class="text-center"><strong>Tanggal Lahir</strong></th>
                                                                <%--<th class="td-actions text-right">Actions
                                                                   <% if (Session["tBodList"] != null) { %>
                                                                     <% foreach (Penjaminan.Object.BoardOfDirector bod in (List<Penjaminan.Object.BoardOfDirector>) Session["tBodList"]) { %>
                                                                    <button type="button" rel="tooltip" class="btn btn-success" onclick="javascript:addBod(<%= bod.fk_mitra %>);">
                                                                        <i class="material-icons">add</i>
                                                                    </button>
                                                                     <% break; %>
                                                                     <% } %>
                                                            <% } %>
                                                                     <%else { %>
                                                                   <button type="button" rel="tooltip" class="btn btn-success" onclick="javascript:addBod(0);">
                                                                        <i class="material-icons">add</i>
                                                                    </button>
                                                               <%} %>
                                                                </th>--%>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <% if (Session["tBodList"] != null) { %>
                                                                <% int c = 0; %>
                                                                <% foreach (Penjaminan.Object.BoardOfDirector bod in (List<Penjaminan.Object.BoardOfDirector>) Session["tBodList"]) { %>
                                                                    <% c++; %>
                                                                    <tr>
                                                                        <td class="text-center"><%= c %></td>
                                                                        <td class="text-center"><%= bod.name %></td>
                                                                        <td class="text-center"><%= bod.jabatan %></td>
                                                                        <td class="text-center"><%= bod.tglLahir %></td>                                                                       
                                                                       <%-- <td class="td-actions text-right">
                                                                            <button type="button" rel="tooltip" class="btn btn-success" onclick="javascript:editBod(<%= bod.id %>);">
                                                                                <i class="material-icons">edit</i>
                                                                            </button>
                                                                            <button type="button" rel="tooltip" class="btn btn-danger" onclick="javascript:deleteBod(<%= bod.id %>);">
                                                                                <i class="material-icons">delete</i>
                                                                            </button>
                                                                        </td>--%>
                                                                    </tr>
                                                                <% } %>
                                                            <% } %>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="card">
                                            <div class="card-header card-header-rose card-header-icon">
                                                <div class="card-icon">
                                                    <i class="material-icons">assignment</i>
                                                </div>
                                                <h4 class="card-title">Checklist</h4>
                                            </div>
                                            <div class="card-body">
                                                <div class="table-responsive">
                                                    <table class="table">
                                                        <thead>
                                                            <tr>
                                                                 <% if (Session["documentDt"] != null) { %>                                                              
                                                                <% foreach (Penjaminan.Object.Checklist cek in (List<Penjaminan.Object.Checklist>)Session["documentDt"])
                                                                    { %>
                                                                        <th class="text-center" >#</th>
                                                                        <th class="text-center"><strong>Kategori</strong></th>
                                                                        <th class="text-center"><strong>Dokumen</strong></th>
                                                                    <% if (cek.fk_mitra != 0)
                                                                            { %>  
                                                                        <th class="text-center"><strong>FileName</strong></th>  
                                                                   <%} %>                                                           
                                                                       <%-- <th class="text-center" >Upload</th> --%>                                                                                                                                 
                                                                      <% if (cek.fk_mitra != 0)
                                                                            { %>          
                                                                    <th class="text-center" ><strong>Download</strong></th>
                                                                   <%} %>
                                                                  <%break; %>
                                                                  <%} %>
                                                                <%} %>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <% if (Session["documentDt"] != null) { %>
                                                                <% int c = 0; %>
                                                                <% foreach (Penjaminan.Object.Checklist cek in (List<Penjaminan.Object.Checklist>) Session["documentDt"]) { %>
                                                                    <% c++; %>                                                                  
                                                                    <tr>
                                                                        <td class="text-center"><%= c %></td>                                                                        
                                                                        <td class="text-center"><%= cek.kategoriname %></td>
                                                                        <td class="text-center"><%= cek.name %></td>      
                                                                        <td class="text-center"><%= cek.FileName %></td>                                                                                                                                          
                                                                        <%--<td class="td-actions text-right">--%>
                                                                           <%-- <asp:FileUpload  runat="server" ID="fuSample" name="fuSample" /> --%>     
                                                                          <%--  <input type="file" id="fuSample" name="fuSample" />  --%>                                                                      
                                                                             <%--  <asp:Label runat="server" ID="lblMessage" Text=""></asp:Label>--%>
                                                                        <%-- </td>   --%>
                                                                       <% if (cek.fk_mitra != 0)
                                                                            { %>                                                                                                                                            
                                                                         <td >                                                                             
                                                                            <button type="button" ID="btnDownload" rel="tooltip" class="btn btn-danger" onclick="javascript:download(<%= cek.id %>);">
                                                                              Download
                                                                            </button>                                                                             
                                                                        </td>
                                                                        <%} %>
                                                                    </tr>
                                                                <% } %>
                                                            <% } %>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                 <div class="row">
                                     <div class="col-md-12">
                                         <div>
                                            <label class="col-md-3"><strong>Alasan Persetujuan atau Penolakan</strong></label>
                                         </div>
                                         <div class="col-md-12">
                                                <div>
                                                    <input class="form-control" id="textKeterangan" runat="server" value="" rows="6" required />
                                                </div>
                                         </div>
                                      </div>                                   
                                </div>
                                <div class="row">
                                    <label class="col-sm-2 col-form-label label-checkbox">&nbsp;</label>
                                    <div class="col-sm-10 checkbox-radios">
                                        <div class="form-check form-check-inline">
                                            <asp:Button type="submit" class="btn btn-success btn-round" onclick="btnSubmit_Click" Text="Aproove" runat="server"/>
                                            <asp:Button type="submit" class="btn btn-warning btn-round" onclick="btnReject_Click" Text="Reject" runat="server" />
                                            <button type="reset" class="btn btn-danger btn-round" onclick="javascript:hello();">Cancel</button>
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