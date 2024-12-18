﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Accounts.BLL;
using Accounts.EL;
using SpreadsheetLight;
using System.Diagnostics;

using MetroFramework.Forms;
using Accounts.Common;

namespace Accounts.UI
{
    public partial class frmSaleReports : MetroForm
    {
        #region Variables
        string AccountNo = string.Empty;
        string ItemNo = string.Empty;
        frmFindAccounts frmaccounts = null;
        frmFindProducts frmfindProducts = null;
        public string ReportType { get; set; }
        #endregion
        #region Form Methods And Events
        public frmSaleReports()
        {
            InitializeComponent();
        }
        private void frmSaleReports_Load(object sender, EventArgs e)
        {
            //ddlReportTypes.SelectedIndex = 0;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            GrpProductSale.Visible = false;
            GrpPersonsale.Visible = false;
            pnlPersonSaleDate.Visible = false;
            pnlProductSaleDate.Visible = false;
            pnlReportsGrid.Visible = false;
            RenameControls();
            FillComboDetail();
        }
        private void RenameControls()
        {
            if (ReportType == "Purchase")
            {
                GrpPersonsale.Text = "Supplier Purchase Information";
                GrpProductSale.Text = "Prodcut Purchase";
                this.Text = "Purchase Report";
            }
            else
            {
                GrpPersonsale.Text = "Customer Sale Information";
            }
        }
        private void FillComboDetail()
        {
            if (ReportType == "Sale")
            {
                ddlReportTypes.Items.Insert(0, "Choose");
                ddlReportTypes.Items.Insert(1, "Customer Sale Report");
                ddlReportTypes.Items.Insert(2, "Product Sale Report");
                ddlReportTypes.Items.Insert(3, "Total Stock Sale Report");
                ddlReportTypes.Items.Insert(4, "DateWise Total Stock Sale Report");

                ddlReportTypes.SelectedIndex = 0;
            }
            else
            {
                ddlReportTypes.Items.Insert(0, "Choose");
                ddlReportTypes.Items.Insert(1, "Supplier Purchase Report");
                ddlReportTypes.Items.Insert(2, "Product Purchase Report");
                ddlReportTypes.Items.Insert(3, "Total Stock Purchase Report");
                ddlReportTypes.Items.Insert(4, "DateWise Total Stock Purchase Report");

                ddlReportTypes.SelectedIndex = 0;
            }
        }
        #endregion
        #region Simple Methods
        private void ClearControls()
        {
            PsEditBox.Text = string.Empty;
            PEditBox.Text = string.Empty;
            grdReports.Rows.Clear();
            chkPersonDate.Checked = false;
            chkProductDate.Checked = false;           
        }
        private void ShowAndHideChildPanels(bool VisibleValue, Panel ParentPanel)
        {
            if (false == VisibleValue && ParentPanel.Name == "pnlPersonSaleDate")
            {
                pnlPersonSaleDate.Visible = false;
            }
            else if (true == VisibleValue && ParentPanel.Name == "pnlPersonSaleDate")
            {
                pnlPersonSaleDate.Visible = true;
            }
            else if (false == VisibleValue && ParentPanel.Name == "pnlProductSaleDate")
            {
                pnlProductSaleDate.Visible = false;
            }
            else if (true == VisibleValue && ParentPanel.Name == "pnlProductSaleDate")
            {
                pnlProductSaleDate.Visible = true;
            }

        }
        private void ShowAndGridColumns()
        {
            if (ddlReportTypes.SelectedIndex == 0)
            {

            }
            else if (ddlReportTypes.SelectedIndex == 1)
            {
                grdReports.Columns[2].Visible = true;
                grdReports.Columns[3].Visible = true;

                grdReports.Columns[0].Visible = false;  // VoucherNoColumn
                grdReports.Columns[1].Visible = false;
                grdReports.Columns[4].Visible = false; // PersonNameColumn
                grdReports.Columns[6].Visible = false; // unitpricecolumn
            }
            else if (ddlReportTypes.SelectedIndex == 2)
            {
                grdReports.Columns[0].Visible = true;
                grdReports.Columns[1].Visible = true;
                grdReports.Columns[3].Visible = true;
                grdReports.Columns[4].Visible = true;
                grdReports.Columns[5].Visible = true;
                grdReports.Columns[6].Visible = true;


                grdReports.Columns[2].Visible = false;
                grdReports.Columns[3].Visible = false;
            }
            else if (ddlReportTypes.SelectedIndex == 3)
            {
                //Setting Columns Visible True
                grdReports.Columns[2].Visible = true;
                grdReports.Columns[3].Visible = true;

                //Setting Columns Visible False
                grdReports.Columns[0].Visible = false;  // VoucherNoColumn
                grdReports.Columns[1].Visible = false;
                grdReports.Columns[4].Visible = false; // PersonNameColumn
                grdReports.Columns[5].Visible = true;

                grdReports.Columns[6].Visible = false; // PersonNameColumn

                GetBindingListByCode(3, "");
            }
            else if (ddlReportTypes.SelectedIndex == 4)
            {
                grdReports.Columns[2].Visible = true;

                //Setting Columns Visible False
                grdReports.Columns[0].Visible = false;  // VoucherNoColumn
                grdReports.Columns[1].Visible = false;
                grdReports.Columns[4].Visible = false; // PersonNameColumn
                
                grdReports.Columns[6].Visible = true; // PersonNameColumn
            }
        }
        #endregion
        #region Win Controls Events
        private void ddlReportTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlPersonSaleDate.Visible = false;
            pnlProductSaleDate.Visible = false;
            pnlDateWiseStock.Visible = false;
            ClearControls();
            if (ddlReportTypes.SelectedIndex == 0)
            {
                GrpProductSale.Visible = false;
                GrpPersonsale.Visible = false;
                pnlDateWiseStock.Visible = false;
            }
            else if (ddlReportTypes.SelectedIndex == 1)
            {                
                GrpPersonsale.Visible = true;

                GrpProductSale.Visible = false;
                pnlReportsGrid.Visible = false;
                pnlDateWiseStock.Visible = false;
            }
            else if (ddlReportTypes.SelectedIndex == 2)
            {
                GrpPersonsale.Visible = false;
                GrpProductSale.Visible = true;

                pnlReportsGrid.Visible = false;
                pnlDateWiseStock.Visible = false;
            }
            else if (ddlReportTypes.SelectedIndex == 3)
            {
                GrpPersonsale.Visible = false;
                GrpProductSale.Visible = false;
                pnlDateWiseStock.Visible = false;

                pnlReportsGrid.Visible = true;
            }
            else if (ddlReportTypes.SelectedIndex == 4)
            {
                GrpPersonsale.Visible = false;
                GrpProductSale.Visible = false;
                
                pnlReportsGrid.Visible = true;
                pnlDateWiseStock.Visible = true;
            }
            ShowAndGridColumns();
        }
        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkSaleDates = sender as CheckBox;
            if (chkSaleDates.Name == "chkPersonDate")
            {
                if (chkSaleDates.Checked)
                {
                    ShowAndHideChildPanels(true, pnlPersonSaleDate);
                }
                else
                {
                    ShowAndHideChildPanels(false, pnlPersonSaleDate);
                }
            }
            else
            {
                if (chkSaleDates.Checked)
                {
                    ShowAndHideChildPanels(true, pnlProductSaleDate);
                }
                else
                {
                    ShowAndHideChildPanels(false, pnlProductSaleDate);
                }
            }
        }
        #endregion
        #region Button Events
        private void btnReport_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Name == "btnPersonReport")
            {
                GetBindingListByCode(1, AccountNo);
            }
            else if (btn.Name == "btnProductReport")
            {
                GetBindingListByCode(2, ItemNo);
            }
            else if (btn.Name == "btnDateWiseStockReport")
            {
                GetBindingListByCode(4, "");
            }
        }
        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            if (grdReports.Rows.Count > 0)
            {
                DataTable dt = new DataTable();

                //Adding the Columns
                foreach (DataGridViewColumn column in grdReports.Columns)
                {
                    if (column.Visible)
                    {
                        dt.Columns.Add(column.HeaderText);
                    }
                }

                //Add Header Rows....
                dt.Rows.Add();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    dt.Rows[0][i] = dt.Columns[i].ColumnName; //"Account Name"; 
                }

                // Add Empty Row....
                dt.Rows.Add();
                for (int i = 0; i < grdReports.Columns.Count; i++)
                {
                    if (i != dt.Columns.Count)
                    {
                        dt.Rows[1][i] = "";
                    }
                    else
                    {
                        break;
                    }
                }

                foreach (DataGridViewRow row in grdReports.Rows)
                {
                    dt.Rows.Add();
                    int colindex = 0;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null)
                        {
                            if (cell.Visible)
                            {
                                //dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                                dt.Rows[dt.Rows.Count - 1][colindex] = cell.Value.ToString();
                                colindex++;
                            }
                        }
                    }
                }

                SLDocument slExcelExport = new SLDocument();


                for (int i = 0; i < dt.Columns.Count; i++)
                {

                    slExcelExport.SetColumnWidth(i, 20);
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        slExcelExport.SetCellValue(j + 1, i + 1, dt.Rows[j].ItemArray[i].ToString());
                    }
                }
                slExcelExport.Save();

                Process.Start("Book1.xlsx");


            }
        }
        #endregion
        #region Cutom Events
        private void PsEditBox_ButtonClick(object sender, EventArgs e)
        {
            frmaccounts = new frmFindAccounts();
            frmaccounts.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmaccounts_ExecuteFindAccountEvent);
            frmaccounts.ShowDialog(this);
        }
        private void PsEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
            {
                    e.Handled = true;
                    frmaccounts = new frmFindAccounts();
                    frmaccounts.SearchText = e.KeyChar.ToString();
                    frmaccounts.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmaccounts_ExecuteFindAccountEvent);
                    frmaccounts.ShowDialog();
                
            }
            else
                e.Handled = false;
        }
        void frmaccounts_ExecuteFindAccountEvent(object Sender, AccountsEL oelAccount)
        {
            if (oelAccount!= null)
            {
                AccountNo = oelAccount.AccountNo;
                PsEditBox.Text = oelAccount.AccountName;
            }
        }
        private void PEditBox_ButtonClick(object sender, EventArgs e)
        {
            frmfindProducts = new frmFindProducts();
            frmfindProducts.ExecuteFindPorudctsEvent += new frmFindProducts.FindProductsDelegate(frmfindProducts_ExecuteFindPorudctsEvent);
            frmfindProducts.ShowDialog(this);
        }
        private void PEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
            {
                frmfindProducts = new frmFindProducts();
                frmfindProducts.ExecuteFindPorudctsEvent += new frmFindProducts.FindProductsDelegate(frmfindProducts_ExecuteFindPorudctsEvent);
                frmfindProducts.SearchText = e.KeyChar.ToString();
                frmfindProducts.ShowDialog(this);
                e.Handled = true;
            }
            else if (e.KeyChar == (char)Keys.Back)
            {

            }
            else
                e.Handled = true;
        }
        void frmfindProducts_ExecuteFindPorudctsEvent(object Sender, ItemsEL oelItems)
        {
            if (oelItems != null)
            {
                PEditBox.Text = oelItems.ItemName;
                ItemNo = oelItems.ItemNo;
               //txtItemName.Text = oelItems.ItemName;
            }
        }
        #endregion
        #region Binding Methods
        private void GetBindingListByCode(short BindingListCode,string AccountNo)
        {
            var SaleManager = new SalesDetailBLL();
            var PurchaseManager = new PurchaseDetailBLL();
            List<SaleDetailEL> listSale = null;
            List<PurchaseDetailEL> listPurchase = null;
            if (BindingListCode == 1 && AccountNo != string.Empty)
            {
                if (ReportType == "Sale")
                {
                    if (chkPersonDate.Checked)
                    {
                        listSale = SaleManager.GetCustomerSaleByDate(AccountNo, Operations.IdProject, dtPrescriberStart.Value, dtPrescriberEnd.Value);
                    }
                    else
                    {
                        listSale = SaleManager.GetCustomerSale(Validation.GetSafeLong(AccountNo),Operations.IdProject);
                    }
                }
                else if (ReportType == "Purchase")
                {
                    if (chkPersonDate.Checked)
                    {
                        listPurchase = PurchaseManager.GetSupplierPurchaseByDate(AccountNo, dtPrescriberStart.Value, dtPrescriberEnd.Value,Operations.IdProject);
                    }
                    else
                    {
                        listPurchase = PurchaseManager.GetSupplierPurchase(AccountNo,Operations.IdProject);
                    }
                }
            }
            else if (BindingListCode == 2 && AccountNo != string.Empty)
            {
                if (ReportType == "Sale")
                {
                    if (chkProductDate.Checked)
                    {
                        listSale = SaleManager.GetProductDetailSaleByDate(Validation.GetSafeLong(AccountNo), dtProductStart.Value, dtProductEnd.Value,Operations.IdProject);
                    }
                    else
                    {
                        listSale = SaleManager.GetProductDetailSale(Validation.GetSafeLong(AccountNo),Operations.IdCompany);
                    }
                }
                else if (ReportType == "Purchase")
                {
                    if (chkProductDate.Checked)
                    {
                        listPurchase = PurchaseManager.GetProductDetailPurchaseByDate(AccountNo, dtProductStart.Value, dtProductEnd.Value,Operations.IdProject);
                    }
                    else
                    {
                        listPurchase = PurchaseManager.GetProductDetailPurchase(Validation.GetSafeLong(AccountNo),Operations.IdProject);
                    }
                }
            }
            else if (BindingListCode == 3)
            {
                if (ReportType == "Sale")
                {
                    listSale = SaleManager.GetProductsTotalSale(Operations.IdProject);
                }
                else if (ReportType == "Purchase")
                {
                    listPurchase = PurchaseManager.GetProductsTotalPurchase(Operations.IdProject);
                }
            }
            else if (BindingListCode == 4)
            {
                if (ReportType == "Sale")
                {
                    listSale = SaleManager.GetProductsTotalSaleByDate(dtStartDateWiseStock.Value,dtEndDateWiseStock.Value,Operations.IdProject);
                }
                else if (ReportType == "Purchase")
                {
                    listPurchase = PurchaseManager.GetProductsTotalPurchaseByDate(dtStartDateWiseStock.Value,dtEndDateWiseStock.Value,Operations.IdProject);
                }
            }
            if (listSale != null && listSale.Count > 0)
            {
                BindSaleGridByCode(listSale, BindingListCode);
                pnlReportsGrid.Visible = true;
            
            }
            else if (listPurchase !=null && listPurchase.Count > 0)
            {
                BindPurchaseGridByCode(listPurchase, BindingListCode);
                pnlReportsGrid.Visible = true;
            }
            
        }
        private void BindSaleGridByCode(List<SaleDetailEL> list,short BindingCode)
        {
            if (grdReports.Rows.Count > 0)
            {
                grdReports.Rows.Clear();
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (BindingCode == 1)
                {
                    grdReports.Rows.Add();
                    grdReports.Rows[i].Cells[2].Value = list[i].ItemNo;
                    grdReports.Rows[i].Cells[3].Value = list[i].ItemName;
                    grdReports.Rows[i].Cells[5].Value = list[i].Qty;
                    grdReports.Rows[i].Cells[6].Value = list[i].UnitPrice;
                    grdReports.Rows[i].Cells[7].Value = list[i].Amount;
                    grdReports.Rows[i].Cells[8].Value = list[i].Discount;
                    grdReports.Rows[i].Cells[9].Value = list[i].NetSaleAmount;
                }
                else if (BindingCode == 2)
                {
                    grdReports.Rows.Add();
                    grdReports.Rows[i].Cells[0].Value = list[i].VoucherNo;
                    grdReports.Rows[i].Cells[1].Value = list[i].VDate;
                    grdReports.Rows[i].Cells[3].Value = list[i].ItemName;
                    grdReports.Rows[i].Cells[4].Value = list[i].AccountName;
                    grdReports.Rows[i].Cells[5].Value = list[i].Qty;
                    grdReports.Rows[i].Cells[6].Value = list[i].UnitPrice;
                    grdReports.Rows[i].Cells[7].Value = list[i].Amount;
                    grdReports.Rows[i].Cells[8].Value = list[i].Discount;
                    grdReports.Rows[i].Cells[9].Value = list[i].NetSaleAmount;
                }
                else if (BindingCode == 3)
                {
                    grdReports.Rows.Add();
                    grdReports.Rows[i].Cells[2].Value = list[i].ItemNo;
                    grdReports.Rows[i].Cells[3].Value = list[i].ItemName;
                    grdReports.Rows[i].Cells[5].Value = list[i].Qty;
                    grdReports.Rows[i].Cells[6].Value = list[i].UnitPrice;
                    grdReports.Rows[i].Cells[7].Value = list[i].Amount;
                    grdReports.Rows[i].Cells[8].Value = list[i].Discount;
                    grdReports.Rows[i].Cells[9].Value = list[i].NetSaleAmount;
                }
                else if (BindingCode == 4)
                {
                    grdReports.Rows.Add();
                    grdReports.Rows[i].Cells[2].Value = list[i].ItemNo;
                    grdReports.Rows[i].Cells[3].Value = list[i].ItemName;
                    grdReports.Rows[i].Cells[5].Value = list[i].Qty;
                    grdReports.Rows[i].Cells[6].Value = list[i].UnitPrice;
                    grdReports.Rows[i].Cells[7].Value = list[i].Amount;
                    grdReports.Rows[i].Cells[8].Value = list[i].Discount;
                    grdReports.Rows[i].Cells[9].Value = list[i].NetSaleAmount;
                }
            }
        }
        private void BindPurchaseGridByCode(List<PurchaseDetailEL> list, short BindingCode)
        {
            if (grdReports.Rows.Count > 0)
            {
                grdReports.Rows.Clear();
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (BindingCode == 1)
                {
                    //grdReports.Rows.Add();
                    //grdReports.Rows[i].Cells[1].Value = list[i].ItemNo;
                    //grdReports.Rows[i].Cells[2].Value = list[i].ItemName;
                    //grdReports.Rows[i].Cells[4].Value = list[i].Qty;
                    //grdReports.Rows[i].Cells[6].Value = list[i].Amount;
                    //grdReports.Rows[i].Cells[7].Value = list[i].Discount;
                    //grdReports.Rows[i].Cells[8].Value = list[i].DiscountAmount;

                    grdReports.Rows.Add();
                    grdReports.Rows[i].Cells[2].Value = list[i].ItemNo;
                    grdReports.Rows[i].Cells[3].Value = list[i].ItemName;
                    grdReports.Rows[i].Cells[5].Value = list[i].Qty;
                    grdReports.Rows[i].Cells[6].Value = list[i].UnitPrice;
                    grdReports.Rows[i].Cells[7].Value = list[i].Amount;
                    grdReports.Rows[i].Cells[8].Value = list[i].Discount;
                    grdReports.Rows[i].Cells[9].Value = list[i].NetAmount;
                }
                else if (BindingCode == 2)
                {
                    //grdReports.Rows.Add();
                    //grdReports.Rows[i].Cells[0].Value = list[i].VoucherNo;
                    //grdReports.Rows[i].Cells[2].Value = list[i].ItemName;
                    //grdReports.Rows[i].Cells[3].Value = list[i].AccountName;
                    //grdReports.Rows[i].Cells[4].Value = list[i].Qty;
                    //grdReports.Rows[i].Cells[5].Value = list[i].UnitPrice;
                    //grdReports.Rows[i].Cells[6].Value = list[i].Amount;
                    //grdReports.Rows[i].Cells[7].Value = list[i].Discount;
                    //grdReports.Rows[i].Cells[8].Value = list[i].DiscountAmount;

                    grdReports.Rows.Add();
                    grdReports.Rows[i].Cells[0].Value = list[i].VoucherNo;
                    grdReports.Rows[i].Cells[1].Value = list[i].VDate;
                    grdReports.Rows[i].Cells[3].Value = list[i].ItemName;
                    grdReports.Rows[i].Cells[4].Value = list[i].AccountName;
                    grdReports.Rows[i].Cells[5].Value = list[i].Qty;
                    grdReports.Rows[i].Cells[6].Value = list[i].UnitPrice;
                    grdReports.Rows[i].Cells[7].Value = list[i].Amount;
                    grdReports.Rows[i].Cells[8].Value = list[i].Discount;
                    grdReports.Rows[i].Cells[9].Value = list[i].NetAmount;
                }
                else if (BindingCode == 3)
                {
                    //grdReports.Rows.Add();
                    //grdReports.Rows[i].Cells[1].Value = list[i].ItemNo;
                    //grdReports.Rows[i].Cells[2].Value = list[i].ItemName;
                    //grdReports.Rows[i].Cells[4].Value = list[i].Qty;
                    //grdReports.Rows[i].Cells[6].Value = list[i].Amount;
                    //grdReports.Rows[i].Cells[7].Value = list[i].Discount;
                    //grdReports.Rows[i].Cells[8].Value = list[i].DiscountAmount;

                    grdReports.Rows.Add();
                    grdReports.Rows[i].Cells[2].Value = list[i].ItemNo;
                    grdReports.Rows[i].Cells[3].Value = list[i].ItemName;
                    grdReports.Rows[i].Cells[5].Value = list[i].Qty;
                    grdReports.Rows[i].Cells[6].Value = list[i].UnitPrice;
                    grdReports.Rows[i].Cells[7].Value = list[i].Amount;
                    grdReports.Rows[i].Cells[8].Value = list[i].Discount;
                    grdReports.Rows[i].Cells[9].Value = list[i].NetAmount;
                }
                else if (BindingCode == 4)
                {
                    //grdReports.Rows.Add();
                    //grdReports.Rows[i].Cells[1].Value = list[i].ItemNo;
                    //grdReports.Rows[i].Cells[2].Value = list[i].ItemName;
                    //grdReports.Rows[i].Cells[4].Value = list[i].Qty;
                    //grdReports.Rows[i].Cells[5].Value = list[i].UnitPrice;
                    //grdReports.Rows[i].Cells[6].Value = list[i].Amount;
                    //grdReports.Rows[i].Cells[7].Value = list[i].Discount;
                    //grdReports.Rows[i].Cells[8].Value = list[i].DiscountAmount;

                    grdReports.Rows.Add();
                    grdReports.Rows[i].Cells[2].Value = list[i].ItemNo;
                    grdReports.Rows[i].Cells[3].Value = list[i].ItemName;
                    grdReports.Rows[i].Cells[5].Value = list[i].Qty;
                    grdReports.Rows[i].Cells[6].Value = list[i].UnitPrice;
                    grdReports.Rows[i].Cells[7].Value = list[i].Amount;
                    grdReports.Rows[i].Cells[8].Value = list[i].Discount;
                    grdReports.Rows[i].Cells[9].Value = list[i].NetAmount;
                }
            }
        }
        #endregion
    }
}
