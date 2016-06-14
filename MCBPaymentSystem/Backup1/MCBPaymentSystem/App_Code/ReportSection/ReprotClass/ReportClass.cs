using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.ComponentModel;
using System.Text;
using System.Data;
//using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;
using System.Windows.Forms;
using Common;
using System.Configuration;
using System.Data.OracleClient;
namespace Report
{
    public class ReportClass : System.Web.UI.Page
    {
        public static IList<ReportParameter> rpParametersV1; 
        string ReportName;

        #region DBConnection
        //private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; //"Data Source=CR-ML150;Initial Catalog=cmg;User ID=sa;Password=";
        //private readonly string ConnectionString = Startup_Util.SPDS_DB.ToString();
        private readonly string ConnectionString = DAL_EXP1.Utility.Startup_Util.DB_Route;
        //private readonly string ConnectionString = "Data Source=CR-ML150;Initial Catalog=Samba_SPDS_PRE;User ID=sa;Password=";
        //private readonly string ConnectionString = "Data Source=SW-WAQAS\\SQLEXPRESS;Initial Catalog=SAMBA_SPDS_RA;User ID=sa;password=sa";
        private static DataSet StoredProceDatasetCollection = new DataSet();
        private OracleConnection DBConnection;
        public string chk = "";
        private OracleConnection ConnectionMaker()
        {
            DBConnection = new OracleConnection(ConnectionString);
            //DBConnection.Open();
            return DBConnection;

        }
        #endregion DBConnection

        #region ClassDeclerations


        dstReport dstCurrentReport = new dstReport();

        BindingSource bsrReport = new BindingSource();
        ReportDataSource dsrReport = new ReportDataSource();

        BindingSource bsrSubReport = new BindingSource();
        ReportDataSource dsrSubReport = new ReportDataSource();

        BindingSource bsrParameter = new BindingSource();
        ReportDataSource dsrParameter = new ReportDataSource();

        BindingSource bsrClient = new BindingSource();
        ReportDataSource dsrClient = new ReportDataSource();

        DatabaseConnection_Util dbConn = new DatabaseConnection_Util();

        private int m_currentPageIndex;
        private IList<Stream> m_streams;
        private IList<ReportParameter> rpParameters = new List<ReportParameter>();

        /// <summary>
        /// Start Report Parameter
        /// </summary>
        public static ReportDataSource dsrReportV;
        public static ReportDataSource dsrParameterV;
        public static string ReportNameV;
        public static bool ShowReportV;
        public static ReportDataSource dsrClientV;
        public static IList<ReportParameter> rpParametersV;
        public static int RowCount = 0;
        public static ReportDataSource dsrSubReportV;

        /// <summary>

        /// </summary>
        /// 

        private static DateTime _FromDate;
        private static DateTime _ToDate;
        private static DateTime _CurrentDate;
        private static double _FromAmount;
        private static double _ToAmount;
        private static double _Amount;
        private static string _RefNo;
        private static string _FromCode;
        private static string _AuthorizerSignature;
        private static string _ToCode;
        private static string _Code;
        private static string _Name;
        private static string _FromName;
        private static string _ToName;
        private static string _Description;
        private static string _OurBank;
        private static string _Address;
        private static string _Phone;
        private static string _Fax;
        private static string _Telex;
        private static string _Cable;
        private static string _DepartmentHead;
        private static string _Designation;
        private static string _AmountInWord;
        private static int _ID;
        private static string _PrinterName;
        private static string _FromManager;
        private static string _ToManager;
        #endregion

        #region ClassProperties



        public DateTime FromDate
        {
            set
            {
                _FromDate = value;
            }
            get
            {
                return _FromDate;
            }
        }

        public DateTime ToDate
        {
            set
            {
                _ToDate = value;
            }
            get
            {
                return _ToDate;
            }
        }

        public DateTime CurrentDate
        {
            set
            {
                _CurrentDate = value;
            }
            get
            {
                return _CurrentDate;
            }
        }

        public double FromAmount
        {
            set
            {
                _FromAmount = value;
            }
            get
            {
                return _FromAmount;
            }
        }

        public double ToAmount
        {
            set
            {
                _ToAmount = value;
            }
            get
            {
                return _ToAmount;
            }
        }

        public double Amount
        {
            set
            {
                _Amount = value;
            }
            get
            {
                return _Amount;
            }
        }

        public string RefNo
        {
            set
            {
                _RefNo = value;
            }
            get
            {
                return _RefNo;
            }
        }

        public string FromCode
        {
            set
            {
                _FromCode = value;
            }
            get
            {
                return _FromCode;
            }
        }

        public string AuthorizerSignature
        {
            set
            {
                _AuthorizerSignature = value;
            }
            get
            {
                return _AuthorizerSignature;
            }
        }

        public string ToCode
        {
            set
            {
                _ToCode = value;
            }
            get
            {
                return _ToCode;
            }
        }

        public string Code
        {
            set
            {
                _Code = value;
            }
            get
            {
                return _Code;
            }
        }

        public string Name
        {
            set
            {
                _Name = value;
            }
            get
            {
                return _Name;
            }
        }

        public string FromName
        {
            set
            {
                _FromName = value;
            }
            get
            {
                return _FromName;
            }
        }

        public string ToName
        {
            set
            {
                _ToName = value;
            }
            get
            {
                return _ToName;
            }
        }


        public string Description
        {
            set
            {
                _Description = value;
            }
            get
            {
                return _Description;
            }
        }

        public string OurBank
        {
            set
            {
                _OurBank = value;
            }
            get
            {
                return _OurBank;
            }
        }

        public string Address
        {
            set
            {
                _Address = value;
            }
            get
            {
                return _Address;
            }
        }

        public string Phone
        {
            set
            {
                _Phone = value;
            }
            get
            {
                return _Phone;
            }
        }

        public string Fax
        {
            set
            {
                _Fax = value;
            }
            get
            {
                return _Fax;
            }
        }

        public string Telex
        {
            set
            {
                _Telex = value;
            }
            get
            {
                return _Telex;
            }
        }

        public string Cable
        {
            set
            {
                _Cable = value;
            }
            get
            {
                return _Cable;
            }
        }

        public string DepartmentHead
        {
            set
            {
                _DepartmentHead = value;
            }
            get
            {
                return _DepartmentHead;
            }
        }

        public string Designation
        {
            set
            {
                _Designation = value;
            }
            get
            {
                return _Designation;
            }
        }

        public string AmountInWord
        {
            set
            {
                _AmountInWord = value;
            }
            get
            {
                return _AmountInWord;
            }
        }

        public int ID
        {
            set
            {
                _ID = value;
            }
            get
            {
                return _ID;
            }
        }

        public string PrinterName
        {
            set
            {
                _PrinterName = value;
            }
            get
            {
                return _PrinterName;
            }
        }

        public string FromManager
        {
            set
            {
                _FromManager = value;
            }
            get
            {
                return _FromManager;
            }
        }
        public string ToManager
        {
            set
            {
                _ToManager = value;
            }
            get
            {
                return _ToManager;
            }
        }

        #endregion

        #region ClassMethods

        // Routine to provide to the report renderer, in order to
        //    save an image for each page of the report.
        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            //Stream stream = new FileStream("C:\\" + name + "." + fileNameExtension, FileMode.Create);
            Stream stream = new FileStream(@".\.\" + name + "." + fileNameExtension, FileMode.Create);
            m_streams.Add(stream);
            return stream;
        }
        // Export the given report as an EMF (Enhanced Metafile) file.
        private void Export(LocalReport report)
        {
            string deviceInfo;
            if (ReportName == "Draft")
            {
                deviceInfo =
                "<DeviceInfo>" +
                "  <OutputFormat>EMF</OutputFormat>" +
                "  <PageWidth>9in</PageWidth>" +
                "  <PageHeight>11in</PageHeight>" +
                "  <MarginTop>0.25in</MarginTop>" +
                "  <MarginLeft>0.25in</MarginLeft>" +
                "  <MarginRight>0.25in</MarginRight>" +
                "  <MarginBottom>0.25in</MarginBottom>" +
                "</DeviceInfo>";
            }
            else
            {
                deviceInfo =
                "<DeviceInfo>" +
                "  <OutputFormat>EMF</OutputFormat>" +
                "  <PageWidth>8.5in</PageWidth>" +
                "  <PageHeight>11in</PageHeight>" +
                "  <MarginTop>0.25in</MarginTop>" +
                "  <MarginLeft>0.25in</MarginLeft>" +
                "  <MarginRight>0.25in</MarginRight>" +
                "  <MarginBottom>0.25in</MarginBottom>" +
                "</DeviceInfo>";
            }
            ReportName = "";

            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("EMF", deviceInfo, CreateStream,
               out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }
        // Handler for PrintPageEvents
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
            Metafile(m_streams[m_currentPageIndex]);
            ev.Graphics.DrawImage(pageImage, ev.PageBounds);
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        private void Print()
        {
            if (m_streams == null || m_streams.Count == 0)
                return;

            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = _PrinterName;

            if (!printDoc.PrinterSettings.IsValid)
            {
                string msg = String.Format(
                   "Can't find printer \"{0}\".", _PrinterName);
                MessageBox.Show(msg, "Print Error");
                return;
            }

            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
            printDoc.Print();
        }
        // Create a local report for Report.rdlc, load the data,
        //    export the report to an .emf file, and print it.
        private void Run()
        {
            LocalReport report = new LocalReport();
            report.ReportPath = @".\.\Report.rdlc";
            //report.DataSources.Add(
            //new ReportDataSource("Sales", LoadSalesData()));
            Export(report);
            m_currentPageIndex = 0;
            Print();
        }

        public void Dispose()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }

        private void SetDataSetBindingSource(string SPName)
        {
            bsrReport.DataMember = SPName;
            bsrReport.DataSource = dstCurrentReport;
            dsrReport.Name = "dstReport_" + SPName;
            dsrReport.Value = bsrReport;

            bsrParameter.DataSource = typeof(ReportClass);
            dsrParameter.Name = "ReportClass";
            dsrParameter.Value = bsrParameter;

            bsrClient.DataMember = "RPS_SP_rptCRPLClient";
            bsrClient.DataSource = dstCurrentReport;
            dsrClient.Name = "dstReport_RPS_SP_rptCRPLClient";
            dsrClient.Value = bsrClient;
            dstReportTableAdapters.RPS_SP_rptCRPLClientTableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptCRPLClientTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            dtbReport.Fill(dstCurrentReport.RPS_SP_rptCRPLClient);
        }

        private void SetDataSetBindingSource(string SPName, string SubReportSPName)
        {

            bsrReport.DataMember = SPName;
            bsrReport.DataSource = dstCurrentReport;
            dsrReport.Name = "dstReport_" + SPName;
            dsrReport.Value = bsrReport;

            if (SubReportSPName != null && SubReportSPName.Length > 0)
            {
                bsrSubReport.DataMember = SubReportSPName;
                bsrSubReport.DataSource = dstCurrentReport;
                dsrSubReport.Name = "dstReport_" + SubReportSPName;
                dsrSubReport.Value = bsrSubReport;
            }

            bsrParameter.DataSource = typeof(ReportClass);
            dsrParameter.Name = "ReportClass";
            dsrParameter.Value = bsrParameter;

            bsrClient.DataMember = "RPS_SP_rptCRPLClient";
            bsrClient.DataSource = dstCurrentReport;
            dsrClient.Name = "dstReport_RPS_SP_rptCRPLClient";
            dsrClient.Value = bsrClient;

            
            dstReportTableAdapters.RPS_SP_rptCRPLClientTableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptCRPLClientTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            dtbReport.Fill(dstCurrentReport.RPS_SP_rptCRPLClient);
        }

        private void SetReportViewer(ReportDataSource dsrReport, ReportDataSource dsrParameter, string ReportName, bool ShowReport)
        {

            /*
            ReportNameV = ReportName;
            dsrReportV  = dsrReport;
            dsrSubReportV = null; 
            dsrParameterV  = dsrParameter;
            dsrClientV  = dsrClient;
            rpParametersV  = rpParameters;
            */
            Session["ReportNameV"] = ReportName;
            Session["dsrReportV"] = dsrReport;
            Session["dsrSubReportV"] = null;
            Session["dsrParameterV"] = dsrParameter;
            Session["dsrClientV"] = dsrClient;
            Session["rpParametersV"] = rpParameters;
            Session["RowCount"] = RowCount;
            Session["rpParametersV1"] = rpParameters;
            //rpParametersV1 = rpParameters;
            if (rpParameters.Count > 0)
            {
                Session["rpParametersCount"] = rpParameters.Count;
            }
            else { Session["rpParametersCount"] = "0"; }

        }

        private void SetReportViewer(ReportDataSource dsrReport, ReportDataSource dsrSubReport, ReportDataSource dsrParameter, string ReportName, bool ShowReport)
        {
            /*
            ReportNameV = ReportName;
            dsrReportV = dsrReport;
            dsrSubReportV = dsrSubReport;
            dsrParameterV = dsrParameter;
            dsrClientV = dsrClient;
            rpParametersV = rpParameters;
            */
            Session["ReportNameV"] = ReportName;
            Session["dsrReportV"] = dsrReport;
            Session["dsrSubReportV"] = dsrSubReport;
            Session["dsrParameterV"] = dsrParameter;
            Session["dsrClientV"] = dsrClient;
            Session["rpParametersV"] = rpParameters;
            Session["RowCount"] = RowCount;

            if (rpParameters.Count > 0)
            {
                Session["rpParametersCount"] = rpParameters.Count;
            }
            else { Session["rpParametersCount"] = "0"; }

        }

        private void NoReportDataMessage()
        {
            //.Show("Report Can't be shown because there is No record in Database according to given Criteria", "iCORE RPS - Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Reports


        //public void MasterZipCodeReport(int @PrincipleBankId, bool Flag, string From, string To)
        //{
        //    SetDataSetBindingSource("RPS_SP_rptMasterZipCode");
        //    dstReportTableAdapters.RPS_SP_rptMasterZipCodeTableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptMasterZipCodeTableAdapter();
        //    dtbReport.ClearBeforeFill = true;
        //    dtbReport.Connection = ConnectionMaker();
        //    dtbReport.Fill(dstCurrentReport.RPS_SP_rptMasterZipCode, Flag, From, To);
        //    if (dstCurrentReport.RPS_SP_rptMasterZipCode.Rows.Count > 0)
        //    {
        //        RowCount = dstCurrentReport.RPS_SP_rptMasterZipCode.Rows.Count;
        //        // SetReportViewer(dsrReport, dsrParameter, @"GeneralReport\Zipcodes.rdlc", true);
        //        SetReportViewer(dsrReport, dsrParameter, @"GeneralReport\Report.rdlc", true);
        //    }
        //    else
        //    {
        //        RowCount = 0;
        //        NoReportDataMessage();
        //    }
        //}


        public void HoldDraftReports(int @PrincipleBankId, string @FromDate, string @ToDate, bool ShowReport)
        {
            SetDataSetBindingSource("RPS_SP_rptHoldDrafts");
            dstReportTableAdapters.RPS_SP_rptHoldDraftsTableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptHoldDraftsTableAdapter();

            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();

            dtbReport.Fill(dstCurrentReport.RPS_SP_rptHoldDrafts, @PrincipleBankId, @FromDate, @ToDate);

            rpParameters.Add(new ReportParameter("FromDate", FromDate));
            rpParameters.Add(new ReportParameter("ToDate", ToDate));
            rpParameters.Add(new ReportParameter("CustomerName", Name));

            if (dstCurrentReport.RPS_SP_rptHoldDrafts.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.RPS_SP_rptHoldDrafts.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"GeneralReport\HoldDrafts\HoldDrafts.rdlc", ShowReport);
            }
            else
            {
                Session["RowCount"] = 0;
                RowCount = 0;
                NoReportDataMessage();
            }
        }
        public void DraftDetailReport(int @PrincipleBankId, int @CorrespondingBankId, string @CurrentDate, string @FromDate, string @ToDate, bool ShowReport)
        {
            SetDataSetBindingSource("RPS_SP_rptDraftDetail");
            dstReportTableAdapters.RPS_SP_rptDraftDetailTableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptDraftDetailTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;

            dtbReport.Fill(dstCurrentReport.RPS_SP_rptDraftDetail, @PrincipleBankId, @CorrespondingBankId, @CurrentDate, @FromDate, @ToDate);

            if (dstCurrentReport.RPS_SP_rptCRPLClient.Rows.Count>0)
            {
            rpParameters.Add(new ReportParameter("ClientName", dstCurrentReport.RPS_SP_rptCRPLClient.Rows[0]["Client Name"].ToString()));
            rpParameters.Add(new ReportParameter("Bank",Code));
            rpParameters.Add(new ReportParameter("RefNo", RefNo));
            rpParameters.Add(new ReportParameter("CustomerName", Name));
            rpParameters.Add(new ReportParameter("IssueDate", @CurrentDate));
            }
            else
            {
                Session["RowCount"] = 0;
                RowCount = 0;
                NoReportDataMessage();
            }

            if (dstCurrentReport.RPS_SP_rptDraftDetail.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.RPS_SP_rptDraftDetail.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"TransactionReport\DraftDetail\DraftDetail.rdlc", ShowReport);

            }
            else
            {
                Session["RowCount"] = 0;
                RowCount = 0;
                NoReportDataMessage();
            }
        }
        public void CitMailForExchangeRateReport(int @PrincipleBankId, string @CurrentDate, bool ShowReport)
        {
            SetDataSetBindingSource("RPS_SP_rptCitiMailForExchangeRate", "RPS_SP_rptOutstandingRejections");

            dstReportTableAdapters.RPS_SP_rptCitiMailForExchangeRateTableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptCitiMailForExchangeRateTableAdapter();
            dstReportTableAdapters.RPS_SP_rptOutstandingRejectionsTableAdapter dtbSubReport = new dstReportTableAdapters.RPS_SP_rptOutstandingRejectionsTableAdapter();

            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            // dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.RPS_SP_rptCitiMailForExchangeRate, @PrincipleBankId, @CurrentDate);

            dtbSubReport.ClearBeforeFill = true;
            dtbSubReport.Connection = ConnectionMaker();
            //dtbSubReport.SelectCommandTimeout = 0;
            dtbSubReport.Fill(dstCurrentReport.RPS_SP_rptOutstandingRejections, @PrincipleBankId, @CurrentDate, @CurrentDate);

            if (dstCurrentReport.RPS_SP_rptCitiMailForExchangeRate.Rows.Count > 0)
            {
                DataRow dr = dstCurrentReport.RPS_SP_rptCitiMailForExchangeRate.Rows[0];
                string no = dr["Total USD Amount"].ToString();
                this.AmountInWord = NumberWord.GetDecimalNumberInWords(no, "Cents", NumberWordsType.Millions);
            }
            if (dstCurrentReport.RPS_SP_rptCitiMailForExchangeRate.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.RPS_SP_rptCitiMailForExchangeRate.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"TransactionReport\ExchangeRateTelexMsg\ExchangeRateTelexMsg.rdlc", ShowReport);
            }
            else
            {
                Session["RowCount"] = 0;
                RowCount = 0;
                NoReportDataMessage();
            }
        }
        public void AmountWiseBeneficiaryReport(int @PrincipleBankId, string @FromDate, string @ToDate, decimal @Amount, bool ShowReport)
        {
            SetDataSetBindingSource("RPS_SP_rptAmountWiseBeneficiary");
            dstReportTableAdapters.RPS_SP_rptAmountWiseBeneficiaryTableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptAmountWiseBeneficiaryTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            // dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.RPS_SP_rptAmountWiseBeneficiary, @PrincipleBankId, @FromDate, @ToDate, @Amount);
            if (dstCurrentReport.RPS_SP_rptAmountWiseBeneficiary.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.RPS_SP_rptAmountWiseBeneficiary.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"TransactionReport\AmountWiseBene\AmountWiseBene.rdlc", ShowReport);
            }
            else
            {
                Session["RowCount"] = 0;
                RowCount = 0;
                NoReportDataMessage();
            }
        }
        public void AmountWiseBeneficiarySAMBAReport(int @PrincipleBankId, string @FromDate, string @ToDate, decimal @Amount, bool ShowReport)
        {
            SetDataSetBindingSource("RPS_SP_rptAmountWiseBeneficiarySAMBA1");
            dstReportTableAdapters.RPS_SP_rptAmountWiseBeneficiarySAMBA1TableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptAmountWiseBeneficiarySAMBA1TableAdapter();
            //dstReportTableAdapters.RPS_SP_rptAmountWiseBeneficiarySAMBATableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptAmountWiseBeneficiarySAMBATableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //  dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.RPS_SP_rptAmountWiseBeneficiarySAMBA1, @PrincipleBankId, @FromDate, @ToDate, @Amount);

            if (dstCurrentReport.RPS_SP_rptAmountWiseBeneficiarySAMBA1.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.RPS_SP_rptAmountWiseBeneficiarySAMBA1.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"TransactionReport\AmountWiseBene\AmountWiseBeneSAMBA.rdlc", ShowReport);
            }
            else
            {
                Session["RowCount"] = 0;
                RowCount = 0;
                NoReportDataMessage();
            }
        }
        public void AmountWiseRemitterReport(int @PrincipleBankId, string @FromDate, string @ToDate, decimal @Amount, bool ShowReport)
        {
            SetDataSetBindingSource("RPS_SP_rptAmountWiseRemitter");
            dstReportTableAdapters.RPS_SP_rptAmountWiseRemitterTableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptAmountWiseRemitterTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            // dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.RPS_SP_rptAmountWiseRemitter, PrincipleBankId, @FromDate, @ToDate, @Amount);

            if (dstCurrentReport.RPS_SP_rptAmountWiseRemitter.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.RPS_SP_rptAmountWiseRemitter.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"TransactionReport\AmountWiseRemitter\AmountWiseRemitter.rdlc", ShowReport);
            }
            else
            {
                Session["RowCount"] = 0;
                RowCount = 0;
                NoReportDataMessage();
            }
        }
        public void AmountWiseRemitterReport2(int @PrincipleBankId, string @FromDate, string @ToDate, decimal @Amount, bool ShowReport)
        {
            SetDataSetBindingSource("RPS_SP_rptAmountWiseRemitter2");
            dstReportTableAdapters.RPS_SP_rptAmountWiseRemitter2TableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptAmountWiseRemitter2TableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            // dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.RPS_SP_rptAmountWiseRemitter2, PrincipleBankId, @FromDate, @ToDate, @Amount);
            if (dstCurrentReport.RPS_SP_rptAmountWiseRemitter2.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.RPS_SP_rptAmountWiseRemitter2.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"TransactionReport\AmountWiseRemitter2\AmountWiseRemitter2.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }
        public void CompleteReport(int @PrincipleBankId, string @FromDate, string @ToDate, bool ShowReport)
        {
            SetDataSetBindingSource("RPS_SP_rptCompleteReport");
            dstReportTableAdapters.RPS_SP_rptCompleteReportTableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptCompleteReportTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.RPS_SP_rptCompleteReport, @PrincipleBankId, @FromDate, @ToDate);

            if (dstCurrentReport.RPS_SP_rptCompleteReport.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.RPS_SP_rptCompleteReport.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"TransactionReport\CompleteReport\CompleteReport.rdlc", ShowReport);
            }
            else
            {
                Session["RowCount"] = 0;
                RowCount = 0;
                NoReportDataMessage();
            }
        }
        public void FinancialEntriesReport(int @PrincipleBankId, DateTime @CurrentDate, bool ShowReport)
        {
            SetDataSetBindingSource("RPS_SP_rptFinancialEntries", "RPS_SP_rptFinancialEntriesDetail");

            dstReportTableAdapters.RPS_SP_rptFinancialEntriesTableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptFinancialEntriesTableAdapter();
            dstReportTableAdapters.RPS_SP_rptFinancialEntriesDetailTableAdapter dtbSubReport = new dstReportTableAdapters.RPS_SP_rptFinancialEntriesDetailTableAdapter();

            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            // dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.RPS_SP_rptFinancialEntries, @PrincipleBankId, @CurrentDate);

            dtbSubReport.ClearBeforeFill = true;
            dtbSubReport.Connection = ConnectionMaker();
            // dtbSubReport.SelectCommandTimeout = 0;
            dtbSubReport.Fill(dstCurrentReport.RPS_SP_rptFinancialEntriesDetail, @PrincipleBankId, @CurrentDate);

            dstCurrentReport.RPS_SP_rptFinancialEntriesDetail.EntryNumberColumn.ReadOnly = false;

            for (int i = 0; i < dstCurrentReport.RPS_SP_rptFinancialEntriesDetail.Rows.Count; i++)
            {
                dstCurrentReport.RPS_SP_rptFinancialEntriesDetail.Rows[i]["EntryNumber"] = 1752 + i;
            }

            if (dstCurrentReport.RPS_SP_rptFinancialEntries.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.RPS_SP_rptFinancialEntries.Rows.Count;
                SetReportViewer(dsrReport, dsrSubReport, dsrParameter, @"TransactionReport\FinancialEntries\FinancialEntries.rdlc", ShowReport);
                //SetReportViewer(dsrReport, dsrSubReport, dsrParameter, @"TransactionReport\FinancialEntries\FinancialEntriesDetail.rdlc", ShowReport);
              //  SetReportViewer(dsrReport, dsrSubReport, dsrParameter, @"TransactionReport\FinancialEntries\CopyofFinancialEntries.rdlc", ShowReport);

            }
            else
            {
                Session["RowCount"] = 0;
                RowCount = 0;
                NoReportDataMessage();
            }
        }

        public void OutstandingTracerReport(int @PrincipleBankId, string @CurrentDate, bool ShowReport)
        {
            SetDataSetBindingSource("RPS_SP_rptOutstandingTracer");
            dstReportTableAdapters.RPS_SP_rptOutstandingTracerTableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptOutstandingTracerTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            // dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.RPS_SP_rptOutstandingTracer, @PrincipleBankId, @CurrentDate);
            if (dstCurrentReport.RPS_SP_rptOutstandingTracer.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.RPS_SP_rptOutstandingTracer.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"TransactionReport\OutstandingTracer\OutstandingTracer.rdlc", ShowReport);
            }
            else
            {
                Session["RowCount"] = 0;
                RowCount = 0;
                NoReportDataMessage();
            }
        }
        public void OverDuePODReport(int @PrincipleBankId, int @CorrespondingBankId, int @CourierId, bool ShowReport)
        {
            SetDataSetBindingSource("RPS_SP_rptOverDuePOD");
            dstReportTableAdapters.RPS_SP_rptOverDuePODTableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptOverDuePODTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.RPS_SP_rptOverDuePOD, @PrincipleBankId, @CorrespondingBankId, @CourierId);
            if (dstCurrentReport.RPS_SP_rptOverDuePOD.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.RPS_SP_rptOverDuePOD.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"TransactionReport\OverDuePOD\OverDuePOD.rdlc", ShowReport);
            }
            else
            {
                Session["RowCount"] = 0;
                RowCount = 0;
                NoReportDataMessage();
            }
        }

        public void MatchDraftsReport(int @PrincipleBankId, int @CorrespondingBankId, DateTime LiquidationDate, bool ShowReport)
        {
            SetDataSetBindingSource("RPS_SP_rptReconcileMatchDrafts");

            dstReportTableAdapters.RPS_SP_rptReconcileMatchDraftsTableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptReconcileMatchDraftsTableAdapter();

            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.RPS_SP_rptReconcileMatchDrafts, @PrincipleBankId, @CorrespondingBankId, LiquidationDate);

            if (dstCurrentReport.RPS_SP_rptReconcileMatchDrafts.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.RPS_SP_rptReconcileMatchDrafts.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"ReconReport\MatchDrafts\MatchDrafts.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void OutstandingDraftsReport(int @PrincipleBankId, int @CorrespondingBankId, DateTime FromDate, DateTime ToDate, bool ShowReport)
        {
            SetDataSetBindingSource("RPS_SP_rptReconcileOutstandingDrafts");
            dstReportTableAdapters.RPS_SP_rptReconcileOutstandingDraftsTableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptReconcileOutstandingDraftsTableAdapter();

            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.RPS_SP_rptReconcileOutstandingDrafts, @PrincipleBankId, @CorrespondingBankId, FromDate, ToDate);

            if (dstCurrentReport.RPS_SP_rptReconcileOutstandingDrafts.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.RPS_SP_rptReconcileOutstandingDrafts.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"ReconReport\OutstandingDrafts\OutstandingDrafts.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void InwardRemittanceReport(int @PrincipleBankId, int @CorrespondingBankId, string @FromDate, string @ToDate, bool ShowReport)
        {
            SetDataSetBindingSource("RPS_SP_rptInwardRemittance");
            dstReportTableAdapters.RPS_SP_rptInwardRemittanceTableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptInwardRemittanceTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            // dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.RPS_SP_rptInwardRemittance, @PrincipleBankId, @CorrespondingBankId, @FromDate, @ToDate);
            if (dstCurrentReport.RPS_SP_rptInwardRemittance.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.RPS_SP_rptInwardRemittance.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"SBP\InwardRemittance\InwardRemittance.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void MonthlySBPClaimReport(string @FromDate, string @ToDate, int @PrincipleBankId, double @CoverAmountUSD, bool ShowReport)
        {
            SetDataSetBindingSource("RPS_SP_rptMonthlySBPClaim");
            dstReportTableAdapters.RPS_SP_rptMonthlySBPClaimTableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptMonthlySBPClaimTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.RPS_SP_rptMonthlySBPClaim, @FromDate, @ToDate, @PrincipleBankId, Convert.ToDecimal(@CoverAmountUSD));
            if (dstCurrentReport.RPS_SP_rptMonthlySBPClaim.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.RPS_SP_rptMonthlySBPClaim.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"SBP\MonthlySBPClaim\MonthlySBPClaim.rdlc", ShowReport);
                Session["RowCount"] = RowCount;
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }
        public void ManifestSummaryReport(int @PrincipleBankId, int @CorrespondingBankId, int @CourierId, string @FromDate, string @ToDate,string BankName,string FileName, bool ShowReport)
        {
            SetDataSetBindingSource("RPS_SP_rptManifestSummary");
            dstReportTableAdapters.RPS_SP_rptManifestSummaryTableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptManifestSummaryTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.RPS_SP_rptManifestSummary, @PrincipleBankId, @CorrespondingBankId, @CourierId, @FromDate, @ToDate);

            rpParameters.Add(new ReportParameter("FromDate", FromDate));
            rpParameters.Add(new ReportParameter("ToDate", ToDate));
            rpParameters.Add(new ReportParameter("Courier", CourierId.ToString()));
            rpParameters.Add(new ReportParameter("BankName", BankName));
            rpParameters.Add(new ReportParameter("FileName", FileName));

            if (dstCurrentReport.RPS_SP_rptManifestSummary.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.RPS_SP_rptManifestSummary.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"TransactionReport\ManifestSummary\ManifestSummary.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void TraderReport(int @PrincipleBankId, int @CorrespondingBankId, string @CurrentDate, string @FromDate, string @ToDate, bool ShowReport)
        {
            SetDataSetBindingSource("RPS_SP_rptTraderReport");
            dstReportTableAdapters.RPS_SP_rptTraderReportTableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptTraderReportTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            // dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.RPS_SP_rptTraderReport, @PrincipleBankId, @CorrespondingBankId, @CurrentDate, @FromDate, @ToDate);

          

            if (dstCurrentReport.RPS_SP_rptTraderReport.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.RPS_SP_rptTraderReport.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"SBP\TraderReport\TraderReport.rdlc", ShowReport);
            }
            else
            {
                Session["RowCount"] = 0;
                RowCount = 0;
                NoReportDataMessage();
            }
        }

        public void TraderReportSAMBA(int @PrincipleBankId, int @CorrespondingBankId, string @CurrentDate, string @FromDate, string @ToDate, bool ShowReport)
        {
            SetDataSetBindingSource("RPS_SP_rptTraderReportSAMBA");
            dstReportTableAdapters.RPS_SP_rptTraderReportSAMBATableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptTraderReportSAMBATableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.RPS_SP_rptTraderReportSAMBA, @PrincipleBankId, @CorrespondingBankId, @CurrentDate, @FromDate, @ToDate);
            if (dstCurrentReport.RPS_SP_rptTraderReportSAMBA.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.RPS_SP_rptTraderReportSAMBA.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"SBP\TraderReport\TraderReportSAMBA.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void InwardRemittanceVoucherReport(int @PrincipleBankId, string @SBPCode, string @FromDate, string @ToDate, bool ShowReport)
        {
            SetDataSetBindingSource("RPS_SP_rptInwardRemittanceVoucher");
            dstReportTableAdapters.RPS_SP_rptInwardRemittanceVoucherTableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptInwardRemittanceVoucherTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.RPS_SP_rptInwardRemittanceVoucher, @PrincipleBankId, @SBPCode, @FromDate, @ToDate);

            if (dstCurrentReport.RPS_SP_rptInwardRemittanceVoucher.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.RPS_SP_rptInwardRemittanceVoucher.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"SBP\InwardRmtncVoucher\InwardRmtncVoucher.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }
        public void OverDuePODReportSummary(int @PrincipleBankId, int @CorrespondingBankId, int @CourierId, bool ShowReport)
        {
            SetDataSetBindingSource("RPS_SP_rptOverDuePODSummary");
            dstReportTableAdapters.RPS_SP_rptOverDuePODSummaryTableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptOverDuePODSummaryTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.RPS_SP_rptOverDuePODSummary, @PrincipleBankId, @CorrespondingBankId, @CourierId);
            if (dstCurrentReport.RPS_SP_rptOverDuePODSummary.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.RPS_SP_rptOverDuePODSummary.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"TransactionReport\OverDuePODSummary\OverDuePODSummary.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void DebitCreditReport(int @PrincipleBankId, int @CorrespondingBankId, DateTime EntryDate, bool ShowReport)
        {
            SetDataSetBindingSource("RPS_SP_rptReconcileDebitCredit", "RPS_SP_rptReconcileDebitCreditSummary");

            dstReportTableAdapters.RPS_SP_rptReconcileDebitCreditTableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptReconcileDebitCreditTableAdapter();
            dstReportTableAdapters.RPS_SP_rptReconcileDebitCreditSummaryTableAdapter dtbSubReport = new dstReportTableAdapters.RPS_SP_rptReconcileDebitCreditSummaryTableAdapter();

            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker(); 
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.RPS_SP_rptReconcileDebitCredit, @PrincipleBankId, @CorrespondingBankId, EntryDate);

            dtbSubReport.ClearBeforeFill = true;
            dtbSubReport.Connection = ConnectionMaker(); 
            //dtbSubReport.SelectCommandTimeout = 0;
            dtbSubReport.Fill(dstCurrentReport.RPS_SP_rptReconcileDebitCreditSummary, @PrincipleBankId, @CorrespondingBankId, EntryDate);

            rpParameters.Add(new ReportParameter("ClientName",
                dstCurrentReport.RPS_SP_rptCRPLClient.Rows[0]["Client Name"].ToString()));
            rpParameters.Add(new ReportParameter("Bank", RefNo));
            rpParameters.Add(new ReportParameter("CustomerName", FromName));
            rpParameters.Add(new ReportParameter("EntryDate", EntryDate.ToString()));

            if (dstCurrentReport.RPS_SP_rptReconcileDebitCredit.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.RPS_SP_rptReconcileDebitCredit.Rows.Count;
                SetReportViewer(dsrReport, dsrSubReport, dsrParameter, @"ReconReport\DebitCredit\DebitCredit.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void DailyRateInputReport(int @PrincipleBankId, string @FromDate, string @ToDate, bool ShowReport)
        {
            SetDataSetBindingSource("RPS_SP_rptDailyRateInput");
            dstReportTableAdapters.RPS_SP_rptDailyRateInputTableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptDailyRateInputTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker(); 
           // dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.RPS_SP_rptDailyRateInput, @PrincipleBankId, @FromDate, @ToDate);
            if (dstCurrentReport.RPS_SP_rptDailyRateInput.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.RPS_SP_rptDailyRateInput.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"GeneralReport\DailyRateInputReport\DailyRateInputReport.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }
        public void StationWiseManifestReport(int @PrincipleBankId, int @CorrespondingBankId, int @CourierId, int @StationId, string @MenifestDate, bool ShowReport)
        {
            SetDataSetBindingSource("RPS_SP_rptStationWiseManifest");
            dstReportTableAdapters.RPS_SP_rptStationWiseManifestTableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptStationWiseManifestTableAdapter();
            //iCORE.RPS.DATAOBJECTS.dstReportTableAdapters.RPS_SP_rptStationWiseManifestTableAdapter dtbReport = new iCORE.RPS.DATAOBJECTS.dstReportTableAdapters.RPS_SP_rptStationWiseManifestTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.RPS_SP_rptStationWiseManifest, @PrincipleBankId, @CorrespondingBankId, @CourierId, @StationId, @MenifestDate);
            if (dstCurrentReport.RPS_SP_rptStationWiseManifest.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.RPS_SP_rptStationWiseManifest.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"TransactionReport\StationWiseManifest\StationWiseManifest.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void DailyTransactionSummaryReport(int @PrincipleBankId, string @FromDate, string @ToDate, bool ShowReport)
        {
            SetDataSetBindingSource("RPS_SP_rptDailyTransactionSummary");
            dstReportTableAdapters.RPS_SP_rptDailyTransactionSummaryTableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptDailyTransactionSummaryTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.RPS_SP_rptDailyTransactionSummary, @PrincipleBankId, @FromDate, @ToDate);
            if (dstCurrentReport.RPS_SP_rptDailyTransactionSummary.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.RPS_SP_rptDailyTransactionSummary.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"GeneralReport\DailyTrnstnSummary\DailyTrnstnSummary.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"]=0;
                NoReportDataMessage();
            }
        }

        public void ExchangeProfitRateReport(int @PrincipleBankId, string @FromDate, string @ToDate, bool ShowReport)
        {
            SetDataSetBindingSource("RPS_SP_rptExchangeProfitLoss");
            dstReportTableAdapters.RPS_SP_rptExchangeProfitLossTableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptExchangeProfitLossTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker(); 
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.RPS_SP_rptExchangeProfitLoss, @PrincipleBankId, @FromDate, @ToDate);
            if (dstCurrentReport.RPS_SP_rptExchangeProfitLoss.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.RPS_SP_rptExchangeProfitLoss.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"GeneralReport\ExchangeProfitLoss\ExchangeProfitLoss.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void MonthlySummaryReport(int @PrincipleBankId, string @FromDate, string @ToDate, bool ShowReport)
        {
            SetDataSetBindingSource("RPS_SP_rptMonthlySummary");
            dstReportTableAdapters.RPS_SP_rptMonthlySummaryTableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptMonthlySummaryTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.RPS_SP_rptMonthlySummary, @FromDate, @ToDate);
            if (dstCurrentReport.RPS_SP_rptMonthlySummary.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.RPS_SP_rptMonthlySummary.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"GeneralReport\MonthlySummary\MonthlySummary.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void OustandingRejectionsReport(int @PrincipleBankId, string @FromDate, string @ToDate, bool ShowReport)
        {
            SetDataSetBindingSource("RPS_SP_rptOutstandingRejections");
            dstReportTableAdapters.RPS_SP_rptOutstandingRejectionsTableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptOutstandingRejectionsTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.RPS_SP_rptOutstandingRejections, @PrincipleBankId, @FromDate, @ToDate);
            if (dstCurrentReport.RPS_SP_rptOutstandingRejections.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.RPS_SP_rptOutstandingRejections.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"GeneralReport\OutstandingRejReport\OutstandingRejReport.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void PREReport(int @PrincipleBankId, int @CorrespondingBankId, string @FromDate, string @ToDate, bool ShowReport)
        {
            SetDataSetBindingSource("RPS_SP_rptPREReport");
            dstReportTableAdapters.RPS_SP_rptPREReportTableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptPREReportTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker(); 
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.RPS_SP_rptPREReport, @CorrespondingBankId, @FromDate, @ToDate);

            if (dstCurrentReport.RPS_SP_rptPREReport.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.RPS_SP_rptPREReport.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"GeneralReport\PREReport\PREReport.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }
        public void StopPaymentReport(int @PrincipleBankId, string @DraftNo, int @CorrespondingBankId, bool ShowReport)
        {
            SetDataSetBindingSource("RPS_SP_rptStopPayment");
            dstReportTableAdapters.RPS_SP_rptStopPaymentTableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptStopPaymentTableAdapter();
           // iCORE.RPS.DATAOBJECTS.dstReportTableAdapters.RPS_SP_rptStopPaymentTableAdapter dtbReport = new iCORE.RPS.DATAOBJECTS.dstReportTableAdapters.RPS_SP_rptStopPaymentTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
           // dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.RPS_SP_rptStopPayment, @PrincipleBankId, @DraftNo, @CorrespondingBankId);
            if (dstCurrentReport.RPS_SP_rptStopPayment.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.RPS_SP_rptStopPayment.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"GeneralReport\StopPaymentLetter\StopPayment.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void ProceedCertificateReport(int @PrincipleBankId, string @DraftNo, bool ShowReport)
        {
            SetDataSetBindingSource("RPS_SP_rptProceedCertificate");
            dstReportTableAdapters.RPS_SP_rptProceedCertificateTableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptProceedCertificateTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dstCurrentReport.EnforceConstraints = false;
            dtbReport.Connection = ConnectionMaker(); 
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.RPS_SP_rptProceedCertificate, @PrincipleBankId, @DraftNo);
            if (dstCurrentReport.RPS_SP_rptProceedCertificate.Rows.Count > 0)
            {
                DataRow dr = dstCurrentReport.RPS_SP_rptProceedCertificate.Rows[0];
                //string no =  dr["Foreign Currency"].ToString();
                DataTable dt = dstCurrentReport.RPS_SP_rptProceedCertificate;
                int i = 0;
                //int no = 0;
                //strt by Muhammad Imran on 20-11-07
                double val = 0;
                foreach (DataRow drw in dt.Rows)
                {

                    val = val + Convert.ToDouble(dt.Rows[i]["Draft Amount"].ToString());
                    i++;
                }


                this.AmountInWord = NumberWord.GetDecimalNumberInWords(val.ToString("###.00"),
                    (dt.Rows[0]["Currency"].ToString() == "USD" ? "Cents" : "Paisas"), NumberWordsType.Millions);
                //end by Muhammad Imran on 20-11-07
            }
            if (dstCurrentReport.RPS_SP_rptProceedCertificate.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.RPS_SP_rptProceedCertificate.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"GeneralReport\ProceedCertificate\ProceedCertificate.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void MasterZipCodeReport(int @PrincipleBankId, bool Flag, string From, string To)
        {
            SetDataSetBindingSource("RPS_SP_rptMasterZipCode");
            dstReportTableAdapters.RPS_SP_rptMasterZipCodeTableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptMasterZipCodeTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker(); 
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.RPS_SP_rptMasterZipCode, Flag, From, To);
            if (dstCurrentReport.RPS_SP_rptMasterZipCode.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.RPS_SP_rptMasterZipCode.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"GeneralReport\Zipcodes\Zipcodes.rdlc", true);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void UndeliveredPacketsReport(int @PrincipleBankId, int @CorrespondingBankId, int @CourierId, string @FromDate, string @ToDate, bool ShowReport)
        {
            SetDataSetBindingSource("RPS_SP_rptUndeliverdPackets");
            dstReportTableAdapters.RPS_SP_rptUndeliverdPacketsTableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptUndeliverdPacketsTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker(); 
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.RPS_SP_rptUndeliverdPackets, @PrincipleBankId, @CorrespondingBankId, @CourierId, @FromDate, @ToDate);
            if (dstCurrentReport.RPS_SP_rptUndeliverdPackets.Rows.Count > 0)
            {
                RowCount=dstCurrentReport.RPS_SP_rptUndeliverdPackets.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"TransactionReport\UndeliverdPackets\UndeliverdPackets.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }
        public void MultipleBeneficiaryReport(string @FromDate, string @ToDate, int Frequency, bool ShowReport)
        {
            SetDataSetBindingSource("RPS_SP_rptMultipleBeneficiary");
            dstReportTableAdapters.RPS_SP_rptMultipleBeneficiaryTableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptMultipleBeneficiaryTableAdapter();
            //iCORE.RPS.DATAOBJECTS.dstReportTableAdapters.RPS_SP_rptMultipleBeneficiaryTableAdapter dtbReport = new iCORE.RPS.DATAOBJECTS.dstReportTableAdapters.RPS_SP_rptMultipleBeneficiaryTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
           // dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.RPS_SP_rptMultipleBeneficiary, @FromDate, @ToDate, Frequency);

            rpParameters.Add(new ReportParameter("FromDate", FromDate));
            rpParameters.Add(new ReportParameter("ToDate", ToDate));
            rpParameters.Add(new ReportParameter("Frequency", Frequency.ToString()));


            if (dstCurrentReport.RPS_SP_rptMultipleBeneficiary.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.RPS_SP_rptMultipleBeneficiary.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"TransactionReport\MultipleBeneficiary\MultipleBeneficiary.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }
        public void FrequencyOfRemitterReport(string @FromDate, string @ToDate, int @Frequency, bool ShowReport)
        {
            SetDataSetBindingSource("RPS_SP_rptFrequencyofRemitter");
            dstReportTableAdapters.RPS_SP_rptFrequencyofRemitterTableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptFrequencyofRemitterTableAdapter();
            //iCORE.RPS.DATAOBJECTS.dstReportTableAdapters.RPS_SP_rptFrequencyofRemitterTableAdapter dtbReport = new iCORE.RPS.DATAOBJECTS.dstReportTableAdapters.RPS_SP_rptFrequencyofRemitterTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
           // dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.RPS_SP_rptFrequencyofRemitter, @FromDate, @ToDate, @Frequency);

            rpParameters.Add(new ReportParameter("FromDate", FromDate));
            rpParameters.Add(new ReportParameter("ToDate", ToDate));
            rpParameters.Add(new ReportParameter("Frequency",Frequency.ToString()));

            if (dstCurrentReport.RPS_SP_rptFrequencyofRemitter.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.RPS_SP_rptFrequencyofRemitter.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"TransactionReport\FrequencyOfRemitter\FrequencyOfRemitter.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void FrequencyOfBeneficiaryReport(string @FromDate, string @ToDate, int @Frequency, bool ShowReport)
        {
            SetDataSetBindingSource("RPS_SP_rptFrequencyofBeneficiary");
            dstReportTableAdapters.RPS_SP_rptFrequencyofBeneficiaryTableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptFrequencyofBeneficiaryTableAdapter();
            //iCORE.RPS.DATAOBJECTS.dstReportTableAdapters.RPS_SP_rptFrequencyofRemitterTableAdapter dtbReport = new iCORE.RPS.DATAOBJECTS.dstReportTableAdapters.RPS_SP_rptFrequencyofRemitterTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            // dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.RPS_SP_rptFrequencyofBeneficiary, @FromDate, @ToDate, @Frequency);
            if (dstCurrentReport.RPS_SP_rptFrequencyofBeneficiary.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.RPS_SP_rptFrequencyofBeneficiary.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"TransactionReport\FrequencyOfBeneficiary\FrequencyOfBeneficiary.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void ReconcileDiscrepancyReport(int @PrincipleBankId, int @CorrespondingBankId, DateTime FromDate, DateTime ToDate, bool ShowReport)
        {
            SetDataSetBindingSource("RPS_SP_rptReconcileDiscrepancy");
            dstReportTableAdapters.RPS_SP_rptReconcileDiscrepancyTableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptReconcileDiscrepancyTableAdapter();
            //iCORE.RPS.DATAOBJECTS.dstReportTableAdapters.RPS_SP_rptReconcileDiscrepancyTableAdapter dtbReport = new iCORE.RPS.DATAOBJECTS.dstReportTableAdapters.RPS_SP_rptReconcileDiscrepancyTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
           // dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.RPS_SP_rptReconcileDiscrepancy, @PrincipleBankId, @CorrespondingBankId, FromDate, ToDate);

            if (dstCurrentReport.RPS_SP_rptReconcileDiscrepancy.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.RPS_SP_rptReconcileDiscrepancy.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"ReconReport\Discrepancy\Discrepancy.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void RemitterDiscrepant(bool ShowReport)
        {
            SetDataSetBindingSource("RPS_RPT_REMITTER");
            dstReportTableAdapters.RPS_RPT_REMITTERTableAdapter dtbReport = new dstReportTableAdapters.RPS_RPT_REMITTERTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.RPS_RPT_REMITTER);
            if (dstCurrentReport.RPS_RPT_REMITTER.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.RPS_RPT_REMITTER.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"AML_Discrepent\Remitter.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void BeneficiaryDiscrepant(bool ShowReport)
        {
            SetDataSetBindingSource("RPS_RPT_BENEFICIARY");
            dstReportTableAdapters.RPS_RPT_BENEFICIARYTableAdapter dtbReport = new dstReportTableAdapters.RPS_RPT_BENEFICIARYTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.RPS_RPT_BENEFICIARY);
            if (dstCurrentReport.RPS_RPT_BENEFICIARY.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.RPS_RPT_BENEFICIARY.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"AML_Discrepent\Beneficiary.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }
        public void Generate_Correspondent_Letter(int @CorrespondingBankID, DateTime @IssueDate,string @SPDS_Type, bool ShowReport)
        {
            SetDataSetBindingSource("Correspondent_Genrate_Letter");
            dstReportTableAdapters.Correspondent_Genrate_LetterTableAdapter dtbReport = new dstReportTableAdapters.Correspondent_Genrate_LetterTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.Correspondent_Genrate_Letter, @CorrespondingBankID, @IssueDate, @SPDS_Type);

            rpParameters.Add(new ReportParameter("SPDSType", SPDS_Type));

            if (dstCurrentReport.Correspondent_Genrate_Letter.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.Correspondent_Genrate_Letter.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"Correspondent_Generate_Letter\Correspondent_Letter.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void SPDS_SP_RPT_PRODUCTARRANGEMENT(bool ShowReport)
        {
            SetDataSetBindingSource("SPDS_SP_RPT_PRODUCTARRANGEMENT");
            dstReportTableAdapters.SPDS_SP_RPT_PRODUCTARRANGEMENTTableAdapter dtbReport = new dstReportTableAdapters.SPDS_SP_RPT_PRODUCTARRANGEMENTTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.SPDS_SP_RPT_PRODUCTARRANGEMENT);
            if (dstCurrentReport.SPDS_SP_RPT_PRODUCTARRANGEMENT.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.SPDS_SP_RPT_PRODUCTARRANGEMENT.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"GeneralReport\CustomerProductArrangment_Configuration\CustomerProduct_Configuration.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void StationaryThreshold(bool ShowReport)
        {
            SetDataSetBindingSource("SPDS_SP_rptStationaryThreshold");
            dstReportTableAdapters.SPDS_SP_rptStationaryThresholdTableAdapter dtbReport = new dstReportTableAdapters.SPDS_SP_rptStationaryThresholdTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.SPDS_SP_rptStationaryThreshold);
            if (dstCurrentReport.SPDS_SP_rptStationaryThreshold.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.SPDS_SP_rptStationaryThreshold.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"StationaryThreshold\StationaryThreshold.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void test(bool ShowReport,string reportName)
        {
            SetDataSetBindingSource("SPDS_SP_rptStationaryThreshold");
            dstReportTableAdapters.SPDS_SP_rptStationaryThresholdTableAdapter dtbReport = new dstReportTableAdapters.SPDS_SP_rptStationaryThresholdTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.SPDS_SP_rptStationaryThreshold);
            if (dstCurrentReport.SPDS_SP_rptStationaryThreshold.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.SPDS_SP_rptStationaryThreshold.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"test\" + reportName , ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void AuditTrial(string @ObjectName, string @From, string @To, string @UserID,string @Action, bool ShowReport)
        {
            SetDataSetBindingSource("SPDS_SP_rpt_AuditTrail");
            dstReportTableAdapters.SPDS_SP_rpt_AuditTrailTableAdapter dtbReport = new dstReportTableAdapters.SPDS_SP_rpt_AuditTrailTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.SPDS_SP_rpt_AuditTrail, @ObjectName, @From, @To, @UserID, @Action);

            rpParameters.Add(new ReportParameter("FromDate", From));
            rpParameters.Add(new ReportParameter("ToDate", To));

            if (dstCurrentReport.SPDS_SP_rpt_AuditTrail.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.SPDS_SP_rpt_AuditTrail.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"AuditTrial\AuditTrial.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void RPT_DailyTran(string @CorrBankID,string @From, string @To, bool ShowReport)
        {
            SetDataSetBindingSource("SPDS_SP_rptDailyTran_1");
            dstReportTableAdapters.SPDS_SP_rptDailyTran_1TableAdapter dtbReport = new dstReportTableAdapters.SPDS_SP_rptDailyTran_1TableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.SPDS_SP_rptDailyTran_1, @CorrBankID, @From, @To);

            rpParameters.Add(new ReportParameter("FromDate", From));
            rpParameters.Add(new ReportParameter("ToDate", To));

            if (dstCurrentReport.SPDS_SP_rptDailyTran_1.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.SPDS_SP_rptDailyTran_1.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"Daily_Trans_rep\Daily_Trans_rep.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void RPT_TransactionReceived(string @CorrBankID, string @From, string @To, bool ShowReport)
        {
            SetDataSetBindingSource("RPS_SP_rptTransactionReceived");
            dstReportTableAdapters.RPS_SP_rptTransactionReceivedTableAdapter dtbReport = new dstReportTableAdapters.RPS_SP_rptTransactionReceivedTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.RPS_SP_rptTransactionReceived, @CorrBankID, @From, @To);

            rpParameters.Add(new ReportParameter("FromDate", From));
            rpParameters.Add(new ReportParameter("ToDate", To));

            if (dstCurrentReport.RPS_SP_rptTransactionReceived.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.RPS_SP_rptTransactionReceived.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"TransactionReceived\TransReceived.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void RPT_PRIControlCart( string @From, string @To, bool ShowReport)
        {
            SetDataSetBindingSource("SPDS_SP_rptPRIControlCard");
            dstReportTableAdapters.SPDS_SP_rptPRIControlCardTableAdapter dtbReport = new dstReportTableAdapters.SPDS_SP_rptPRIControlCardTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.SPDS_SP_rptPRIControlCard, @From, @To);

            rpParameters.Add(new ReportParameter("FromDate", From));
            rpParameters.Add(new ReportParameter("ToDate", To));

            if (dstCurrentReport.SPDS_SP_rptPRIControlCard.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.SPDS_SP_rptPRIControlCard.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"Control_Card\Control_Card.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void RPT_IntraBankTransaction(string @FromDate, string @ToDate, bool ShowReport)
        {
            SetDataSetBindingSource("SPDS_SP_rptIntraBankTransaction");
            dstReportTableAdapters.SPDS_SP_rptIntraBankTransactionTableAdapter dtbReport = new dstReportTableAdapters.SPDS_SP_rptIntraBankTransactionTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.SPDS_SP_rptIntraBankTransaction, @FromDate, @ToDate);

            rpParameters.Add(new ReportParameter("FromDate", FromDate));
            rpParameters.Add(new ReportParameter("ToDate", ToDate));

            if (dstCurrentReport.SPDS_SP_rptIntraBankTransaction.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.SPDS_SP_rptIntraBankTransaction.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"IntraBankTransaction\IntraBankTrans.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void RPT_UnauthorizeObject(bool ShowReport)
        {
            SetDataSetBindingSource("SPDS_SP_rptUnauthorizeObject");
            dstReportTableAdapters.SPDS_SP_rptUnauthorizeObjectTableAdapter dtbReport = new dstReportTableAdapters.SPDS_SP_rptUnauthorizeObjectTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.SPDS_SP_rptUnauthorizeObject);
            if (dstCurrentReport.SPDS_SP_rptUnauthorizeObject.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.SPDS_SP_rptUnauthorizeObject.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"UnAuthorizerObject\Unauthorize_Object.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void RPT_ConsolidatedReport(string @From, string @To, bool ShowReport)
        {
            SetDataSetBindingSource("SPDS_SP_rptConsolidatedDraft");
            dstReportTableAdapters.SPDS_SP_rptConsolidatedDraftTableAdapter dtbReport = new dstReportTableAdapters.SPDS_SP_rptConsolidatedDraftTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.SPDS_SP_rptConsolidatedDraft, @From, @To);

            rpParameters.Add(new ReportParameter("FromDate", From));
            rpParameters.Add(new ReportParameter("ToDate", To));

            if (dstCurrentReport.SPDS_SP_rptConsolidatedDraft.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.SPDS_SP_rptConsolidatedDraft.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"Consolidated_Report\Consolidated_Report.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void RPT_ListStopPaymentCancelDraft(string @From, string @To, bool ShowReport)
        {
            SetDataSetBindingSource("SPDS_SP_rptListStopPaymentCancelDraft");
            dstReportTableAdapters.SPDS_SP_rptListStopPaymentCancelDraftTableAdapter dtbReport = new dstReportTableAdapters.SPDS_SP_rptListStopPaymentCancelDraftTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.SPDS_SP_rptListStopPaymentCancelDraft, @From, @To);

            rpParameters.Add(new ReportParameter("FromDate", From));
            rpParameters.Add(new ReportParameter("ToDate", To));

            if (dstCurrentReport.SPDS_SP_rptListStopPaymentCancelDraft.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.SPDS_SP_rptListStopPaymentCancelDraft.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"ListOfStopPaymentDraft\ListOfCancelDraft.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void RPT_ListStopPaymentDuplicateDraft(string @From, string @To, bool ShowReport)
        {
            SetDataSetBindingSource("SPDS_SP_rptListStopPaymentDuplicateDraft");
            dstReportTableAdapters.SPDS_SP_rptListStopPaymentDuplicateDraftTableAdapter dtbReport = new dstReportTableAdapters.SPDS_SP_rptListStopPaymentDuplicateDraftTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.SPDS_SP_rptListStopPaymentDuplicateDraft, @From, @To);

            rpParameters.Add(new ReportParameter("FromDate", From));
            rpParameters.Add(new ReportParameter("ToDate", To));

            if (dstCurrentReport.SPDS_SP_rptListStopPaymentDuplicateDraft.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.SPDS_SP_rptListStopPaymentDuplicateDraft.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"ListOfStopPaymentDraft\ListOfDuplicateDraft.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void RPT_ListOfCancelDraft(int CorrBankID,string @From, string @To, bool ShowReport)
        {
            SetDataSetBindingSource("SPDS_SP_rptListofCancelDraft");
            dstReportTableAdapters.SPDS_SP_rptListofCancelDraftTableAdapter dtbReport = new dstReportTableAdapters.SPDS_SP_rptListofCancelDraftTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.SPDS_SP_rptListofCancelDraft,@CorrBankID, @From, @To);

            rpParameters.Add(new ReportParameter("FromDate", From));
            rpParameters.Add(new ReportParameter("ToDate", To));

            if (dstCurrentReport.SPDS_SP_rptListofCancelDraft.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.SPDS_SP_rptListofCancelDraft.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"ListOfCancelDraft\ListOfCancelDraft.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void RPT_ListOfDuplicateDraft(int CorrespondingBankID, string @From, string @To, bool ShowReport)
        {
            SetDataSetBindingSource("SPDS_SP_rptDuplicateDraft");
            dstReportTableAdapters.SPDS_SP_rptDuplicateDraftTableAdapter dtbReport = new dstReportTableAdapters.SPDS_SP_rptDuplicateDraftTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.SPDS_SP_rptDuplicateDraft, @CorrespondingBankID, @From, @To);

            rpParameters.Add(new ReportParameter("FromDate", From));
            rpParameters.Add(new ReportParameter("ToDate", To));
            rpParameters.Add(new ReportParameter("CorrBankID", Convert.ToString(CorrespondingBankID)));

            if (dstCurrentReport.SPDS_SP_rptDuplicateDraft.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.SPDS_SP_rptDuplicateDraft.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"ListOfDuplicateDraft\ListOfDuplicateDraft.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void RPT_A2A_CompleteReport(int CorrespondingBankID, string @From, string @To, bool ShowReport)
        {
            SetDataSetBindingSource("SPDS_SP_rptA2A");
            dstReportTableAdapters.SPDS_SP_rptA2ATableAdapter dtbReport = new dstReportTableAdapters.SPDS_SP_rptA2ATableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.SPDS_SP_rptA2A, @CorrespondingBankID, @From, @To);

            rpParameters.Add(new ReportParameter("FromDate", From));
            rpParameters.Add(new ReportParameter("ToDate", To));
            rpParameters.Add(new ReportParameter("CorrBankID", Convert.ToString(CorrespondingBankID)));

            if (dstCurrentReport.SPDS_SP_rptA2A.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.SPDS_SP_rptA2A.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"A2A\A2A_Report.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void RPT_DraftDelivered(int CorrespondingBankID, string @From, string @To, bool ShowReport)
        {
            SetDataSetBindingSource("SPDS_SP_rptDraftDelivered");
            dstReportTableAdapters.SPDS_SP_rptDraftDeliveredTableAdapter dtbReport = new dstReportTableAdapters.SPDS_SP_rptDraftDeliveredTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.SPDS_SP_rptDraftDelivered, @CorrespondingBankID, @From, @To);

            rpParameters.Add(new ReportParameter("FromDate", From));
            rpParameters.Add(new ReportParameter("ToDate", To));
            rpParameters.Add(new ReportParameter("CorrBankID", Convert.ToString(CorrespondingBankID)));

            if (dstCurrentReport.SPDS_SP_rptDraftDelivered.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.SPDS_SP_rptDraftDelivered.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"DraftDelivered\DraftDelivered.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void RPT_DraftUnDelivered(int CorrespondingBankID, string @From, string @To, bool ShowReport)
        {
            SetDataSetBindingSource("SPDS_SP_rptDraftUnDelivered");
            dstReportTableAdapters.SPDS_SP_rptDraftUnDeliveredTableAdapter dtbReport = new dstReportTableAdapters.SPDS_SP_rptDraftUnDeliveredTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.SPDS_SP_rptDraftUnDelivered, @CorrespondingBankID, @From, @To);

            rpParameters.Add(new ReportParameter("FromDate", From));
            rpParameters.Add(new ReportParameter("ToDate", To));
            rpParameters.Add(new ReportParameter("CorrBankID", Convert.ToString(CorrespondingBankID)));

            if (dstCurrentReport.SPDS_SP_rptDraftUnDelivered.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.SPDS_SP_rptDraftUnDelivered.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"DraftUnDelivered\DraftUnDelivered.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void RPT_FED(string @From, string @To, bool ShowReport)
        {
            SetDataSetBindingSource("SPDS_SP_rptFEDReport");
            dstReportTableAdapters.SPDS_SP_rptFEDReportTableAdapter dtbReport = new dstReportTableAdapters.SPDS_SP_rptFEDReportTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.SPDS_SP_rptFEDReport, @From, @To);

            rpParameters.Add(new ReportParameter("FromDate", From));
            rpParameters.Add(new ReportParameter("ToDate", To));

            if (dstCurrentReport.SPDS_SP_rptFEDReport.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.SPDS_SP_rptFEDReport.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"FED\FED_Report.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void RPT_DeliveredMCReport(string @From, string @To, bool ShowReport)
        {
            SetDataSetBindingSource("SPDS_SP_rptDeliveredMCReport");
            dstReportTableAdapters.SPDS_SP_rptDeliveredMCReportTableAdapter dtbReport = new dstReportTableAdapters.SPDS_SP_rptDeliveredMCReportTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.SPDS_SP_rptDeliveredMCReport, @From, @To);

            rpParameters.Add(new ReportParameter("FromDate", From));
            rpParameters.Add(new ReportParameter("ToDate", To));

            if (dstCurrentReport.SPDS_SP_rptDeliveredMCReport.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.SPDS_SP_rptDeliveredMCReport.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"DeliveredMCReport\DeliveredMCReport.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void RPT_UndeliveredMCReport(string @From, string @To, bool ShowReport)
        {
            SetDataSetBindingSource("SPDS_SP_rptUndeliveredMCReport");
            dstReportTableAdapters.SPDS_SP_rptUndeliveredMCReportTableAdapter dtbReport = new dstReportTableAdapters.SPDS_SP_rptUndeliveredMCReportTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.SPDS_SP_rptUndeliveredMCReport, @From, @To);

            rpParameters.Add(new ReportParameter("FromDate", From));
            rpParameters.Add(new ReportParameter("ToDate", To));

            if (dstCurrentReport.SPDS_SP_rptUndeliveredMCReport.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.SPDS_SP_rptUndeliveredMCReport.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"UndeliveredMC_Report\UndeliveredMC_Report.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void RPT_RemittanceReceivedSFG(string @From, string @To, bool ShowReport)
        {
            SetDataSetBindingSource("SPDS_SP_rptRemittanceReceivedSFG");
            dstReportTableAdapters.SPDS_SP_rptRemittanceReceivedSFGTableAdapter dtbReport = new dstReportTableAdapters.SPDS_SP_rptRemittanceReceivedSFGTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.SPDS_SP_rptRemittanceReceivedSFG, @From, @To);

            rpParameters.Add(new ReportParameter("FromDate", From));
            rpParameters.Add(new ReportParameter("ToDate", To));

            if (dstCurrentReport.SPDS_SP_rptRemittanceReceivedSFG.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.SPDS_SP_rptRemittanceReceivedSFG.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"RemittanceReceived\RemittanceReceived.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void RPT_RejectedTransactionProcessed(string @From, string @To, bool ShowReport)
        {
            SetDataSetBindingSource("SPDS_SP_rptRejectedTransactionProcessed");
            dstReportTableAdapters.SPDS_SP_rptRejectedTransactionProcessedTableAdapter dtbReport = new dstReportTableAdapters.SPDS_SP_rptRejectedTransactionProcessedTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.SPDS_SP_rptRejectedTransactionProcessed, @From, @To);

            rpParameters.Add(new ReportParameter("FromDate", From));
            rpParameters.Add(new ReportParameter("ToDate", To));

            if (dstCurrentReport.SPDS_SP_rptRejectedTransactionProcessed.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.SPDS_SP_rptRejectedTransactionProcessed.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"RejectedTransaction\RejectedTransaction.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void RPT_UnClaimAging(string @From, string @To, bool ShowReport)
        {
            SetDataSetBindingSource("SPDS_SP_rptUnClaimAging");
            dstReportTableAdapters.SPDS_SP_rptUnClaimAgingTableAdapter dtbReport = new dstReportTableAdapters.SPDS_SP_rptUnClaimAgingTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.SPDS_SP_rptUnClaimAging, @From, @To);

            rpParameters.Add(new ReportParameter("FromDate", From));
            rpParameters.Add(new ReportParameter("ToDate", To));

            if (dstCurrentReport.SPDS_SP_rptUnClaimAging.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.SPDS_SP_rptUnClaimAging.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"UnClaimAging\UnClaimAging.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void RPT_UnPaidRemittance(string @From, string @To, bool ShowReport)
        {
            SetDataSetBindingSource("SPDS_SP_rptUnPaidRemittance");
            dstReportTableAdapters.SPDS_SP_rptUnPaidRemittanceTableAdapter dtbReport = new dstReportTableAdapters.SPDS_SP_rptUnPaidRemittanceTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.SPDS_SP_rptUnPaidRemittance, @From, @To);

            rpParameters.Add(new ReportParameter("FromDate", From));
            rpParameters.Add(new ReportParameter("ToDate", To));

            if (dstCurrentReport.SPDS_SP_rptUnPaidRemittance.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.SPDS_SP_rptUnPaidRemittance.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"PaidRemittance\UnPaidRemittance.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void RPT_PaidRemittance(string @From, string @To, bool ShowReport)
        {
            SetDataSetBindingSource("SPDS_SP_rptPaidRemittance");
            dstReportTableAdapters.SPDS_SP_rptPaidRemittanceTableAdapter dtbReport = new dstReportTableAdapters.SPDS_SP_rptPaidRemittanceTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.SPDS_SP_rptPaidRemittance, @From, @To);

            rpParameters.Add(new ReportParameter("FromDate", From));
            rpParameters.Add(new ReportParameter("ToDate", To));

            if (dstCurrentReport.SPDS_SP_rptPaidRemittance.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.SPDS_SP_rptPaidRemittance.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"PaidRemittance\PaidRemittance.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void RPT_DetailStatusCode(bool ShowReport)
        {
            SetDataSetBindingSource("SPDS_SP_rptDetailStatusCode");
            dstReportTableAdapters.SPDS_SP_rptDetailStatusCodeTableAdapter dtbReport = new dstReportTableAdapters.SPDS_SP_rptDetailStatusCodeTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.SPDS_SP_rptDetailStatusCode);

            if (dstCurrentReport.SPDS_SP_rptDetailStatusCode.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.SPDS_SP_rptDetailStatusCode.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"DetailCode_Report\DetailCodeReport.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void RPT_RTGSReport(string Date,string DeptManager,string Department, bool ShowReport)
        {
            SetDataSetBindingSource("SPDS_SP_rptRTGSReport");
            dstReportTableAdapters.SPDS_SP_rptRTGSReportTableAdapter dtbReport = new dstReportTableAdapters.SPDS_SP_rptRTGSReportTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.SPDS_SP_rptRTGSReport,@Date);

            rpParameters.Add(new ReportParameter("FromDate", Date));
            rpParameters.Add(new ReportParameter("Department", Department));
            rpParameters.Add(new ReportParameter("DeptManager", DeptManager));

            if (dstCurrentReport.SPDS_SP_rptRTGSReport.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.SPDS_SP_rptRTGSReport.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"RTGS_Report\RTGS_Report.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }

        public void RPT_STBTReportFormat(int CorrespondingBankID, string FromDate, string ToDate, bool ShowReport)
        {
            SetDataSetBindingSource("SPDS_SP_rptSTBTReportFormat");
            dstReportTableAdapters.SPDS_SP_rptSTBTReportFormatTableAdapter dtbReport = new dstReportTableAdapters.SPDS_SP_rptSTBTReportFormatTableAdapter();
            dtbReport.ClearBeforeFill = true;
            dtbReport.Connection = ConnectionMaker();
            //dtbReport.SelectCommandTimeout = 0;
            dtbReport.Fill(dstCurrentReport.SPDS_SP_rptSTBTReportFormat, @CorrespondingBankID,@FromDate,@ToDate);

            rpParameters.Add(new ReportParameter("FromDate", FromDate));
            rpParameters.Add(new ReportParameter("ToDate", ToDate));

            if (dstCurrentReport.SPDS_SP_rptSTBTReportFormat.Rows.Count > 0)
            {
                RowCount = dstCurrentReport.SPDS_SP_rptSTBTReportFormat.Rows.Count;
                SetReportViewer(dsrReport, dsrParameter, @"STBT Report\STBTReport.rdlc", ShowReport);
            }
            else
            {
                RowCount = 0;
                Session["RowCount"] = 0;
                NoReportDataMessage();
            }
        }
        
        #endregion
    }
}

