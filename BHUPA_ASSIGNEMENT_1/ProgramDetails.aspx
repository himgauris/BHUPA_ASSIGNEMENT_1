<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ProgramDetails.aspx.cs" Inherits="BHUPA_ASSIGNEMENT_1.ProgramDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row">
        <div class="col-md-4">
            <h2><asp:Literal ID="ProgramName" runat="server" /></h2>
            <p>
               <asp:Literal ID="Description" runat="server" />
            </p>
            <p>
                <asp:Literal ID="StartTime" runat="server" />
                <asp:Literal ID="EndTime" runat="server" />
            </p>
            <p>
                <asp:Literal ID="ProgramImage" runat="server" />
                <%--<img alt="<%# Eval("Name") %>" src="<%# Eval("ProgramImage") %>" width="95" height="142" class="media-object">--%>
            </p>
                        
        </div>
    </div>
</asp:Content>