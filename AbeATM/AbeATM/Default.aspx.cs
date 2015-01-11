using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AbeATM
{
    public partial class _Default : Page
    {
        #region Variables

        // TODO: get this exchange rate from the server
        private float OneBtcRate = 277.92f;

        private const string Str_SellerPin = "314159";
        private const string Str_BuyerPin = "112358";

        // Variables
        #endregion

        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (! IsPostBack)
            {
                // do reset
            }
        }

        #endregion

        #region HidePanels

        /// <summary>
        /// Hide all panels
        /// </summary>
        private void HidePanels()
        {
            this.pnlStep1.Visible = false;
            this.pnlSell_Step1.Visible = false;
            this.pnlGetYourCash.Visible = false;
            this.pnlNeedApp.Visible = false;
            this.pnlHaveApp.Visible = false;
            this.pnlPinFinished.Visible = false;
            this.pnlCancelTransaction.Visible = false;
            this.pnlCancelFinished.Visible = false;
        }

        // HidePanels
        #endregion

        #region cmdSell_Click

        /// <summary>
        /// Go to step 1 sell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cmdSell_Click(object sender, EventArgs e)
        {
            HidePanels();
            this.pnlSell_Step1.Visible = true;
        }

        #endregion

        #region cmdNeedApp_Click

        protected void cmdNeedApp_Click(object sender, EventArgs e)
        {
            HidePanels();
            
            // show need
            this.pnlNeedApp.Visible = true;
        }
        #endregion

        #region cmdHaveApp_Click

        protected void cmdHaveApp_Click(object sender, EventArgs e)
        {
            HidePanels();

            // show have
            this.pnlHaveApp.Visible = true;
        }
        #endregion

        #region cmdPinFinished

        protected void cmdPinFinished_Click(object sender, EventArgs e)
        {
            // validate pin
            if (! this.txtCashoutPIN.Text.Equals(Str_SellerPin))
            {
                this.lblPinMsg.Text = "Invalid PIN. Please try again";
                return;
            }

            HidePanels();
            this.pnlPinFinished.Visible = true;
        }

        // cmdPinFinished
        #endregion

        #region cmdCashout_Click

        protected void cmdCashout_Click(object sender, EventArgs e)
        {
            HidePanels();
            this.pnlGetYourCash.Visible = true;
        }
        #endregion

        #region cmdCancelTransaction_Click

        protected void cmdCancelTransaction_Click(object sender, EventArgs e)
        {
            HidePanels();
            this.pnlCancelTransaction.Visible = true;
        }
        #endregion

        #region cmdCancelFinished_Click

        /// <summary>
        /// finished cancel pin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cmdCancelFinished_Click(object sender, EventArgs e)
        {
            // validate pin
            if ((!this.txtCancelPin.Text.Equals(Str_SellerPin)) && (!this.txtCancelPin.Text.Equals(Str_BuyerPin)))
            {
                this.lblCancelMsg.Text = "Invalid PIN. Please try again";
                return;
            }

            HidePanels();
            this.pnlCancelFinished.Visible = true;            
        }

        // cmdCancelFinished_Click
        #endregion
    }
}