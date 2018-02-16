<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BHUPA_ASSIGNEMENT_1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>List of DD1 Programs</h1>
    </div>

    <div class="row">
        <asp:repeater ID="rptprograms" runat="server">
            <ItemTemplate>
                <div class="col-md-4">
                    <h2><%# Eval("Name") %></h2>
                    <p> Program ID
                       <a href="/ProgramDetails?id=<%# Eval("ProgramId") %>"><%# Eval("ProgramId") %></a>
                   
                    </p>
                    <p>
                       <%# Eval("Desc") %>
                    </p>
                   <p>
                       <%# Eval("StartTime") %> -
                       <%# Eval("EndTime") %>
                    </p>
                     <p>
                        <img alt="<%# Eval("Name") %>" src="<%# Eval("ProgramImage") %>" width="95" height="142" class="media-object">
                    </p>
                 
                </div>
             </ItemTemplate>
       </asp:repeater>
    </div>
    <script>

        function loadViewMoreLink() {
            $("#ViewMoreLink").each(function () {
                jQuery("#ViewMoreLink").attr('style', 'display:block;');
            });
        }
    </script>
</asp:Content>


