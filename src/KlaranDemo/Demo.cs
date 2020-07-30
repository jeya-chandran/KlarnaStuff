using System;
using System.Diagnostics;

using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using VA.Services;
using System.IO;

namespace KlaranDemo
{
    public partial class Demo : Form
    {
        private const string CHROME = @"C:\Program Files(x86)\Google\Chrome\Application\chrome.exe";

        private readonly Context _context;
        private readonly KlarnaPaymentService _klarnaService;
        private readonly string _appPath;
        private readonly string _browserPath;

        private string _newlyCreatedKlarnaOrderId = string.Empty;

        #region Constructors

        public Demo()
        {
            InitializeComponent();

            _context = GetContext();
            _klarnaService = new KlarnaPaymentService(_context);

            _appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _browserPath = ConfigurationManager.AppSettings["Browser.Path"];
        }

        #endregion Constructors


        #region Private methods

        #region Event handlers

        private void Demo_Load(object sender, EventArgs e)
        {
            cmbLocale.SelectedIndex = 0;
            txtKlarnaOrderId.Text = _newlyCreatedKlarnaOrderId;
            lblErrorMessage.Text = "";
        }

        private async void btnPay_Click(object sender, EventArgs e)
        {
            lblErrorMessage.Text = string.Empty;

            KlarnaCreateCheckoutOrderRequest req = GetCreateOrderRequest();

            var response = await _klarnaService.CreateKlarnaCheckoutOrderAsync(req);

            txtKlarnaOrderId.Text = response.KlarnaOrderId;
            //_newlyCreatedKlarnaOrderId = response.KlarnaOrderId;
            //txtKlarnaOrderId.Text = _newlyCreatedKlarnaOrderId;

            if (string.IsNullOrEmpty(response.ErrorMessage) && response.KlarnaOrderStatus == "Created")
            {
                PrepareHtmlFile(_appPath + @"\Template.html", _appPath + @"\Checkout.html", response.HtmlSnippet);
                OpenUrl(_appPath + @"\Checkout.html");
            }
            else
            {
                lblErrorMessage.Text = response.ErrorMessage;
            }
        }

        private async void btnConfirmation_Click(object sender, EventArgs e)
        {
            lblErrorMessage.Text = string.Empty;

            var response = await _klarnaService.GetKlarnaCheckoutOrderAsync(_newlyCreatedKlarnaOrderId);

            if (string.IsNullOrEmpty(response.ErrorMessage) && response.KlarnaOrderStatus == "Retrieved")
            {
                PrepareHtmlFile(_appPath + @"\Template.html", _appPath + @"\Confirmation.html", response.HtmlSnippet);
                OpenUrl(_appPath + @"\Confirmation.html");
            }
            else
            {
                lblErrorMessage.Text = response.ErrorMessage;
            }
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            decimal amount = decimal.Parse(txtOrderAmount.Text);

            if (string.IsNullOrEmpty(txtTaxRate.Text)) txtTaxRate.Text = "0.00";

            decimal vatRate = decimal.Parse(txtTaxRate.Text);
            vatRate = vatRate + 100.00M;

            var total = (amount / 100.00M) * vatRate;
            var tax = total - amount;

            txtTotalAmount.Text = total.ToString("0.00");
            txtTaxAmount.Text = tax.ToString("0.00");
        }

        private async void btnAcknowledge_Click(object sender, EventArgs e)
        {
            lblErrorMessage.Text = string.Empty;
            var response = await _klarnaService.AcknowledgeKlarnaOrderAsync(txtKlarnaOrderId.Text);

            if (response.KlarnaOrderStatus == "Acknowledged" && string.IsNullOrEmpty(response.ErrorMessage))
            {
                MessageBox.Show("Order Acknowledged!", "Klarna Demo (POC)", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                lblErrorMessage.Text = response.ErrorMessage;
            }
        }

        private async void btnCapture_Click(object sender, EventArgs e)
        {
            lblErrorMessage.Text = string.Empty;
            var response = await _klarnaService.CreateKlarnaCaptureOrderAsync(GetCreateCaptureOrderRequest());

            if (response.KlarnaOrderStatus == "Created" && 
                !string.IsNullOrEmpty(response.CaptureId) &&
                string.IsNullOrEmpty(response.ErrorMessage))
            {
                MessageBox.Show(string.Format("Order Captured with '{0}' capture id", response.CaptureId), "Klarna Demo (POC)", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                lblErrorMessage.Text = response.ErrorMessage;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtVeritixOrderNo.Text = string.Empty;
            txtOrderAmount.Text = "100.00";
            txtTaxRate.Text = "0.00";
            txtTaxAmount.Text = string.Empty;
            txtTotalAmount.Text = string.Empty;
            cmbLocale.SelectedIndex = 0;
            txtKlarnaOrderId.Text = string.Empty;

            txtVeritixOrderNo.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtKlarnaOrderId_TextChanged(object sender, EventArgs e)
        {
            _newlyCreatedKlarnaOrderId = txtKlarnaOrderId.Text;
        }

        #endregion Event handlers

        private Context GetContext()
        {
            Context context = new Context();

            context.Properties["Klarna.BaseUrl"] = ConfigurationManager.AppSettings["Klarna.BaseUrl"];
            context.Properties["Klarna.MerchantUrl.Terms"] = ConfigurationManager.AppSettings["Klarna.MerchantUrl.Terms"];
            context.Properties["Klarna.MerchantUrl.Checkout"] = ConfigurationManager.AppSettings["Klarna.MerchantUrl.Checkout"];
            context.Properties["Klarna.MerchantUrl.Confirmation"] = ConfigurationManager.AppSettings["Klarna.MerchantUrl.Confirmation"];
            context.Properties["Klarna.MerchantUrl.Push"] = ConfigurationManager.AppSettings["Klarna.MerchantUrl.Push"];

            context.Properties["Klarna.Proxy"] = ConfigurationManager.AppSettings["Klarna.Proxy"];

            context.Properties["Klarna.MerchantId"] = ConfigurationManager.AppSettings["Klarna.MerchantId"];
            context.Properties["Klarna.Password"] = ConfigurationManager.AppSettings["Klarna.Password"];

            return (context);
        }

        private void OpenUrl(string url)
        {
            // Process.Start(url);
            var psi = new ProcessStartInfo(url);

            try
            {
                Process.Start(psi);
            }
            catch (Exception)
            {
                Process.Start(_browserPath, psi.FileName);
            }
        }

        private void PrepareHtmlFile(string source, string destination, string htmlSnippet)
        {
            string contents = File.ReadAllText(source);
            contents = contents.Replace("{KLARNA_HTML_SNIPPET_PLACEHOLDER}", htmlSnippet);
            File.WriteAllText(destination, contents);
        }

        private KlarnaCreateCheckoutOrderRequest GetCreateOrderRequest()
        {
            KlarnaCreateCheckoutOrderRequest req = new KlarnaCreateCheckoutOrderRequest();

            req.OrderId = txtVeritixOrderNo.Text;
            req.ContextId = 101010101; // AXS-UK-DEMO-GLOBAL (QA1)
            req.BillingAddress = Address.Jeya();
            req.Customer = Customer.Jeya();
            req.Locale = cmbLocale.Text;

            req.ShoppingCart = new ShoppingCart()
            {
                Total = decimal.Parse(txtTotalAmount.Text),
                Tax = decimal.Parse(txtTaxAmount.Text),
                TaxRate = decimal.Parse(txtTaxRate.Text)
            };

            return (req);
        }

        private KlarnaCreateCaptureOrderRequest GetCreateCaptureOrderRequest()
        {
            KlarnaCreateCaptureOrderRequest req = new KlarnaCreateCaptureOrderRequest();

            req.KlarnaOrderId = txtKlarnaOrderId.Text;
            req.CapturedAmount = decimal.Parse(txtTotalAmount.Text);
            req.Description = "Full capture of the order";

            return (req);
        }

        #endregion Private methods

        private void txtVeritixOrderNo_Leave(object sender, EventArgs e)
        {

        }
    }
}
