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

        // TODO: these need to go to the viewstate
        private static float BtcQuantityToSell = 0;
        private static bool IsBtcSellStep1 = true;

        // TODO: get this exchange rate from the server
        private float OneBtcRate = 290;

        // Variables
        #endregion

        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (! IsPostBack)
            {
                // do reset
                BtcQuantityToSell = 0;
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
            this.pnlSell_Step2.Visible = false;
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

            this.lblSellHowMany.Text = "How many <strong>Bitcoins</strong> to sell";
            this.lblSellBtcCurrencyMark.Text = "BTC&nbsp;";
            this.txtSellQuantity.Text = string.Empty;
            BtcQuantityToSell = 0;
            IsBtcSellStep1 = true;


            this.pnlSell_Step1.Visible = true;
        }

        #endregion

        #region cmdSetBtcSellQuantity_Click

        /// <summary>
        /// user clicked btc sell amount - Next
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cmdSetBtcSellQuantity_Click(object sender, EventArgs e)
        {
            // exit if nothing in text
            if (string.IsNullOrEmpty(this.txtSellQuantity.Text))
                return;

            // BTC to sell
            if (IsBtcSellStep1)
            {
                // exit if we can't convert
                float BtcToSell = 0;
                if (!float.TryParse(this.txtSellQuantity.Text, out BtcToSell))
                    return;

                // set the value
                BtcQuantityToSell = BtcToSell;

                // set the labels so we can go to step 2
                this.lblSellHowMany.Text = "How much to sell them for?";
                this.lblSellBtcCurrencyMark.Text = "$&nbsp;";
                this.txtSellQuantity.Text = (OneBtcRate * BtcQuantityToSell).ToString("N2");
                BtcQuantityToSell = 0;
                IsBtcSellStep1 = false;
                return;
            }

            // step 2 of sell
            // TODO: save and load next panel
        }
        #endregion
    }
}