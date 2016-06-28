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
    public class PrintPDF
    {
        public bool CreatePDF(DataTable AppDT,DataTable DetailDT,string filePath,string title)
        {
            try
            {
                CreateXLS(AppDT, DetailDT,title);
                string sourcePath = System.IO.Directory.GetCurrentDirectory() + @"\tempPDF\tempExcel.xls";
                string targetPath = filePath;
                XLSConvertToPDF(sourcePath, targetPath);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool CreateEnPDF(DataTable AppDT, DataTable DetailDT,string filePath)
        {
            try
            {
                CreateEnXLS(AppDT, DetailDT);
                string sourcePath = System.IO.Directory.GetCurrentDirectory() + @"\tempPDF\tempExcel.xls";
                string targetPath = filePath;
                XLSConvertToPDF(sourcePath, targetPath);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool CreateXLS(DataTable AppDT, DataTable DetailDT,string title)
        {
            string XLSName;
            XLSName = System.IO.Directory.GetCurrentDirectory() + @"\templet\2016国内员购申请表-模板.xls";
            Excel.Application app = new Excel.Application();
            app.DisplayAlerts = false;
            Excel.Workbooks wbks = app.Workbooks;
            Excel._Workbook _wbk = wbks.Add(XLSName);
            Excel.Sheets shs = _wbk.Sheets;
            Excel._Worksheet _wsh = (Excel._Worksheet)shs.get_Item(1);


            //写入
            _wsh.Cells[2, 2] = title;
            _wsh.Cells[4, 3] = AppDT.Rows[0]["ApplicantsName"].ToString();
            _wsh.Cells[4, 10] = AppDT.Rows[0]["ApplicantsNo"].ToString();
            _wsh.Cells[5, 3] = AppDT.Rows[0]["Location"].ToString();
            _wsh.Cells[5, 10] = AppDT.Rows[0]["PurchaseLocation"].ToString();
            _wsh.Cells[22, 11] = AppDT.Rows[0]["TotalPrice"].ToString();

            int j = 0;
            int i = 0;
            foreach(DataRow dr in DetailDT.Rows)
            {
                if(i<6)
                {
                    _wsh.Cells[9 + 2 * i, 2] = dr["CodeID"].ToString();
                    _wsh.Cells[9 + 2 * i, 3] = dr["ItemID"].ToString();
                    _wsh.Cells[9 + 2 * i, 4] = dr["Detail"].ToString();
                    _wsh.Cells[9 + 2 * i, 6] = dr["Count"].ToString();
                    _wsh.Cells[9 + 2 * i, 7] = dr["Price"].ToString();
                    if (dr["SelforGift"].ToString()=="2") _wsh.Cells[9 + 2 * i, 8] ="送礼";
                    else _wsh.Cells[9 + 2 * i, 8] = "自用";

                    _wsh.Cells[9 + 2 * i, 9] = dr["ApprovalCount"].ToString();
                    _wsh.Cells[9 + 2 * i, 10] = dr["ApprovalDiscount"].ToString();
                    _wsh.Cells[9 + 2 * i, 11] = dr["FinalPrice"].ToString();
                    i++;
                }
                if (j < 3)
                {
                    if (dr["SelforGift"].ToString() == "2")
                    {
                        _wsh.Cells[24 + j, 2] = dr["CodeID"].ToString();
                        _wsh.Cells[24 + j, 3] = dr["Recipient"].ToString();
                        _wsh.Cells[24 + j, 4] = dr["Relationship"].ToString();
                        _wsh.Cells[24 + j, 5] = dr["Reason"].ToString();
                        j++;
                    }
                }
            }


            //保存
            string filePath = System.IO.Directory.GetCurrentDirectory() + @"\tempPDF\tempExcel.xls";
            app.AlertBeforeOverwriting = false;
            _wbk.SaveAs(filePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            //退出和释放
            _wbk.Close(null, null, null);
            wbks.Close();
            app.Quit();
            //释放掉多余的excel进程
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            app = null;
            return true;
        }

        /// <summary>
        /// 英文版
        /// </summary>
        /// <param name="AppDT"></param>
        /// <param name="DetailDT"></param>
        /// <returns></returns>
        private bool CreateEnXLS(DataTable AppDT, DataTable DetailDT)
        {
            string XLSName;
            XLSName = System.IO.Directory.GetCurrentDirectory() + @"\templet\2015 Staff Purchase Form-in HK -templet .xls";
            Excel.Application app = new Excel.Application();
            app.DisplayAlerts = false;
            Excel.Workbooks wbks = app.Workbooks;
            Excel._Workbook _wbk = wbks.Add(XLSName);
            Excel.Sheets shs = _wbk.Sheets;
            Excel._Worksheet _wsh = (Excel._Worksheet)shs.get_Item(1);


            //写入
            _wsh.Cells[4, 3] = AppDT.Rows[0]["ApplicantsName"].ToString();
            _wsh.Cells[4, 11] = AppDT.Rows[0]["ApplicantsNo"].ToString();
            _wsh.Cells[5, 3] = AppDT.Rows[0]["Location"].ToString();
            _wsh.Cells[5, 11] = AppDT.Rows[0]["PurchaseLocation"].ToString();
            _wsh.Cells[22, 12] = AppDT.Rows[0]["TotalPrice"].ToString();

            int j = 0;
            int i = 0;
            foreach (DataRow dr in DetailDT.Rows)
            {
                if (i < 6)
                {
                    _wsh.Cells[8 + 2 * i, 2] = dr["CodeID"].ToString();
                    _wsh.Cells[8 + 2 * i, 4] = dr["ItemID"].ToString();
                    _wsh.Cells[8 + 2 * i, 5] = dr["Detail"].ToString();
                    _wsh.Cells[8 + 2 * i, 7] = dr["Count"].ToString();
                    _wsh.Cells[8 + 2 * i, 8] = dr["Price"].ToString();
                    if (dr["SelforGift"].ToString() == "2") _wsh.Cells[8 + 2 * i, 9] = "Gift";
                    else _wsh.Cells[8 + 2 * i, 9] = "Self";

                    _wsh.Cells[8 + 2 * i, 10] = dr["ApprovalCount"].ToString();
                    _wsh.Cells[8 + 2 * i, 11] = dr["ApprovalDiscount"].ToString();
                    _wsh.Cells[8 + 2 * i, 12] = dr["FinalPrice"].ToString();
                    i++;
                }
                if (j < 3)
                {
                    if (dr["SelforGift"].ToString() == "2")
                    {
                        _wsh.Cells[24 + j, 2] = dr["CodeID"].ToString();
                        _wsh.Cells[24 + j, 3] = dr["Recipient"].ToString();
                        _wsh.Cells[24 + j, 5] = dr["Relationship"].ToString();
                        _wsh.Cells[24 + j, 6] = dr["Reason"].ToString();
                        j++;
                    }
                }
            }



            //保存
            string filePath = System.IO.Directory.GetCurrentDirectory() + @"\tempPDF\tempExcel.xls";
            app.AlertBeforeOverwriting = false;
            _wbk.SaveAs(filePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            //退出和释放
            _wbk.Close(null, null, null);
            wbks.Close();
            app.Quit();
            //释放掉多余的excel进程
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            app = null;

            return true;
        }


        /// <summary>
        /// 把Excel文件转换成PDF格式文件
        /// </summary>
        /// <param name="sourcePath">源文件路径</param>
        /// <param name="targetPath">目标文件路径</param>
        /// <returns>true=转换成功</returns>
        private bool XLSConvertToPDF(string sourcePath, string targetPath)
        {
            bool result = false;
            Excel.XlFixedFormatType targetType = Excel.XlFixedFormatType.xlTypePDF;
            object missing = Type.Missing;
            Excel.ApplicationClass application = null;
            Excel.Workbook workBook = null;
            try
            {
                application = new Excel.ApplicationClass();
                object target = targetPath;
                object type = targetType;
                workBook = application.Workbooks.Open(sourcePath, missing, missing, missing, missing, missing,
                        missing, missing, missing, missing, missing, missing, missing, missing, missing);

                workBook.ExportAsFixedFormat(targetType, target, Excel.XlFixedFormatQuality.xlQualityStandard, true, false, missing, missing, missing, missing);
                result = true;
            }
            catch
            {
                result = false;
            }
            finally
            {
                if (workBook != null)
                {
                    workBook.Close(true, missing, missing);
                    workBook = null;
                }
                if (application != null)
                {
                    application.Quit();
                    application = null;
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            if(workBook!=null)workBook.Close();
            if (application != null) application.Quit();
            return result;
        }
    }
}
