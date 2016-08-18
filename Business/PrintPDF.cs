using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;
using System.IO;
using System.Data;
using System.Windows.Forms;

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
            _wsh.Cells[23, 11] = AppDT.Rows[0]["TransNo"].ToString();
            _wsh.Cells[24, 11] = DateTime.Now.ToShortDateString();

            _wsh.Cells[31, 4] = AppDT.Rows[0]["ApplicantsName"].ToString();
            _wsh.Cells[31, 6] = DateTime.Parse(AppDT.Rows[0]["ApplicantsDate"].ToString()).ToShortDateString();
            _wsh.Cells[32, 4] = AppDT.Rows[0]["ApprovalName2"].ToString();
            _wsh.Cells[32, 6] = DateTime.Parse(AppDT.Rows[0]["ApprovalDate2"].ToString()).ToShortDateString();
            _wsh.Cells[33, 4] = AppDT.Rows[0]["ApprovalName"].ToString();
            _wsh.Cells[33, 6] = DateTime.Parse(AppDT.Rows[0]["ApprovalDate"].ToString()).ToShortDateString();
            _wsh.Cells[34, 4] = AppDT.Rows[0]["ApprovalName3"].ToString();
            _wsh.Cells[34, 6] = DateTime.Parse(AppDT.Rows[0]["ApprovalDate3"].ToString()).ToShortDateString();
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
        public bool XLSConvertToPDF(string sourcePath, string targetPath)
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

        public void WriteToExcel(DataTable thisTable, string FileName, string sheetName)
        {
            string strFilePath = FileName;
            string XLSName = System.IO.Directory.GetCurrentDirectory() + @"\templet\报告模板.xls";
            Excel.Application app = new Excel.Application();
            app.DisplayAlerts = false;
            Excel.Workbooks wbks = app.Workbooks;
            Excel._Workbook _wbk = wbks.Add(XLSName);
            Excel.Sheets shs = _wbk.Sheets;
            Excel._Worksheet _wsh = (Excel._Worksheet)shs.get_Item(1);
            try
            {
                int sheetRowsCount = _wsh.UsedRange.Rows.Count;
                int count = thisTable.Columns.Count;

                //设置列名
                //foreach (DataColumn myNewColumn in thisTable.Columns)
                //{
                //    _wsh.Cells[0, count] = myNewColumn.ColumnName;
                //    count = count + 1;
                //}er
                for (int i = 0; i < count; i++)
                {
                    _wsh.Cells[1, i + 1] = thisTable.Columns[i].ColumnName;
                }

                //加入內容
                for (int i = 1; i <= thisTable.Rows.Count; i++)
                {
                    for (int j = 1; j <= thisTable.Columns.Count; j++)
                    {
                        _wsh.Cells[i + sheetRowsCount, j] = thisTable.Rows[i - 1][j - 1];
                    }
                }
                _wsh.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                _wsh.Cells.Columns.AutoFit();
                _wsh.Cells.Rows.AutoFit();
                //若為EXCEL2000, 將最後一個參數拿掉即可             
                _wbk.SaveAs(strFilePath, Excel.XlFileFormat.xlWorkbookNormal,
                    null, null, false, false, Excel.XlSaveAsAccessMode.xlShared,
                    false, false, null, null, null);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                //關閉文件
                _wbk.Close(false, Type.Missing, Type.Missing);
                app.Workbooks.Close();
                app.Quit();

                //釋放資源
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(_wsh);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(_wbk);
                _wsh = null;
                _wbk = null;
                app = null;
            }
        }

        public DataTable exporeDataToTable(DataGridView dataGridView)
        {
            //将datagridview中的数据导入到表中
            DataTable tempTable = new DataTable("tempTable");
            //定义一个模板表，专门用来获取列名
            DataTable modelTable = new DataTable("ModelTable");
            //创建列
            for (int column = 0; column < dataGridView.Columns.Count; column++)
            {
                //可见的列才显示出来
                if (dataGridView.Columns[column].Visible == true)
                {
                    DataColumn tempColumn = new DataColumn(dataGridView.Columns[column].HeaderText, typeof(string));
                    tempTable.Columns.Add(tempColumn);
                    DataColumn modelColumn = new DataColumn(dataGridView.Columns[column].Name, typeof(string));
                    modelTable.Columns.Add(modelColumn);
                }
            }
            //添加datagridview中行的数据到表
            for (int row = 0; row < dataGridView.Rows.Count; row++)
            {
                if (dataGridView.Rows[row].Visible == false)
                {
                    continue;
                }
                DataRow tempRow = tempTable.NewRow();
                for (int i = 0; i < tempTable.Columns.Count; i++)
                {
                    tempRow[i] = dataGridView.Rows[row].Cells[modelTable.Columns[i].ColumnName].Value;
                }
                tempTable.Rows.Add(tempRow);
            }
            return tempTable;
        }

        //public bool XLSConvertToPDF(string sourcePath, string targetPath)
        //{
        //    bool result = false;
        //    Excel.XlFixedFormatType targetType = Excel.XlFixedFormatType.xlTypePDF;
        //    object missing = Type.Missing;
        //    Excel.ApplicationClass application = null;
        //    Excel.Workbook workBook = null;
        //    try
        //    {
        //        application = new Excel.ApplicationClass();
        //        object target = targetPath;
        //        object type = targetType;
        //        workBook = application.Workbooks.Open(sourcePath, missing, missing, missing, missing, missing,
        //                missing, missing, missing, missing, missing, missing, missing, missing, missing);

        //        workBook.ExportAsFixedFormat(targetType, target, Excel.XlFixedFormatQuality.xlQualityStandard, true, false, missing, missing, missing, missing);
        //        result = true;
        //    }
        //    catch
        //    {
        //        result = false;
        //    }
        //    finally
        //    {
        //        if (workBook != null)
        //        {
        //            workBook.Close(true, missing, missing);
        //            workBook = null;
        //        }
        //        if (application != null)
        //        {
        //            application.Quit();
        //            application = null;
        //        }
        //        GC.Collect();
        //        GC.WaitForPendingFinalizers();
        //        GC.Collect();
        //        GC.WaitForPendingFinalizers();
        //    }

        //    if (workBook != null) workBook.Close();
        //    if (application != null) application.Quit();
        //    return result;
        //}
    }
}
