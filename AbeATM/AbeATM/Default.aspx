<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AbeATM._Default" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <script>
        var SellPinStr = '';
        var CancelPinStr = '';
        var BuyQuanityStr = '';
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlStep1" runat="server" Width="100%">
                <div class="centered">
                    <asp:LinkButton ID="cmdSell" runat="server" CssClass="button bigButton" OnClick="cmdSell_Click">Sell Bitcoin</asp:LinkButton>
                    <br /><br />
                    <asp:LinkButton ID="cmdBuy" runat="server" CssClass="button bigButton" OnClick="cmdBuy_Click">Buy Bitcoin</asp:LinkButton>
                    <br /><br />
                    <asp:LinkButton ID="cmdCashout" runat="server" CssClass="button bigButton" OnClick="cmdCashout_Click">Get Your Cash</asp:LinkButton>
                    <br /><br />
                    <asp:LinkButton ID="cmdCancelTransaction" runat="server" CssClass="button bigButton" OnClick="cmdCancelTransaction_Click">Return Cash</asp:LinkButton>
                    <br /><br />
                </div>
            </asp:Panel>

            <asp:Panel ID="pnlSell_Step1" runat="server" Visible="false">
                <div class="centered">
                    <asp:LinkButton ID="cmdHaveApp" runat="server" CssClass="button bigButton" OnClick="cmdHaveApp_Click">Have ABE App</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="cmdNeedApp" runat="server" CssClass="button bigButton" OnClick="cmdNeedApp_Click">Need ABE App</asp:LinkButton>
                </div>
            </asp:Panel>
            
            <asp:Panel ID="pnlNeedApp" runat="server" Visible="false">
                <div class="centered">
                    <h5>Use this code to download ABE</h5><br />
                    <br />
                    <img src="Images/AppQRCode.png" />
                    <br /><br />
                    <a href="Default.aspx" class="button bigButton">Finished</a>
                </div>
            </asp:Panel>
            
            <asp:Panel ID="pnlHaveApp" runat="server" Visible="false">
                <div class="centered">
                    <h5>Open ABE Mobile to Complete Your Transaction</h5>
                    <br /><br />
                    <h4>ABE Location ID: 2364</h4>
                    <br /><br />
                    <a href="Default.aspx" class="button bigButton">Finished</a>
                </div>
            </asp:Panel>
            
            <asp:Panel ID="pnlGetYourCash" runat="server" Visible="false">
                <div class="centered">
                    <h3>Please Enter Your Seller's PIN</h3>
                    <br />
                    <asp:TextBox ID="txtCashoutPIN" runat="server" MaxLength="6" CssClass="quantityText"></asp:TextBox>
                    <br />
                    <a href="#" class="button singleButton cashPin">7</a>
                    <a href="#" class="button singleButton cashPin">8</a>
                    <a href="#" class="button singleButton cashPin">9</a>
                    <br />
                    <a href="#" class="button singleButton cashPin">4</a>
                    <a href="#" class="button singleButton cashPin">5</a>
                    <a href="#" class="button singleButton cashPin">6</a>
                    <br />
                    <a href="#" class="button singleButton cashPin">1</a>
                    <a href="#" class="button singleButton cashPin">2</a>
                    <a href="#" class="button singleButton cashPin">3</a>
                    <br />
                    <a href="#" class="button singleButton cashPinDel">&lt;</a>
                    <a href="#" class="button singleButton cashPin">0</a>
                    <a href="#" class="button singleButton cashPin">.</a>
                    <br /><br />
                    <asp:Button ID="cmdPinFinished" runat="server" Text="Finished" CssClass="button" OnClick="cmdPinFinished_Click" />
                    <br />
                    <asp:Label ID="lblPinMsg" runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label>
                </div>
            </asp:Panel>

            <asp:Panel ID="pnlCancelTransaction" runat="server" Visible="false">
                <div class="centered">
                    <h3>Please Enter Your PIN</h3>
                    <br />
                    <asp:TextBox ID="txtCancelPin" runat="server" MaxLength="6" CssClass="quantityText"></asp:TextBox>
                    <br /><br />
                    <a href="#" class="button singleButton cancelPin">7</a>
                    <a href="#" class="button singleButton cancelPin">8</a>
                    <a href="#" class="button singleButton cancelPin">9</a>
                    <br />
                    <a href="#" class="button singleButton cancelPin">4</a>
                    <a href="#" class="button singleButton cancelPin">5</a>
                    <a href="#" class="button singleButton cancelPin">6</a>
                    <br />
                    <a href="#" class="button singleButton cancelPin">1</a>
                    <a href="#" class="button singleButton cancelPin">2</a>
                    <a href="#" class="button singleButton cancelPin">3</a>
                    <br />
                    <a href="#" class="button singleButton cancelPinDel">&lt;</a>
                    <a href="#" class="button singleButton cancelPin">0</a>
                    <a href="#" class="button singleButton cancelPin">.</a>
                    <br /><br />
                    <asp:Button ID="cmdCancelFinished" runat="server" Text="Cancel Transaction" CssClass="button" OnClick="cmdCancelFinished_Click" />
                    <br />
                    <asp:Label ID="lblCancelMsg" runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label>
                </div>
            </asp:Panel>
            
            <asp:Panel ID="pnlPinFinished" runat="server" Visible="false">
                <div class="centered">
                    <h2>Thank you for using ABE</h2>
                    <br /><br />
                    <img src="Images/chevy-chase-atm-o.gif" />
                    <br />
                </div>
            </asp:Panel>
             
            <asp:Panel ID="pnlCancelFinished" runat="server" Visible="false">
                <div class="centered">
                    <h2>Thank you for using ABE</h2>
                    <br /><br />
                    <h3>Your Transaction Has Been Cancelled</h3>
                    <br /><br />
                    <img src="Images/chevy-chase-atm-o.gif" />
                    <br />
                </div>
            </asp:Panel>

            <asp:Panel ID="pnlBuyStep1" runat="server" Visible="false">
                <div class="centered">
                    <h3>How Many Bitcoins Do You Want to Buy?</h3>
                    <h5><asp:Label ID="lblRates" runat="server" Text=""></asp:Label></h5>
                    <asp:TextBox ID="txtBuyQuantity" runat="server" CssClass="quantityText"></asp:TextBox>
                    <br />
                    <a href="#" class="button singleButton buyQuantity">7</a>
                    <a href="#" class="button singleButton buyQuantity">8</a>
                    <a href="#" class="button singleButton buyQuantity">9</a>
                    <br />
                    <a href="#" class="button singleButton buyQuantity">4</a>
                    <a href="#" class="button singleButton buyQuantity">5</a>
                    <a href="#" class="button singleButton buyQuantity">6</a>
                    <br />
                    <a href="#" class="button singleButton buyQuantity">1</a>
                    <a href="#" class="button singleButton buyQuantity">2</a>
                    <a href="#" class="button singleButton buyQuantity">3</a>
                    <br />
                    <a href="#" class="button singleButton buyQuantityDel">&lt;</a>
                    <a href="#" class="button singleButton buyQuantity">0</a>
                    <a href="#" class="button singleButton buyQuantity">.</a>
                    <br />
                    <asp:Button ID="cmdBuyNext" runat="server" Text="Next" CssClass="button" OnClick="cmdBuyNext_Click" />
                </div>
            </asp:Panel>
            
            <asp:Panel ID="pnlBuyInsertCash" runat="server" Visible="false">
                <div class="centered">
                    <h2>Please Insert <asp:Label ID="lblDollarAmount" runat="server" Text=""></asp:Label></h2>
                    <br /><br />
                    <img src="Images/show_me_money.gif" />
                    <br /><br />
                    <asp:Button ID="cmdBuyFinished" runat="server" CssClass="button" Text="Finished" OnClick="cmdBuyFinished_Click" />
                </div>
            </asp:Panel>

            <asp:Panel ID="pnlBuyFinished" runat="server" Visible="false">
                <div class="centered">
                    <h2>Scan With Your Camera to Deposit to Your Wallet</h2>
                    <br /><br />
                    <asp:ImageButton ID="cmdQR" runat="server" ImageUrl="~/Images/QRCodeCamera.png" OnClick="cmdQR_Click" />
                    <br /><br />
                </div>
            </asp:Panel>

            <asp:Panel ID="pnlFundingFinished" runat="server" Visible="false">
                <div class="centered">
                    <h2>Thank you.</h2>
                    <br />
                    <h2>Your wallet will be funded momentarily</h2>
                </div>
            </asp:Panel>

        </ContentTemplate>
    </asp:UpdatePanel>

    <script>
        $(function ()
        {
            $(document).on("click", ".cashPin", function ()
            {
                SellPinStr += $(this).html();
                $('#MainContent_txtCashoutPIN').val(SellPinStr);
            });
        });

        $(function () {
            $(document).on("click", ".cashPinDel", function () {
                SellPinStr = SellPinStr.substr(0, SellPinStr.length - 1);
                $('#MainContent_txtCashoutPIN').val(SellPinStr);
            });
        });

        $(function () {
            $(document).on("click", ".cancelPin", function () {
                CancelPinStr += $(this).html();
                $('#MainContent_txtCancelPin').val(CancelPinStr);
            });
        });

        $(function () {
            $(document).on("click", ".cancelPinDel", function () {
                CancelPinStr = CancelPinStr.substr(0, CancelPinStr.length - 1);
                $('#MainContent_txtCancelPin').val(CancelPinStr);
            });
        });

        $(function () {
            $(document).on("click", ".buyQuantity", function () {
                BuyQuanityStr += $(this).html();
                $('#MainContent_txtBuyQuantity').val(BuyQuanityStr);
            });
        });

        $(function () {
            $(document).on("click", ".buyQuantityDel", function () {
                BuyQuanityStr = BuyQuanityStr.substr(0, BuyQuanityStr.length - 1);
                $('#MainContent_txtBuyQuantity').val(BuyQuanityStr);
            });
        });
    </script>

</asp:Content>
