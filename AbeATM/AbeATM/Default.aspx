﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AbeATM._Default" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <script>
        var QuantityStr = '';
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlStep1" runat="server" Width="100%">
                <div class="centered">
                    <asp:LinkButton ID="cmdSell" runat="server" CssClass="button bigButton" OnClick="cmdSell_Click">Sell Bitcoin</asp:LinkButton>
                    <br /><br /><br /><br />
                    <asp:LinkButton ID="cmdBuy" runat="server" CssClass="button bigButton">Buy Bitcoin</asp:LinkButton>
                    <br /><br /><br /><br />
                    <asp:LinkButton ID="cmdCashout" runat="server" CssClass="button bigButton">Get Your Cash</asp:LinkButton>
                    <br /><br /><br /><br />
                </div>
            </asp:Panel>

            <asp:Panel ID="pnlSell_Step1" runat="server" Visible="false">
                <div>
                    <h3><asp:Label ID="lblSellHowMany" runat="server" Text=""></asp:Label></h3>
                    <br />
                    <asp:Label ID="lblSellBtcCurrencyMark" runat="server" Text=""></asp:Label>
                    <asp:TextBox ID="txtSellQuantity" runat="server" CssClass="quantityText"></asp:TextBox>
                    <br /><br />
                    <a href="#" class="button singleButton">7</a>
                    
                    <a href="#" class="button singleButton">8</a>
                    <a href="#" class="button singleButton">9</a>
                    <br />
                    <a href="#" class="button singleButton">4</a>
                    <a href="#" class="button singleButton">5</a>
                    <a href="#" class="button singleButton">6</a>
                    <br />
                    <a href="#" class="button singleButton">1</a>
                    <a href="#" class="button singleButton">2</a>
                    <a href="#" class="button singleButton">3</a>
                    <br />
                    <a href="#" class="button singleButtonDel">&lt;</a>
                    <a href="#" class="button singleButton">0</a>
                    <a href="#" class="button singleButton">.</a>
                    <br /><br />
                    <asp:Button ID="cmdSetBtcSellQuantity" runat="server" Text="Next" />
                </div>
            </asp:Panel>
            
            <asp:Panel ID="pnlSell_Step2" runat="server" Visible="false">
                <h3>We suggest the following:</h3>
                <ol class="round">
                    <li class="one">
                        <h5>Getting Started</h5>
                        ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
                        A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
                        <a href="http://go.microsoft.com/fwlink/?LinkId=245146">Learn more…</a>
                    </li>
                    <li class="two">
                        <h5>Add NuGet packages and jump-start your coding</h5>
                        NuGet makes it easy to install and update free libraries and tools.
                        <a href="http://go.microsoft.com/fwlink/?LinkId=245147">Learn more…</a>
                    </li>
                    <li class="three">
                        <h5>Find Web Hosting</h5>
                        You can easily find a web hosting company that offers the right mix of features and price for your applications.
                        <a href="http://go.microsoft.com/fwlink/?LinkId=245143">Learn more…</a>
                    </li>
                </ol>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script>
        $(function ()
        {
            $(document).on("click", ".singleButton", function ()
            {
                QuantityStr += $(this).html();
                $('#MainContent_txtSellQuantity').val(QuantityStr);
            });
        });

        $(function () {
            $(document).on("click", ".singleButtonDel", function () {
                QuantityStr = QuantityStr.substr(0, QuantityStr.length - 1);
                $('#MainContent_txtSellQuantity').val(QuantityStr);
            });
        });
    </script>

</asp:Content>