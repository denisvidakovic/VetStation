using System;
using System.Data;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;
using Excel = Microsoft.Office.Interop.Excel;

namespace Data
{
    public class ExcelHelper
    {
        public ExcelHelper()
        {
        }
        public void CreateExcelMilkCard(string path, DataTable tbl)
        {
            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
            Excel.Worksheet worksheet = (Excel.Worksheet)excel.Worksheets.get_Item(1);
            Excel.Range chartRange;

            worksheet.Cells.NumberFormat = "@";
            worksheet.get_Range("A1", "B1").ColumnWidth = 15;
            worksheet.get_Range("C1", "D1").ColumnWidth = 20;
            worksheet.Cells[1, 5].ColumnWidth = 15;
            worksheet.get_Range("F1", "G1").ColumnWidth = 20;
            worksheet.Cells[1, 8].ColumnWidth = 35;
            worksheet.Cells[1, 9].ColumnWidth = 20;

            worksheet.get_Range("A1", "I1").RowHeight = 35;
            worksheet.get_Range("A1", "I1").Font.Bold = true;
            worksheet.get_Range("A1", "I1").VerticalAlignment = 2;
            worksheet.get_Range("A1", "I1").HorizontalAlignment = 3;

            excel.Cells[1, 1] = "Datum";
            excel.Cells[1, 2] = "Broj uzorka";
            excel.Cells[1, 3] = "Prezime i Ime\nVlasnika";
            excel.Cells[1, 4] = "JMBG";
            excel.Cells[1, 5] = "Adresa Sabirno\nMjesto";
            excel.Cells[1, 6] = "Broj ušne\nmarkice";
            excel.Cells[1, 7] = "Tuberkuloza";
            excel.Cells[1, 8] = "CMT";
            excel.Cells[1, 9] = "Broj Obrazca";

            int iCol = 0;
            int iRow = 0;
            string tmpString = null;


            foreach (DataRow row in tbl.Rows)
            {
                iRow++;
                iCol = 0;
                foreach (DataColumn column in tbl.Columns)
                {
                    iCol++;
                    if (iCol == 1)
                        tmpString = row[column.ColumnName].ToString();
                    else if (iCol == 2)
                    {
                        tmpString += " " + row[column.ColumnName].ToString();
                        excel.Cells[iRow + 1, 3] = tmpString;
                    }
                    else if (iCol == 3)
                    {
                        tmpString = row[column.ColumnName].ToString();
                        excel.Cells[iRow + 1, 4] = tmpString;
                    }
                    else if (iCol == 4)
                    {
                        tmpString = row[column.ColumnName].ToString();
                        excel.Cells[iRow + 1, 5] = tmpString;
                    }
                    else if (iCol == 5)
                    {
                        tmpString = row[column.ColumnName].ToString();
                        excel.Cells[iRow + 1, 6] = tmpString;
                    }
                    else if (iCol == 6)
                    {
                        DateTime tmpDate = Convert.ToDateTime(row[column.ColumnName]);
                        excel.Cells[iRow + 1, 1] = tmpDate.Date.ToShortDateString();
                    }
                    else if (iCol == 7)
                    {
                        tmpString = row[column.ColumnName].ToString();
                        excel.Cells[iRow + 1, 8] = tmpString;
                    }
                    else if (iCol == 8)
                    {
                        tmpString = row[column.ColumnName].ToString().ToLower();

                        if (tmpString == "true")
                            excel.Cells[iRow + 1, iCol - 1] = "Pozitivno";
                        if (tmpString == "false")
                            excel.Cells[iRow + 1, iCol - 1] = "Negativno";
                    }
                    else
                    {
                        excel.Cells[iRow + 1, iCol - 1] = row[column.ColumnName];
                    }
                }
            }

            int tableHeight = tbl.Rows.Count + 1;

            chartRange = worksheet.get_Range("a1", "i1");
            chartRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);

            chartRange = worksheet.get_Range("a1", "i" + tableHeight);
            chartRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);

            object missing = System.Reflection.Missing.Value;
            workbook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, missing, missing, false, false, Excel.XlSaveAsAccessMode.xlExclusive, missing, missing, missing, missing, missing);
            workbook.Close(true, missing, missing);
            excel.Quit();
        }

        public void CreateExcelTuberkulinizacija(string  path, DataTable tbl)
        {
            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
            Excel.Worksheet worksheet = (Excel.Worksheet)excel.Worksheets.get_Item(1);
            Excel.Range chartRange;

            worksheet.Cells.NumberFormat = "@";
            worksheet.Cells[1, 1].ColumnWidth = 35;
            worksheet.get_Range("B1", "E1").ColumnWidth = 20;

            worksheet.get_Range("A1", "I1").RowHeight = 90;
            worksheet.get_Range("A1", "I1").Font.Bold = true;
            worksheet.get_Range("A1", "I1").VerticalAlignment = 2;
            worksheet.get_Range("A1", "I1").HorizontalAlignment = 3;

            worksheet.get_Range("F1", "H1").ColumnWidth = 13;

            excel.Cells[1, 1] = "IME I PREZIME\n\tVLASNIKA";
            excel.Cells[1, 2] = "JMBG";
            excel.Cells[1, 3] = "ŠIFRA\n\tIMANJA";
            excel.Cells[1, 4] = "BROJ UŠNE\n\tMARKICE";
            excel.Cells[1, 5] = "ADRESA";
            excel.Cells[1, 6] = "DATUM\n\tAPLIKACIJE\n\tTUBERKULINA";
            worksheet.Cells[1, 6].Orientation = 90;

            excel.Cells[1, 7] = "DATUM\n\tKONTROLE";
            worksheet.Cells[1, 7].Orientation = 90;

            excel.Cells[1, 8] = "REZULTATI";
            worksheet.Cells[1, 8].Orientation = 90;

            int iCol = 0;
            int iRow = 0;
            string tmpString = null;
            

            foreach (DataRow row in tbl.Rows)
            {
                iRow++;
                iCol = 0;
                foreach (DataColumn column in tbl.Columns)
                {
                    iCol++;
                    if (iCol == 1)
                        tmpString = row[column.ColumnName].ToString();
                    else if (iCol == 2)
                    {
                        tmpString += " " + row[column.ColumnName].ToString();
                        excel.Cells[iRow + 1, 1] = tmpString;
                    }
                    else if (iCol == 7 || iCol == 8)
                    {
                        DateTime tmpDate = Convert.ToDateTime(row[column.ColumnName]);
                        excel.Cells[iRow + 1, iCol - 1] = tmpDate.Date.ToShortDateString();
                    }
                    else if (iCol == 9)
                    {
                        tmpString = row[column.ColumnName].ToString().ToLower();

                        if (tmpString == "true")
                            excel.Cells[iRow + 1, iCol - 1] = "Pozitivno";
                        if (tmpString == "false")
                            excel.Cells[iRow + 1, iCol - 1] = "Negativno";
                    }
                    else
                    {
                        excel.Cells[iRow + 1, iCol - 1] = row[column.ColumnName];
                    }
                }
            }

            int tableHeight = tbl.Rows.Count + 1;

            chartRange = worksheet.get_Range("a1", "h1");
            chartRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);

            chartRange = worksheet.get_Range("a1", "h" + tableHeight);
            chartRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);

            object missing = System.Reflection.Missing.Value;
            workbook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, missing, missing, false, false, Excel.XlSaveAsAccessMode.xlExclusive, missing, missing, missing, missing, missing);
            workbook.Close(true, missing, missing);
            excel.Quit();
        }

        public void CreateExcelBruceloza(string path, DataTable tbl)
        {
            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
            Excel.Worksheet worksheet = (Excel.Worksheet)excel.Worksheets.get_Item(1);
            Excel.Range chartRange;

            worksheet.Cells.NumberFormat = "@";
            worksheet.Cells[1, 1].ColumnWidth = 35;
            worksheet.get_Range("B1", "E1").ColumnWidth = 20;

            worksheet.get_Range("A1", "I1").RowHeight = 90;
            worksheet.get_Range("A1", "I1").Font.Bold = true;
            worksheet.get_Range("A1", "I1").VerticalAlignment = 2;
            worksheet.get_Range("A1", "I1").HorizontalAlignment = 3;

            worksheet.get_Range("F1", "H1").ColumnWidth = 13;

            excel.Cells[1, 1] = "IME I PREZIME\n\tVLASNIKA";
            excel.Cells[1, 2] = "ADRESA";
            excel.Cells[1, 3] = "OPĆINA";
            excel.Cells[1, 4] = "IDENTIFIKACIJSKI\nBROJ ŽIVOTINJE";
            excel.Cells[1, 5] = "PROVEDENA MJERA";
            excel.Cells[1, 6] = "NAZIV VETERINARSKE\nORGANIZACIJE KOJA\nJE UZORKOVALA";
            excel.Cells[1, 7] = "REZULTATI";

            int iCol = 0;
            int iRow = 0;
            string tmpString = null;


            foreach (DataRow row in tbl.Rows)
            {
                iRow++;
                iCol = 0;
                foreach (DataColumn column in tbl.Columns)
                {
                    iCol++;

                    if (iCol == 1)
                        tmpString = row[column.ColumnName].ToString();
                    if (iCol == 2)
                    {
                        tmpString += " " + row[column.ColumnName].ToString();
                        excel.Cells[iRow + 1, 1] = tmpString;
                    }
                    if (iCol == 3)
                    {
                        excel.Cells[iRow + 1, iCol - 1] = row[column.ColumnName];

                        tmpString = "CAZIN";
                        excel.Cells[iRow + 1, 3] = tmpString;
                        tmpString = "";
                    }
                    if (iCol == 4)
                    {
                        excel.Cells[iRow + 1, iCol] = row[column.ColumnName];
                    }
                    if (iCol == 5)
                    {
                        tmpString = "VZ BIHAĆ";
                        excel.Cells[iRow + 1, 6] = tmpString;
                        tmpString = "";
                    }
                    if (iCol == 6)
                    {
                        string str = row[column.ColumnName].ToString();
                        if (str.ToLower() == "true")
                            tmpString = "krv";
                    }
                    if (iCol == 7)
                    {
                        string str = row[column.ColumnName].ToString();
                        if (str.ToLower() == "true")
                            tmpString += ", mljeko";
                    }
                    if (iCol == 8)
                    {
                        string str = row[column.ColumnName].ToString();
                        if (str.ToLower() == "true")
                            tmpString = ", ostalo";

                        excel.Cells[iRow + 1, 5] = tmpString;
                    }
                    if (iCol == 9)
                    {
                        tmpString = row[column.ColumnName].ToString().ToLower();
                        
                        if (tmpString == "true")
                            excel.Cells[iRow + 1, 7] = "Pozitivno";
                        if (tmpString == "false")
                            excel.Cells[iRow + 1, 7] = "Negativno";
                        
                    }
                }
            }

            int tebaleHeight = tbl.Rows.Count + 1;

            chartRange = worksheet.get_Range("a1", "g1");
            chartRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);

            chartRange = worksheet.get_Range("a1", "g" + tebaleHeight);
            chartRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);

            object missing = System.Reflection.Missing.Value;
            workbook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, missing, missing, false, false, Excel.XlSaveAsAccessMode.xlExclusive, missing, missing, missing, missing, missing);
            workbook.Close(true, missing, missing);
            excel.Quit();
        }

        public void CreateExcelVakcinacija(string path, DataTable tbl)
        {
            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
            Excel.Worksheet worksheet = (Excel.Worksheet)excel.Worksheets.get_Item(1);
            Excel.Range chartRange;

            worksheet.Cells.NumberFormat = "@";
            worksheet.Cells[1, 1].ColumnWidth = 5;
            worksheet.get_Range("B1", "C1").ColumnWidth = 30;
            worksheet.get_Range("D1", "F1").ColumnWidth = 20;

            worksheet.get_Range("A1", "F1").Font.Bold = true;
            worksheet.get_Range("A1", "F1").VerticalAlignment = 2;
            worksheet.get_Range("A1", "F1").HorizontalAlignment = 3;

            excel.Cells[1, 1] = "REDNI\nBROJ";
            excel.Cells[1, 2] = "PREZIME I IME";
            excel.Cells[1, 3] = "JMBG";
            excel.Cells[1, 4] = "ADRESA VLASNIKA";
            excel.Cells[1, 5] = "BROJ UŠNE MARKICE";
            excel.Cells[1, 6] = "DATUM VAKCINACIJE";

            int iCol = 0;
            int iRow = 0;
            string tmpString = null;


            foreach (DataRow row in tbl.Rows)
            {
                iRow++;
                iCol = 0;
                foreach (DataColumn column in tbl.Columns)
                {
                    iCol++;
                    if (iCol == 1)
                    {
                        string str = iRow.ToString();
                        tmpString = str;
                        excel.Cells[iRow + 1, 1] = tmpString;
                        tmpString = "";

                        tmpString = row[column.ColumnName].ToString();
                    }
                    if (iCol == 2)
                    {
                        tmpString += " " + row[column.ColumnName].ToString();
                        excel.Cells[iRow + 1, 2] = tmpString;
                    }

                    if (iCol == 3)
                    {
                        excel.Cells[iRow + 1, iCol] = row[column.ColumnName];
                    }
                    if (iCol == 4)
                    {
                        excel.Cells[iRow + 1, iCol] = row[column.ColumnName];
                    }
                    if (iCol == 5)
                    {
                        excel.Cells[iRow + 1, iCol] = row[column.ColumnName];
                    }
                    if (iCol == 6)
                    {
                        DateTime tmpDate = Convert.ToDateTime(row[column.ColumnName]);
                        excel.Cells[iRow + 1, iCol] = tmpDate.Date.ToShortDateString();
                    }
                }
            }

            int tebaleHeight = tbl.Rows.Count + 1;

            chartRange = worksheet.get_Range("a1", "f1");
            chartRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);

            chartRange = worksheet.get_Range("a1", "f" + tebaleHeight);
            chartRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);

            object missing = System.Reflection.Missing.Value;
            workbook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, missing, missing, false, false, Excel.XlSaveAsAccessMode.xlExclusive, missing, missing, missing, missing, missing);
            workbook.Close(true, missing, missing);
            excel.Quit();
        }
    }    
}
