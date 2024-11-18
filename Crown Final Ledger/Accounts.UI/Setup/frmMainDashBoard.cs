using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accounts.BLL;
using Accounts.Common;
using Accounts.EL;
using MetroFramework.Forms;
namespace Accounts.UI
{
    public partial class frmMainDashBoard : MetroForm
    {
        #region Variables
        UserModulesBLL manager = new UserModulesBLL();
        frmCompanyProjectInfo cpinfo = null;
        frmLogin frmlogin = null;
        frmInventoryIssuance frmissuance = null;
        frmGatePassReports frmgatepassmiscreports = null;
        //frmChartOfAccounts frmAccounts = null;
        frmAccounts frmAccounts = null;
        frmVouchers frmvouchers = null;
        frmSalesManLedger frmsaleManLedger = null;
        frmSales frmsales = null;
        frmUsers frmusers = null;
        frmOpeningBalance frmopeningbalance = null;
        //frmOpeningBalancesByType frmOpeningType = null;
        frmAccountsOpeningBalanceByTypeAndHeads frmOpeningType = null;
        frmPriceList frmpricelist = new frmPriceList();
        frmStockReceipt frmstockreceipt = null;
        frmPosPurchases frmpospurchase = null;
        frmPosPurchasesReturn frmpospurchasereturn = null;
        frmStockReturn frmstockReturn = null;
        frmgeneralLedger frmledger = null;
        frmExpenses frmExpense = null;
        frmSubHeadExpenses frmsubheadexpense;
        frmSalesReturn frmSaleReturn = null;
        frmInvoicesDateChange frmchangeinvoice = null;
        frmAccountBalance frmAccountbalanceReport = null;
        frmBackup frmbackup = null;
        frmUnpostedVouchers frmunpostedVouchers = null;
        frmIncomeStatement frmincomestatement = null;
        //frmPrescriberSample frmprescriberSample = null;
        frmSaleReports frmSaleReport = null;
        frmJournalVoucher frmjournalvoucher = null;
        frmTrialBalance frmtrialbalance = null;
        frmMiniTrialBalance frmminitrialbalance = null;
        frmDetailedJournalLedger frmDetailLedger;
        frmTotalStock frmtotalStock;
        frmPersons frmPerson;
        frmStockItems frmstockitems;
        frmCompany frmCompanies;
        frmModulesRights frmModuleRights;
        frmModulesPermissions frmModulesPermission;
        frmChangePassword frmchangePassword;
        frmUsersRoles frmuserRoles;
        frmUOM frmAllUOMS = null;
        frmProducts frmProduct = null;
        frmHeadsSetup frmheadsSetup = null;
        frmSamples frmSample = null;
        frmSamplesReturn frmSampleReturn = null;
        frmCategories frmcategories = null;
        frmSampleReports frmsampleReports = null;
        frmRecoveryReport frmrecoveryReport = null;
        frmSampleSaleDays frmsamplesaledays = null;
        frmMonthlySalesReport frmmonthlySaleReport = null;
        frmMonthlyClaimReport frmmonthlyClaimReturn = null;
        frmCurrentStock frmcurrentStock = null;
        frmProductLedger frmproductledger = null;
        frmBusinessVolume frmbusinessvolume = null;
        frmLowStock frmlowstockreport;
        frmUserActivityReport frmuseractivityreport = null;
        frmStockRatesCalculation frmstockrates = null;
        frmInventoryIssuance frminventoryissuance;
        frmSalesMainSummaryWithReturn frmsalemansalesummary;
        frmProjectWiseDatedSales frmallprojectsales;
        frmDistributionSales frmdistributionSale;
        frmDistributionSalesReturn frmdistributionreturn;
        frmDayBook frmdaybook;
        frmDayBookDetail frmdaybooklongformat;
        frmEmployeesMonthlyReport frmmonthlyperformance;
        frmPartyWiseSaleSummary frmpartywisesalesummary;
        frmAgingReport frmagingreportshow;
        frmFifoAgingReport frmfifoawisegingreport;
        frmBalanceSheet frmbalanceSheet;
        frmClosingBalancesReports frmclosingbalancesreports;
        frmProjects frmprojectsSetup;
        frmStockReturnAdjustmentSetup frmStockReturnAdjustments;
        frmTradingCo frmtradingCo = null;
        frmMonthlySalesReport frmmonthlySalesReport = null;
        frmAvailableModules frmextraModules = null;
        frmMonthlyPurchasesReport frmMonthlyPurchaseSaleReports = null;
        frmTopSellingAndReturningItems frmtopStock = null;
        frmCustomersProfitAndLoss frmcustomerwiseprofitLoss = null;
        frmCashBook frmcashbookdetail = null;
        frmProductsChart frmcompanyproductschart = null;
        frmProductWiseProfitLoss frmproductsProfitLoss = null;
        frmAllProductsWiseProfitLoss frmallproductsprofitandloss = null;
        frmDatedCashPaidExpense frmdatedexpenses = null;
        frmCustomerWiseProductsProfitAndLoss frmcustomersproductsProfitLoss = null;
        frmAllProductsInOutWithAvg frmallproductsinoutwithaverage = null;
        frmDailyBusinessActivities frmdailyactivity = null;
        frmPosInvoice frmposinvoice = null;
        frmPosReturn frmposreturninvoice = null;
        frmCustomersWiseDiscountSummary frmcustomersdiscountsummary = null;
        frmCustomersSalesInvoices frmadjustcustomerbalance;
        #region OutSource Related Variables
        frmOutSourceWork frmoutsource = null;
        frmOutSourceWorkTypes frmoutsourceworks;
        #endregion
        #endregion
        #region Form Related Methods and events
        public frmMainDashBoard()
        {
            InitializeComponent();
        }
        private void frmMainDashBoard_Load(object sender, EventArgs e)
        {
            if (Operations.UserName != null)
            {
                UserNameStatus.Text = Operations.UserName.ToUpper();
            }
            if (Operations.CompanyName != string.Empty)
            {
                toolStripCompanyName.Text = Operations.CompanyName;
            }
            if (Operations.ProjectName != string.Empty)
            {
                toolStripProjectName.Text = Operations.ProjectName;
            }
            FillModules();
        }
        private void FillModules()
        {
            var manager = new ModulesBLL();
            List<ModulesEL> list = manager.GetAllModules();

            if (list.Count > 0)
            {
                List<ModulesEL> listEnabledModules = list.FindAll(x => x.IsEnabled == false);
                if (listEnabledModules.Count > 0)
                {
                    //EnableDisableModules(listEnabledModules);
                    //MultiEnableDisableModules(listEnabledModules);
                }
            }
        }
        private string SoftwareType()
        {
            string SoftwareType = string.Empty;
            List<SoftwareTypesEL> list = DataOperations.SoftwareTypes;
            if (list.Count > 0)
            {
                SoftwareTypesEL objActiveType = list.Find(x => x.ActiveSoftware == true);
                SoftwareType = objActiveType.SoftwareType;
            }
            return SoftwareType;
        }
        #endregion
        //private void EnableDisableModules(List<ModulesEL> list)
        //{
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        if (list[i].ModuleName == "Account Balances")
        //        {
        //            rbnBtnBalances.Visible = false;
        //        }
        //        else if (list[i].ModuleName == "Detailed Ledger Reports")
        //        {
        //            rbnBtnDetailedLedgerReport.Visible = false;
        //        }
        //        else if (list[i].ModuleName == "Sales Reports")
        //        {
        //            rbnSaleReport.Visible = false;
        //        }
        //        else if (list[i].ModuleName == "Activity Logger")
        //        {
        //            rbnBtnUserActivityLogger.Visible = false;
        //        }
        //        else if (list[i].ModuleName == "Multi Company")
        //        {
        //            rbnBtnCompanies.Visible = false;
        //        }
        //        else if (list[i].ModuleName == "Multi Project")
        //        {
        //            rbnbtnProjects.Visible = false;
        //        }
        //        else if (list[i].ModuleName == "Trial Balance")
        //        {
        //            rbnBtnTrialBalance.Visible = false;
        //        }
        //        else if (list[i].ModuleName == "Mini Trial Balance")
        //        {
        //            rbnBtnMiniTrial.Visible = false;
        //        }
        //        else if (list[i].ModuleName == "Income Statement")
        //        {
        //            rbnBtnIncome.Visible = false;
        //        }
        //        else if (list[i].ModuleName == "Balance Sheet")
        //        {
        //            rbnBtnBalanceSheet.Visible = false;
        //        }
        //        else if (list[i].ModuleName == "Closing Balances")
        //        {
        //            rbnBtnClosingBalance.Visible = false;
        //        }
        //        else if (list[i].ModuleName == "Aging Report")
        //        {
        //            rbnBtnAgingReport.Visible = false;
        //        }
        //        else if (list[i].ModuleName == "Fifo Aging Report")
        //        {
        //            rbnBtnFifoAgingReport.Visible = false;
        //        }
        //        else if (list[i].ModuleName == "Business Volume")
        //        {
        //            rbnBtnBusinessVolume.Visible = false;
        //        }
        //        else if (list[i].ModuleName == "Detailed Ledger")
        //        {
        //            rbnBtnDetailedLedgerReport.Visible = false;
        //        }
        //        else if (list[i].ModuleName == "Recovery Report")
        //        {
        //            rbnBtnRecover.Visible = false;
        //        }
        //        else if (list[i].ModuleName == "Short Day Book")
        //        {
        //            rbnBtnShortDayBook.Visible = false;
        //        }
        //        else if (list[i].ModuleName == "Long Day Book")
        //        {
        //            rbnBtnLongDayBookFormat.Visible = false;
        //        }
        //        else if (list[i].ModuleName == "Daily Business Activity")
        //        {
        //            rbnBtnDailyBusinessActivity.Visible = false;
        //        }
        //        else if (list[i].ModuleName == "Head Wise Expenses")
        //        {
        //            rbnBtnHeadWiseExpenseReport.Visible = false;
        //        }
        //        else if (list[i].ModuleName == "Dated Cash Paid Expenses")
        //        {
        //            rbnBtnDatedCashPaid.Visible = false;
        //        }
        //        else if (list[i].ModuleName == "Low Stock Report")
        //        {
        //            rbnBtnLowStockReport.Visible = false;
        //        }
        //        else if (list[i].ModuleName == "Product Ledger Report")
        //        {
        //            rbnBtnProductsLedger.Visible = false;
        //        }
        //        else if (list[i].ModuleName == "Monthly Purchase Report")
        //        {
        //            rbnBtnMonthPurchasesReport.Visible = false;
        //        }
        //        else if (list[i].ModuleName == "Monthly Purchase Return Report")
        //        {
        //            rbnBtnMonthlyPurchasesReturnReport.Visible = false;
        //        }
        //        else if (list[i].ModuleName == "Monthly Sale Report")
        //        {
        //            rbnBtnCustomerWiseReport.Visible = false;
        //        }
        //        else if (list[i].ModuleName == "Monthly Sale Return Report")
        //        {
        //            rbnBtnCustomerWiseSaleReturnReport.Visible = false;
        //        }
        //        else if (list[i].ModuleName == "Party Wise Sale Summary")
        //        {
        //            rbnBtnPartyWiseSaleSummary.Visible = false;
        //        }
        //        else if (list[i].ModuleName == "Customers Profit And Loss")
        //        {
        //            rbnBtnCustomersProfitAndLoss.Visible = false;
        //        }
        //        else if (list[i].ModuleName == "Top Selling Products")
        //        {
        //            rbnBtnTopSellingItems.Visible = false;
        //        }
        //        else if (list[i].ModuleName == "Cash Book")
        //        {
        //            rbnBtnCashBook.Visible = false;
        //        }
        //        else if (list[i].ModuleName == "Product Wise Profit And Loss")
        //        {
        //            rbnBtnProductsProfit.Visible = false;
        //        }
        //        else if (list[i].ModuleName == "All Product Profit And Loss")
        //        {
        //            rbnBtnAllProductsProfit.Visible = false;
        //        }
        //        else if (list[i].ModuleName == "Customer Wise All Products Profit And Loss")
        //        {
        //            rbnBtnCustomerWiseAllProductsProfitLoss.Visible = false;
        //        }
        //        else if (list[i].ModuleName == "All Products IN / Out With Average")
        //        {
        //            rbnBtnAllProductsINOutWithAverage.Visible = false;
        //        }
        //    }
        //}
        //private void MultiEnableDisableModules(List<ModulesEL> list)
        //{
        //    List<ModulesEL> elClosingBalancesModule = list.FindAll(x => x.ModuleName == "Closing Balances" || x.ModuleName == "Aging Report" || x.ModuleName == "Fifo Aging Report");
        //    //if (elClosingBalancesModule != null && elClosingBalancesModule.Count > 0)
        //    {
        //        if (list.Exists(x => x.ModuleName == "Closing Balances"))
        //        {
        //            if (list.Exists(x => x.ModuleName == "Aging Report"))
        //            {
        //                if (list.Exists(x => x.ModuleName == "Fifo Aging Report"))
        //                {
        //                    rbnBtnClosingBalancesType.Visible = false;
        //                }
        //            }
        //        }
        //    }
        //    List<ModulesEL> elDayBookModule = list.FindAll(x => x.ModuleName == "Short Day Book" || x.ModuleName == "Long Day Book");
        //    //if (elClosingBalancesModule != null && elDayBookModule.Count > 0)
        //    {
        //        if (list.Exists(x => x.ModuleName == "Short Day Book"))
        //        {
        //            if (list.Exists(x => x.ModuleName == "Long Day Book"))
        //            {
        //                if (list.Exists(x => x.ModuleName == "Daily Business Activity"))
        //                {
        //                    rbnBtnDayBook.Visible = false;
        //                }
        //            }
        //        }
        //    }

        //    List<ModulesEL> elTrialBalanceModule = list.FindAll(x => x.ModuleName == "Trial Balance" || x.ModuleName == "Mini Trial Balance");
        //    //if (elTrialBalanceModule != null && elTrialBalanceModule.Count > 0)
        //    {
        //        if (list.Exists(x => x.ModuleName == "Trial Balance"))
        //        {
        //            if (list.Exists(x => x.ModuleName == "Mini Trial Balance"))
        //            {
        //                rbnBtnTrial.Visible = false;
        //            }
        //        }
        //    }

        //}
        #region Accounts Related Methods
        private void createNewAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccounts = new frmAccounts();
            frmAccounts.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmAccounts.Show();
            }
            else if (CheckModuleRights(frmAccounts.Name) != 0)
            {
                frmAccounts.Show();
            }
            else
            {
                frmAccounts.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void createNewHeadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmheadsSetup = new frmHeadsSetup();
            frmheadsSetup.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmheadsSetup.Show();
            }
            else if (CheckModuleRights(frmheadsSetup.Name) != 0)
            {
                frmheadsSetup.Show();
            }
            else
            {
                frmheadsSetup.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void openingBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmopeningbalance = new frmOpeningBalance();
            frmopeningbalance.MdiParent = this;
            frmopeningbalance.Show();
        }
        private void viewOpeningBalancesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOpeningType = new frmAccountsOpeningBalanceByTypeAndHeads();
            frmOpeningType.MdiParent = this;
            frmOpeningType.Show();
        }
        private void accountBalancesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccountbalanceReport = new frmAccountBalance();
            frmAccountbalanceReport.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmAccountbalanceReport.Show();
            }
            else if (CheckModuleRights(frmAccountbalanceReport.Name) != 0)
            {
                frmAccountbalanceReport.Show();
            }
            else
            {
                frmAccountbalanceReport.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        #endregion
        #region Users Related Methods
        private void newUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmusers = new frmUsers();
            frmusers.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmusers.Show();
            }
            else if (CheckModuleRights(frmusers.Name) != 0)
            {
                frmusers.Show();
            }
            else
            {
                frmusers.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void userRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmuserRoles = new frmUsersRoles();
            frmuserRoles.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmuserRoles.Show();
            }
            else if (CheckModuleRights(frmuserRoles.Name) != 0)
            {
                frmuserRoles.Show();
            }
            else
            {
                frmuserRoles.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void rbnBtnUserActivityLogger_Click(object sender, EventArgs e)
        {
            frmuseractivityreport = new frmUserActivityReport();
            frmuseractivityreport.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmuseractivityreport.Show();
            }
            else if (CheckModuleRights(frmuseractivityreport.Name) != 0)
            {
                frmuseractivityreport.Show();
            }
            else
            {
                frmuseractivityreport.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmchangePassword = new frmChangePassword();
            frmchangePassword.MdiParent = this;
            frmchangePassword.Show();
        }
        private void modulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmModuleRights = new frmModulesRights();
            frmModuleRights.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmModuleRights.Show();
            }
            else if (CheckModuleRights(frmModuleRights.Name) != 0)
            {
                frmModuleRights.Show();
            }
            else
            {
                frmModuleRights.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void permissionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmModulesPermission = new frmModulesPermissions();
            frmModulesPermission.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmModulesPermission.Show();
            }
            else if (CheckModuleRights(frmModulesPermission.Name) != 0)
            {
                frmModulesPermission.Show();
            }
            else
            {
                frmModulesPermission.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private Int64 CheckModuleRights(string FormName)
        {
            var Manager = new UserModulesBLL();
            List<UserModulesEL> list = manager.GetUserModuleRightsByIdAndForm(Operations.UserID, FormName);
            if (list.Count > 0)
            {
                UserPermissions.IdModule = list[0].IdModule;
                return list[0].IdModule;
            }
            else
            {
                UserPermissions.IdModule = 0;
                return 0;
            }
        }
        private void rbnBtnSignOut_click(object sender, EventArgs e)
        {
            try
            {
                //frmlogin = new frmLogin();
                foreach (Form form in MdiChildren)
                {
                    form.Close();
                }
                if (frmlogin == null)
                {
                    this.Hide();
                    frmlogin = new frmLogin();
                    frmlogin.ShowDialog();
                    this.Dispose(true);
                }
                else
                {
                    frmlogin.ShowDialog();
                }
                //if (!frmlogin.IsDisposed)
                //{
                //    frmlogin.ShowDialog(this);
                //}
                //else
                //{
                //    frmlogin = new frmLogin();
                //    frmlogin.ShowDialog();
                //    //frmlogin.ShowDialog(this);
                //}
                if (Operations.UserName != null)
                {
                    UserNameStatus.Text = Operations.UserName.ToUpper();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured");
            }
        }



        #endregion
        #region Setup Related Methods
        private void availableModulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmextraModules = new frmAvailableModules();
            frmextraModules.MdiParent = this;
            frmextraModules.Show();
        }
        private void companyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCompanies = new frmCompany();
            frmCompanies.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmCompanies.Show();
            }
            else if (CheckModuleRights(frmCompanies.Name) != 0)
            {
                frmCompanies.Show();
            }
            else
            {
                frmCompanies.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void projectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmprojectsSetup = new frmProjects();
            frmprojectsSetup.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmprojectsSetup.Show();
            }
            else if (CheckModuleRights(frmprojectsSetup.Name) != 0)
            {
                frmprojectsSetup.Show();
            }
            else
            {
                frmprojectsSetup.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void customersMetaDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPerson = new frmPersons();
            frmPerson.PersonsType = "Customers";
            frmPerson.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmPerson.Show();
            }
            else if (CheckModuleRights(frmPerson.Name) != 0)
            {
                frmPerson.Show();
            }
            else
            {
                frmPerson.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void suppliersMetaDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPerson = new frmPersons();
            frmPerson.PersonsType = "Suppliers";
            frmPerson.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmPerson.Show();
            }
            else if (CheckModuleRights(frmPerson.Name) != 0)
            {
                frmPerson.Show();
            }
            else
            {
                frmPerson.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void employeesMetaDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPerson = new frmPersons();
            frmPerson.PersonsType = "Employees";
            frmPerson.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmPerson.Show();
            }
            else if (CheckModuleRights(frmPerson.Name) != 0)
            {
                frmPerson.Show();
            }
            else
            {
                frmPerson.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void databaseBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmbackup = new frmBackup();
            frmbackup.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmbackup.Show();
            }
            else if (CheckModuleRights(frmbackup.Name) != 0)
            {
                frmbackup.Show();
            }
            else
            {
                frmbackup.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        #endregion
        #region Stock Products Related Methods
        private void newBrandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmtradingCo = new frmTradingCo();
            frmtradingCo.MdiParent = this;
            frmtradingCo.Show();
        }
        private void newCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmcategories = new frmCategories();
            frmcategories.MdiParent = this;
            frmcategories.Show();
        }
        private void newProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProduct = new frmProducts();
            frmProduct.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmProduct.Show();
            }
            else if (CheckModuleRights(frmProduct.Name) != 0)
            {
                frmProduct.Show();
            }
            else
            {
                frmProduct.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void openingStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmcurrentStock = new frmCurrentStock();
            frmcurrentStock.MdiParent = this;
            frmcurrentStock.Show();
        }
        private void uOMSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAllUOMS = new frmUOM();
            frmAllUOMS.MdiParent = this;
            frmAllUOMS.Show();
        }
        private void companyProductsChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmcompanyproductschart = new frmProductsChart();
            frmcompanyproductschart.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmcompanyproductschart.Show();
            }
            else if (CheckModuleRights(frmcompanyproductschart.Name) != 0)
            {
                frmcompanyproductschart.Show();
            }
            else
            {
                frmcompanyproductschart.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void productsPriceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmpricelist = new frmPriceList();
            frmpricelist.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmpricelist.Show();
            }
            else if (CheckModuleRights(frmpricelist.Name) != 0)
            {
                frmpricelist.Show();
            }
            else
            {
                frmpricelist.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void stockCalculationRatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmstockrates = new frmStockRatesCalculation();
            frmstockrates.MdiParent = this;
            frmstockrates.Show();
        }
        private void stockAdjustmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStockReturnAdjustments = new frmStockReturnAdjustmentSetup();
            frmStockReturnAdjustments.AdjustmentType = 1;
            frmStockReturnAdjustments.MdiParent = this;
            frmStockReturnAdjustments.Show();
        }
        #endregion
        #region Financial Vouchers
        private void cashReceiptVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmvouchers = new frmVouchers();
            frmvouchers.MdiParent = this;
            frmvouchers.VoucherType = VoucherTypes.CashReceiptVoucher.ToString();
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmvouchers.Show();
            }
            else if (CheckModuleRights(frmvouchers.Name + "/Cash Receipts") != 0)
            {
                frmvouchers.Show();
            }
            else
            {
                frmvouchers.Dispose();
                MessageBox.Show("Access Is Denied !");
            }
        }
        private void cashPaymentVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmvouchers = new frmVouchers();
            frmvouchers.MdiParent = this;
            frmvouchers.VoucherType = VoucherTypes.PaymentVoucher.ToString();
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {

                frmvouchers.Show();
            }
            else if (CheckModuleRights(frmvouchers.Name + "/Cash Payments") != 0)
            {
                frmvouchers.MdiParent = this;
                frmvouchers.Show();
            }
            else
            {
                frmvouchers.Dispose();
                MessageBox.Show("Access Is Denied !");
            }
        }
        private void bankReceiptVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmvouchers = new frmVouchers();
            frmvouchers.MdiParent = this;
            frmvouchers.VoucherType = VoucherTypes.BankReceiptVoucher.ToString();
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmvouchers.Show();
            }
            else if (CheckModuleRights(frmvouchers.Name + "/Bank Receipt") != 0)
            {
                frmvouchers.Show();
            }
            else
            {
                frmvouchers.Dispose();
                MessageBox.Show("Access Is Denied !");
            }
        }
        private void bankPaymentVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmvouchers = new frmVouchers();
            frmvouchers.MdiParent = this;
            frmvouchers.VoucherType = VoucherTypes.BankPaymentVoucher.ToString();
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {

                frmvouchers.Show();
            }
            else if (CheckModuleRights(frmvouchers.Name + "/Bank Payment") != 0)
            {
                frmvouchers.Show();
            }
            else
            {
                frmvouchers.Dispose();
                MessageBox.Show("Access Is Denied !");
            }
        }
        private void createJournalVoucherEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmjournalvoucher = new frmJournalVoucher();
            frmjournalvoucher.MdiParent = this;
            frmjournalvoucher.VoucherType = VoucherTypes.JournalVoucher.ToString();
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmjournalvoucher.Show();
            }
            else if (CheckModuleRights(frmjournalvoucher.Name) != 0)
            {
                frmjournalvoucher.Show();
            }
            else
            {
                frmjournalvoucher.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        #endregion
        #region Financial Reports
        private void viewPartyLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmledger = new frmgeneralLedger();
            frmledger.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmledger.Show();
                frmledger.BringToFront();
            }
            else if (CheckModuleRights(frmledger.Name) != 0)
            {
                frmledger.Show();
                frmledger.BringToFront();
            }
            else
            {
                frmledger.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void annualGeneralLedgerForCompanyRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetailLedger = new frmDetailedJournalLedger();
            frmDetailLedger.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmDetailLedger.Show();
            }
            else if (CheckModuleRights(frmDetailLedger.Name) != 0)
            {
                frmDetailLedger.Show();
            }
            else
            {
                frmDetailLedger.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void miniTrialBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmminitrialbalance = new frmMiniTrialBalance();
            frmminitrialbalance.MdiParent = this;

            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmminitrialbalance.Show();
            }
            else if (CheckModuleRights(frmminitrialbalance.Name) != 0)
            {
                frmminitrialbalance.Show();
            }
            else
            {
                frmminitrialbalance.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void fullTrialBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmtrialbalance = new frmTrialBalance();
            frmtrialbalance.MdiParent = this;

            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmtrialbalance.Show();
            }
            else if (CheckModuleRights(frmtrialbalance.Name) != 0)
            {
                frmtrialbalance.Show();
            }
            else
            {
                frmtrialbalance.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void customersRecoveryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmrecoveryReport = new frmRecoveryReport();
            frmrecoveryReport.MdiParent = this;

            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmrecoveryReport.Show();
            }
            else if (CheckModuleRights(frmrecoveryReport.Name) != 0)
            {
                frmrecoveryReport.Show();
            }
            else
            {
                frmrecoveryReport.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void financialClosingBalancesPrintableReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmclosingbalancesreports = new frmClosingBalancesReports();
            frmclosingbalancesreports.MdiParent = this;
            frmclosingbalancesreports.Show();
        }
        private void cashBookReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmcashbookdetail = new frmCashBook();
            frmcashbookdetail.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmcashbookdetail.Show();
            }
            else if (CheckModuleRights(frmcashbookdetail.Name) != 0)
            {
                frmcashbookdetail.Show();
            }
            else
            {
                frmcashbookdetail.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void incomeStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmincomestatement = new frmIncomeStatement();
            frmincomestatement.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmincomestatement.Show();
            }
            else if (CheckModuleRights(frmincomestatement.Name) != 0)
            {
                frmincomestatement.Show();
            }
            else
            {
                frmincomestatement.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void balanceSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmbalanceSheet = new frmBalanceSheet();
            frmbalanceSheet.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmbalanceSheet.Show();
            }
            else if (CheckModuleRights(frmbalanceSheet.Name) != 0)
            {
                frmbalanceSheet.Show();
            }
            else
            {
                frmbalanceSheet.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void agingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmagingreportshow = new frmAgingReport();
            frmagingreportshow.MdiParent = this;

            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmagingreportshow.Show();
            }
            else if (CheckModuleRights(frmagingreportshow.Name) != 0)
            {
                frmagingreportshow.Show();
            }
            else
            {
                frmagingreportshow.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void fifoAgingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmfifoawisegingreport = new frmFifoAgingReport();
            frmfifoawisegingreport.MdiParent = this;

            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmfifoawisegingreport.Show();
            }
            else if (CheckModuleRights(frmfifoawisegingreport.Name) != 0)
            {
                frmfifoawisegingreport.Show();
            }
            else
            {
                frmfifoawisegingreport.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void startDayBusinessVolumeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmbusinessvolume = new frmBusinessVolume();
            frmbusinessvolume.VolumeType = 1;
            frmbusinessvolume.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmbusinessvolume.Show();
            }
            else if (CheckModuleRights(frmbusinessvolume.Name) != 0)
            {
                frmbusinessvolume.Show();
            }
            else
            {
                frmbusinessvolume.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void endDayBusinessVolumneReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmbusinessvolume = new frmBusinessVolume();
            frmbusinessvolume.VolumeType = 2;
            frmbusinessvolume.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmbusinessvolume.Show();
            }
            else if (CheckModuleRights(frmbusinessvolume.Name) != 0)
            {
                frmbusinessvolume.Show();
            }
            else
            {
                frmbusinessvolume.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        #endregion
        #region Expense Reports Region
        private void dailyExpenseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExpense = new frmExpenses();
            frmExpense.MdiParent = this;

            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmExpense.Show();
            }
            else if (CheckModuleRights(frmExpense.Name) != 0)
            {
                frmExpense.Show();
            }
            else
            {
                frmExpense.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void headWiseExpenseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmsubheadexpense = new frmSubHeadExpenses();
            frmsubheadexpense.MdiParent = this;

            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmsubheadexpense.Show();
            }
            else if (CheckModuleRights(frmsubheadexpense.Name) != 0)
            {
                frmsubheadexpense.Show();
            }
            else
            {
                frmsubheadexpense.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void datedCashPaidExpenseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmdatedexpenses = new frmDatedCashPaidExpense();
            frmdatedexpenses.MdiParent = this;

            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmdatedexpenses.Show();
            }
            else if (CheckModuleRights(frmdatedexpenses.Name) != 0)
            {
                frmdatedexpenses.Show();
            }
            else
            {
                frmdatedexpenses.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        #endregion
        #region Activitry Reports
        private void shortDayBookReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmdaybook = new frmDayBook();
            frmdaybook.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmdaybook.Show();
            }
            else if (CheckModuleRights(frmdaybook.Name) != 0)
            {
                frmdaybook.Show();
            }
            else
            {
                frmdaybook.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void longDayBookFormatReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmdaybooklongformat = new frmDayBookDetail();
            frmdaybooklongformat.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmdaybooklongformat.Show();
            }
            else if (CheckModuleRights(frmdaybooklongformat.Name) != 0)
            {
                frmdaybooklongformat.Show();
            }
            else
            {
                frmdaybooklongformat.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void dailyBusinessActivityLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmdailyactivity = new frmDailyBusinessActivities();
            frmdailyactivity.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmdailyactivity.Show();
            }
            else if (CheckModuleRights(frmdailyactivity.Name) != 0)
            {
                frmdailyactivity.Show();
            }
            else
            {
                frmdailyactivity.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void activityLoggerReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmuseractivityreport = new frmUserActivityReport();
            frmuseractivityreport.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmuseractivityreport.Show();
            }
            else if (CheckModuleRights(frmuseractivityreport.Name) != 0)
            {
                frmuseractivityreport.Show();
            }
            else
            {
                frmuseractivityreport.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        #endregion
        #region Stock Reports
        private void stockAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmtotalStock = new frmTotalStock();
            frmtotalStock.MdiParent = this;
            frmtotalStock.Show();
        }
        private void productLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmproductledger = new frmProductLedger();
            frmproductledger.MdiParent = this;
            frmproductledger.Show();
        }
        private void lowStockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmlowstockreport = new frmLowStock();
            frmlowstockreport.MdiParent = this;
            frmlowstockreport.Show();
        }
        private void productsProfitLossToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmproductsProfitLoss = new frmProductWiseProfitLoss();
            frmproductsProfitLoss.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmproductsProfitLoss.Show();
            }
            else if (CheckModuleRights(frmproductsProfitLoss.Name) != 0)
            {
                frmproductsProfitLoss.Show();
            }
            else
            {
                frmproductsProfitLoss.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void allProductsProiftLossReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmallproductsprofitandloss = new frmAllProductsWiseProfitLoss();
            frmallproductsprofitandloss.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmallproductsprofitandloss.Show();
            }
            else if (CheckModuleRights(frmallproductsprofitandloss.Name) != 0)
            {
                frmallproductsprofitandloss.Show();
            }
            else
            {
                frmallproductsprofitandloss.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void customWiseProductProfitLossReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmcustomersproductsProfitLoss = new frmCustomerWiseProductsProfitAndLoss();
            frmcustomersproductsProfitLoss.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmcustomersproductsProfitLoss.Show();
            }
            else if (CheckModuleRights(frmcustomersproductsProfitLoss.Name) != 0)
            {
                frmcustomersproductsProfitLoss.Show();
            }
            else
            {
                frmcustomersproductsProfitLoss.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void allProductsINOUTReportWithToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmallproductsinoutwithaverage = new frmAllProductsInOutWithAvg();
            frmallproductsinoutwithaverage.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmallproductsinoutwithaverage.Show();
            }
            else if (CheckModuleRights(frmallproductsinoutwithaverage.Name) != 0)
            {
                frmallproductsinoutwithaverage.Show();
            }
            else
            {
                frmallproductsinoutwithaverage.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        #endregion
        #region Sales Forms
        private void createNewSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmsales = new frmSales();
            frmsales.MdiParent = this;
            frmsales.IsImportTransaction = false;
            //frmsales.IsNetTransaction = false;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmsales.Show();
            }
            else if (CheckModuleRights(frmsales.Name) != 0)
            {
                frmsales.Show();
            }
            else
            {
                frmsales.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void createNewSaleReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSaleReturn = new frmSalesReturn();
            frmSaleReturn.MdiParent = this;
            //frmSaleReturn.IsNetTransaction = true;
            frmSaleReturn.IsImportTransaction = true;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmSaleReturn.Show();
            }
            else if (CheckModuleRights(frmSaleReturn.Name) != 0)
            {
                frmSaleReturn.Show();
            }
            else
            {
                frmSaleReturn.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void salesReturnAdjustmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStockReturnAdjustments = new frmStockReturnAdjustmentSetup();
            frmStockReturnAdjustments.AdjustmentType = 2;
            frmStockReturnAdjustments.MdiParent = this;
            frmStockReturnAdjustments.Show();
        }
        #endregion
        #region Purchase Forms
        private void createNewPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmstockreceipt = new frmStockReceipt();
            frmstockreceipt.MdiParent = this;
            //frmstockreceipt.IsNetTransaction = false;
            frmstockreceipt.IsImportTransaction = false;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmstockreceipt.Show();
            }
            else if (CheckModuleRights(frmstockreceipt.Name) != 0)
            {
                frmstockreceipt.Show();
            }
            else
            {
                frmstockreceipt.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void createNewPurchaseReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmstockReturn = new frmStockReturn();
            frmstockReturn.MdiParent = this;
            frmstockReturn.IsImport = false;
            //frmstockReturn.IsNetTransaction = false;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmstockReturn.Show();
            }
            else if (CheckModuleRights(frmstockReturn.Name) != 0)
            {
                frmstockReturn.Show();
            }
            else
            {
                frmstockReturn.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        #endregion
        #region Purchase Reports
        private void allPurchasesReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSaleReport = new frmSaleReports();
            frmSaleReport.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmSaleReport.ReportType = "Purchase";
                frmSaleReport.Show();
            }
            else if (CheckModuleRights(frmSaleReport.Name) != 0)
            {
                frmSaleReport.ReportType = "Purchase";
                frmSaleReport.Show();
            }
            else
            {
                frmSaleReport.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void monthlyPurchaseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMonthlyPurchaseSaleReports = new frmMonthlyPurchasesReport();
            frmMonthlyPurchaseSaleReports.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmMonthlyPurchaseSaleReports.ReportType = 1;
                frmMonthlyPurchaseSaleReports.Show();
            }
            else if (CheckModuleRights(frmMonthlyPurchaseSaleReports.Name + "/P") != 0)
            {
                frmMonthlyPurchaseSaleReports.ReportType = 1;
                frmMonthlyPurchaseSaleReports.Show();
            }
            else
            {
                frmMonthlyPurchaseSaleReports.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void monthlyPurchaseReturnReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMonthlyPurchaseSaleReports = new frmMonthlyPurchasesReport();
            frmMonthlyPurchaseSaleReports.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmMonthlyPurchaseSaleReports.ReportType = 2;
                frmMonthlyPurchaseSaleReports.Show();
            }
            else if (CheckModuleRights(frmMonthlyPurchaseSaleReports.Name + "/PR") != 0)
            {
                frmMonthlyPurchaseSaleReports.ReportType = 2;
                frmMonthlyPurchaseSaleReports.Show();
            }
            else
            {
                frmMonthlyPurchaseSaleReports.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        #endregion

        #region Sales Reports
        private void allSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSaleReport = new frmSaleReports();
            frmSaleReport.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmSaleReport.ReportType = "Sale";
                frmSaleReport.Show();
            }
            else if (CheckModuleRights(frmSaleReport.Name) != 0)
            {
                frmSaleReport.ReportType = "Sale";
                frmSaleReport.Show();
            }
            else
            {
                frmSaleReport.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void monthlySalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmmonthlySaleReport = new frmMonthlySalesReport();
            frmmonthlySaleReport.MdiParent = this;
            frmmonthlySaleReport.Show();
        }
        private void partyWiseSaleSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void topSellingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmtopStock = new frmTopSellingAndReturningItems();
            frmtopStock.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmtopStock.Show();
            }
            else if (CheckModuleRights(frmtopStock.Name) != 0)
            {
                frmtopStock.Show();
            }
            else
            {
                frmtopStock.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void customerWiseMonthlySaleReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMonthlyPurchasesReport frmMonthlySaleReports = new frmMonthlyPurchasesReport();
            frmMonthlySaleReports.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmMonthlySaleReports.ReportType = 3;
                frmMonthlySaleReports.Show();
            }
            else if (CheckModuleRights(frmMonthlySaleReports.Name + "/S") != 0)
            {
                frmMonthlySaleReports.ReportType = 3;
                frmMonthlySaleReports.Show();
            }
            else
            {
                frmMonthlySaleReports.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void customerWiseMonthlySaleReturnReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMonthlyPurchasesReport frmMonthlySaleReports = new frmMonthlyPurchasesReport();
            frmMonthlySaleReports.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmMonthlySaleReports.ReportType = 4;
                frmMonthlySaleReports.Show();
            }
            else if (CheckModuleRights(frmMonthlySaleReports.Name + "/SR") != 0)
            {
                frmMonthlySaleReports.ReportType = 4;
                frmMonthlySaleReports.Show();
            }
            else
            {
                frmMonthlySaleReports.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void claimReturnReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmmonthlyClaimReturn = new frmMonthlyClaimReport();
            frmmonthlyClaimReturn.MdiParent = this;
            frmmonthlyClaimReturn.Show();
        }
        private void marketSampleReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void customersDicountReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmcustomersdiscountsummary = new frmCustomersWiseDiscountSummary();
            frmcustomersdiscountsummary.MdiParent = this;
            frmcustomersdiscountsummary.Show();
        }
        private void customersProfitLossReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmcustomerwiseprofitLoss = new frmCustomersProfitAndLoss();
            frmcustomerwiseprofitLoss.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeLong(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeLong(EnRoles.Administrator))
            {
                frmcustomerwiseprofitLoss.Show();
            }
            else if (CheckModuleRights(frmcustomerwiseprofitLoss.Name) != 0)
            {
                frmcustomerwiseprofitLoss.Show();
            }
            else
            {
                frmcustomerwiseprofitLoss.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void salesManOrderBookerReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SoftwareType() == "Distribution Trading")
            {
                frmmonthlyperformance = new frmEmployeesMonthlyReport();
                frmmonthlyperformance.MdiParent = this;
                frmmonthlyperformance.Show();
            }
            else
            {
                frmsaleManLedger = new frmSalesManLedger();
                frmsaleManLedger.MdiParent = this;
                frmsaleManLedger.Show();
            }
        }
        #endregion
    }
}
