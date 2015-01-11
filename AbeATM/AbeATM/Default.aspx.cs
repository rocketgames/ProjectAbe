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


        // Variables
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

            this.pnlSell_Step1.Visible = true;
        }

        #endregion
    }
}