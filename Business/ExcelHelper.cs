using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;
using System.IO;
using System.Data;

namespace BHair.Business
{
    public class ExcelHelper
    {
        public DataTable ExcelToDataTable_Items(string filePath, DataTable Result)
        {
            Excel.Application app = new Excel.Application();
            Excel.Sheets sheets;
            object oMissiong = System.Reflection.Missing.Value;
            Excel.Workbook workbook = null;

            try
            {
                if (app == null) return null;
                workbook = app.Workbooks.Open(filePath, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong,
                    oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong);
                sheets = workbook.Worksheets;

                //将数据读入到DataTable中
                Excel.Worksheet worksheet = (Excel.Worksheet)sheets.get_Item(1);//读取第一张表  
                if (worksheet == null) return null;

                int iRowCount = worksheet.UsedRange.Rows.Count;
                int iColCount = worksheet.UsedRange.Columns.Count;

                //生成行数据
                Excel.Range range;
                for (int iRow = 2; iRow <= iRowCount; iRow++)
                {
                    int validate = 0;
                    DataRow dr = Result.NewRow();

                    dr["ItemID"] = ((Excel.Range)worksheet.Cells[iRow, 1]).Text;

                    double price = 0;
                    if (!double.TryParse(((Excel.Range)worksheet.Cells[iRow, 2]).Text.ToString(), out price))
                        validate++;
                    dr["Price"] = price;
                    double price2 = 0;
                    if (!double.TryParse(((Excel.Range)worksheet.Cells[iRow, 3]).Text.ToString(), out price2))
                        validate++;
                    dr["Price2"] = price2;
                    double price3 = 0;
                    if (!double.TryParse(((Excel.Range)worksheet.Cells[iRow, 4]).Text.ToString(), out price3))
                        validate++;
                    dr["Price3"] = price3;
                    int isSpecial = 0;
                    if (!int.TryParse(((Excel.Range)worksheet.Cells[iRow, 5]).Text.ToString(), out isSpecial))
                        validate++;
                    dr["IsSpecial"] = isSpecial;
                    dr["Detail"] = ((Excel.Range)worksheet.Cells[iRow, 6]).Text;
                    dr["IsDelete"] = 0;

                    if (dr["ItemID"].ToString() == "") validate++;
                    if (dr["Price"].ToString() == "") validate++;
                    if (dr["Price2"].ToString() == "") validate++;
                    if (dr["Price3"].ToString() == "") validate++;
                    if (dr["IsSpecial"].ToString() != "0" && dr["IsSpecial"].ToString() != "1") validate++;

                    if (validate == 0) Result.Rows.Add(dr);
                }
                return Result;
            }
            catch { return null; }
            finally
            {
                workbook.Close(false, oMissiong, oMissiong);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                workbook = null;
                app.Workbooks.Close();
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                app = null;
            }
        }


        public DataTable ExcelToDataTable_Member(string filePath, DataTable Result, string sha1pwd)
        {
            //DataTable Result = new DataTable();


            Excel.Application app = new Excel.Application();
            Excel.Sheets sheets;
            object oMissiong = System.Reflection.Missing.Value;
            Excel.Workbook workbook = null;

            try
            {
                if (app == null) return null;
                workbook = app.Workbooks.Open(filePath, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong,
                    oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong);
                sheets = workbook.Worksheets;

                //将数据读入到DataTable中
                Excel.Worksheet worksheet = (Excel.Worksheet)sheets.get_Item(1);//读取第一张表  
                if (worksheet == null) return null;

                int iRowCount = worksheet.UsedRange.Rows.Count;
                int iColCount = worksheet.UsedRange.Columns.Count;

                //生成行数据
                Excel.Range range;
                for (int iRow = 2; iRow <= iRowCount; iRow++)
                {
                    int validate = 0;
                    DataRow dr = Result.NewRow();

                    dr["UID"] = ((Excel.Range)worksheet.Cells[iRow, 1]).Text;
                    dr["UserName"] = ((Excel.Range)worksheet.Cells[iRow, 2]).Text;
                    dr["EmployeeID"] = ((Excel.Range)worksheet.Cells[iRow, 3]).Text;
                    int character = 0;
                    if (!int.TryParse(((Excel.Range)worksheet.Cells[iRow, 4]).Text.ToString(), out character))
                        validate++;
                    dr["Character"] = character;
                    dr["ManagerID"] = ((Excel.Range)worksheet.Cells[iRow, 5]).Text;
                    int moneyUnit = 0;
                    if (!int.TryParse(((Excel.Range)worksheet.Cells[iRow, 6]).Text.ToString(), out moneyUnit))
                        validate++;
                    dr["MoneyUnit"] = moneyUnit;
                    dr["Store"] = ((Excel.Range)worksheet.Cells[iRow, 7]).Text;

                    dr["Position"] = ((Excel.Range)worksheet.Cells[iRow, 8]).Text;
                    dr["Department"] = ((Excel.Range)worksheet.Cells[iRow, 9]).Text;
                    dr["Email"] = ((Excel.Range)worksheet.Cells[iRow, 10]).Text;
                    dr["Detail"] = ((Excel.Range)worksheet.Cells[iRow, 11]).Text;
                    dr["RestAmount"] = ((Excel.Range)worksheet.Cells[iRow, 12]).Text;

                    dr["IsDelete"] = 0;
                    dr["IsAble"] = 0;
                    dr["IsAdmin"] = 0;
                    dr["TotalAmount"] = 0;
                    dr["UsedAmount"] = 0;
                    //dr["RestAmount"] = 0;
                    dr["UserPwd"] = sha1pwd;

                    if (dr["UID"].ToString() == "")
                    { validate++; }
                    if (dr["UserName"].ToString() == "")
                    { validate++; }
                    if (dr["EmployeeID"].ToString() == "")
                    { validate++; }
                    if (dr["Character"].ToString() != "1" && dr["Character"].ToString() != "2" && dr["Character"].ToString() != "3" && dr["Character"].ToString() != "4" && dr["Character"].ToString() != "5" && dr["Character"].ToString() != "6")
                    { validate++; }
                    if (int.Parse(dr["MoneyUnit"].ToString())<1 || int.Parse(dr["MoneyUnit"].ToString()) >10)
                    { validate++; }
                    if ((dr["Character"].ToString() == "3" && dr["ManagerID"].ToString() == "") || (dr["Character"].ToString() == "2" && dr["ManagerID"].ToString() == ""))
                    { validate++; }
                    if (dr["Character"].ToString() == "4" && dr["Store"].ToString() == "")
                    { validate++; }

                    if (validate == 0) Result.Rows.Add(dr);
                }
                return Result;
            }
            catch { return null; }
            finally
            {
                workbook.Close(false, oMissiong, oMissiong);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                workbook = null;
                app.Workbooks.Close();
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                app = null;
            }
        }

        public DataTable ExcelToDataTable_EmployeeID(string filePath)
        {
            DataTable Result = new DataTable();
            Result.Columns.Add(new DataColumn("EmployeeID", typeof(string)));

            Excel.Application app = new Excel.Application();
            Excel.Sheets sheets;
            object oMissiong = System.Reflection.Missing.Value;
            Excel.Workbook workbook = null;

            try
            {
                if (app == null) return null;
                workbook = app.Workbooks.Open(filePath, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong,
                    oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong);
                sheets = workbook.Worksheets;

                //将数据读入到DataTable中
                Excel.Worksheet worksheet = (Excel.Worksheet)sheets.get_Item(1);//读取第一张表  
                if (worksheet == null) return null;

                int iRowCount = worksheet.UsedRange.Rows.Count;
                int iColCount = worksheet.UsedRange.Columns.Count;

                //生成行数据
                Excel.Range range;
                for (int iRow = 2; iRow <= iRowCount; iRow++)
                {
                    int validate = 0;
                    DataRow dr = Result.NewRow();
                    dr["EmployeeID"] = ((Excel.Range)worksheet.Cells[iRow, 1]).Text;
                    if (dr["EmployeeID"].ToString() == "") validate++;
                    if (validate == 0) Result.Rows.Add(dr);
                }
                return Result;
            }
            catch { return null; }
            finally
            {
                workbook.Close(false, oMissiong, oMissiong);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                workbook = null;
                app.Workbooks.Close();
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                app = null;
            }
        }


        public bool StoreReportExcel(string filePath, DataTable ReportDT)
        {
            bool Result = false;

            Excel.Application app;
            Excel.Workbooks wbs;
            Excel.Workbook wb;
            app = new Excel.Application();
            wbs = app.Workbooks;
            wb = wbs.Add(true);


            Excel.Worksheet s = (Excel.Worksheet)wb.Worksheets.get_Item(1);

            s.Cells[1, 1] = "交易号";
            s.Cells[1, 2] = "申请时间";
            s.Cells[1, 3] = "申请人";
            s.Cells[1, 4] = "货号";
            s.Cells[1, 5] = "批准数量";
            s.Cells[1, 6] = "批准后价格";
            s.Cells[1, 7] = "货币单位";

            int i = 1;
            foreach (DataRow dr in ReportDT.Rows)
            {
                s.Cells[1 + i, 1] = dr["TransNo"].ToString();
                s.Cells[1 + i, 2] = dr["ApplicantsDate"].ToString();
                s.Cells[1 + i, 3] = dr["ApplicantsName"].ToString();
                s.Cells[1 + i, 4] = dr["ItemID"].ToString();
                s.Cells[1 + i, 5] = dr["ApprovalCount"].ToString();
                s.Cells[1 + i, 6] = dr["FinalPrice"].ToString();
                if (dr["MoneyUnit"].ToString() == "2") s.Cells[1 + i, 7] = "美元";
                else if (dr["MoneyUnit"].ToString() == "3") s.Cells[1 + i, 7] = "港币";
                else s.Cells[1 + i, 7] = "人民币";
                i++;
            }

            //保存
            //string filePath = System.IO.Directory.GetCurrentDirectory() + @"\tempPDF\tempExcel.xls";

            app.AlertBeforeOverwriting = false;
            wb.SaveAs(filePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            //退出和释放
            wb.Close(null, null, null);
            wbs.Close();
            app.Quit();
            //释放掉多余的excel进程
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            app = null;


            return true;
        }
        public DataTable SelectUsersByUID(string UID)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from Users where IsDelete = 0 and UID='{0}'", UID);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }
        public DataTable SelectAllUsers(string sql)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from [Users] where IsDelete = 0 {0}", sql);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        public Boolean boolIsManager(string UID)
        {
            Boolean boolResult = false;
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from Users where IsDelete = 0 and ManagerID='{0}'", UID);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            if (Result.Rows.Count > 0) { boolResult = true; }
            return boolResult;
        }
    }
}
