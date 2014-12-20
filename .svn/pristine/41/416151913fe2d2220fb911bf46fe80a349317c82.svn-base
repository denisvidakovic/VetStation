using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace Data
{
    public class PDFHelper
    {
        public PDFHelper()
        {
        }

        public void CreatePdfMilkCard(string fileName, DataTable tbl)
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            FontFactory.RegisterDirectory(path + "\\res\\");

            Font HeaderArial = FontFactory.GetFont("Arial", BaseFont.CP1250.ToString(), 10, Font.BOLD);
            Font NormalArial = FontFactory.GetFont("Arial", BaseFont.CP1250.ToString(), 8, Font.NORMAL);
            DateTime CurrTime = DateTime.Now;
            Document document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());

            PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));
            Image jpg = Image.GetInstance(path + "\\res\\LOGO.jpg");


            //global::Data.Properties.Resources.arial.ttf

            try
            {
                document.Open();

                Paragraph paragraph = new Paragraph("JP 'VETERINARSKA STANICA' DOO CAZIN", HeaderArial);
                paragraph.Font = HeaderArial;

                //Setting Paragraph options
                paragraph.Alignment = Element.ALIGN_JUSTIFIED;

                //Setting Image options
                jpg.ScaleToFit(70f, 70f);
                jpg.Alignment = Image.TEXTWRAP | Image.ALIGN_RIGHT;
                jpg.IndentationLeft = 9f;
                jpg.SpacingAfter = 9f;
                document.Add(jpg);
                document.Add(paragraph);

                paragraph.Clear();
                paragraph.Add("OPĆINA CAZIN".ToUpper());
                paragraph.Alignment = Element.ALIGN_JUSTIFIED;
                document.Add(paragraph);

                paragraph.Clear();
                paragraph.Add("\n\t");
                paragraph.Add("\n\t");
                paragraph.Add("\n\t");
                paragraph.Add("\n\t");

                DateTime tmpYear = Convert.ToDateTime(tbl.Rows[1].ItemArray[5]);

                paragraph.Add("SPISAK VLASNIKA STOKE KOJI SU IZVRŠILI:");
                paragraph.Alignment = Element.ALIGN_CENTER;
                document.Add(paragraph);
                paragraph.Clear();

                paragraph.Add("- DIJAGNOSTIČKO ISPITIVANJE:");
                paragraph.Alignment = Element.ALIGN_LEFT;
                document.Add(paragraph);
                paragraph.Clear();

                paragraph.Add("- PREVENTIVNO VAKCINISANJE:");
                paragraph.Alignment = Element.ALIGN_LEFT;

                paragraph.Add("\n\t");
                document.Add(paragraph);

                //Number of columns in table
                PdfPTable table = new PdfPTable(9);
                //actual width of table in points
                table.TotalWidth = 770f;
                //fix the absolute width of the table
                table.LockedWidth = true;

                //relative col widths in proportions - 1/3 and 2/3
                //                             01     02    03    04    05    06    07    08    09
                float[] widths = new float[] { 0.3f, 0.3f, 0.5f, 0.5f, 0.3f, 0.5f, 0.7f, 0.7f, 0.4f };
                table.SetWidths(widths);
                table.HorizontalAlignment = 0;
                //leave a gap before and after the table
                table.SpacingBefore = 20f;
                table.SpacingAfter = 30f;

                PdfPCell Cell_Date = new PdfPCell(new Phrase("Datum", HeaderArial));

                PdfPCell Cell_SampleNumber = new PdfPCell(new Phrase("Broj uzorka", HeaderArial));

                PdfPCell Cell_OwnerName = new PdfPCell(new Phrase("Prezime i Ime\nVlasnika", HeaderArial));

                PdfPCell Cell_Jmbg = new PdfPCell(new Phrase("JMBG", HeaderArial));

                PdfPCell Cell_Address = new PdfPCell(new Phrase("Adresa\nSabirno\nMjesto", HeaderArial));

                PdfPCell Cell_AnimalNumaber = new PdfPCell(new Phrase("Broj ušne markice", HeaderArial));

                PdfPCell Cell_Tuberkuloza = new PdfPCell(new Phrase("Tuberkuloza", HeaderArial));

                PdfPCell Cell_CMT = new PdfPCell(new Phrase("CMT", HeaderArial));

                PdfPCell Cell_FormNumber = new PdfPCell(new Phrase("Broj Obrazca", HeaderArial));


                Cell_Date.HorizontalAlignment = 1;              //0=Left, 1=Centre, 2=Right
                Cell_SampleNumber.HorizontalAlignment = 1;      //0=Left, 1=Centre, 2=Right
                Cell_OwnerName.HorizontalAlignment = 1;         //0=Left, 1=Centre, 2=Right
                Cell_Jmbg.HorizontalAlignment = 1;              //0=Left, 1=Centre, 2=Right
                Cell_Address.HorizontalAlignment = 1;           //0=Left, 1=Centre, 2=Right
                Cell_AnimalNumaber.HorizontalAlignment = 1;     //0=Left, 1=Centre, 2=Right
                Cell_Tuberkuloza.HorizontalAlignment = 1;       //0=Left, 1=Centre, 2=Right
                Cell_CMT.HorizontalAlignment = 1;               //0=Left, 1=Centre, 2=Right
                Cell_FormNumber.HorizontalAlignment = 1;        //0=Left, 1=Centre, 2=Right

                Cell_Date.VerticalAlignment = Element.ALIGN_MIDDLE;
                Cell_SampleNumber.VerticalAlignment = Element.ALIGN_MIDDLE;
                Cell_OwnerName.VerticalAlignment = Element.ALIGN_MIDDLE;
                Cell_Jmbg.VerticalAlignment = Element.ALIGN_MIDDLE;
                Cell_Address.VerticalAlignment = Element.ALIGN_MIDDLE;
                Cell_AnimalNumaber.VerticalAlignment = Element.ALIGN_MIDDLE;
                Cell_Tuberkuloza.VerticalAlignment = Element.ALIGN_MIDDLE;
                Cell_CMT.VerticalAlignment = Element.ALIGN_MIDDLE;
                Cell_FormNumber.VerticalAlignment = Element.ALIGN_MIDDLE;

                table.AddCell(Cell_Date);
                table.AddCell(Cell_SampleNumber);
                table.AddCell(Cell_OwnerName);
                table.AddCell(Cell_Jmbg);
                table.AddCell(Cell_Address);
                table.AddCell(Cell_AnimalNumaber);
                table.AddCell(Cell_Tuberkuloza);
                table.AddCell(Cell_CMT);
                table.AddCell(Cell_FormNumber);

                for (int i = 1; i <= tbl.Rows.Count; i++)
                {
                    DateTime tmpDate = Convert.ToDateTime(tbl.Rows[i - 1].ItemArray[5]);
                    Cell_Date = new PdfPCell(new Phrase(tmpDate.Date.ToShortDateString(), NormalArial));
                    Cell_Date.HorizontalAlignment = 1;      //0=Left, 1=Centre, 2=Right
                    table.AddCell(Cell_Date);

                    Cell_SampleNumber = new PdfPCell(new Phrase("", NormalArial));
                    Cell_SampleNumber.HorizontalAlignment = 1;         //0=Left, 1=Centre, 2=Right
                    table.AddCell(Cell_SampleNumber);

                    Cell_OwnerName = new PdfPCell(new Phrase(tbl.Rows[i - 1].ItemArray[0].ToString() + " " + tbl.Rows[i - 1].ItemArray[1].ToString(), NormalArial));
                    Cell_OwnerName.HorizontalAlignment = 1;         //0=Left, 1=Centre, 2=Right
                    table.AddCell(Cell_OwnerName);

                    Cell_Jmbg = new PdfPCell(new Phrase(tbl.Rows[i - 1].ItemArray[2].ToString(), NormalArial));
                    Cell_Jmbg.HorizontalAlignment = 1;       //0=Left, 1=Centre, 2=Right
                    table.AddCell(Cell_Jmbg);

                    Cell_Address = new PdfPCell(new Phrase(tbl.Rows[i - 1].ItemArray[3].ToString(), NormalArial));
                    Cell_Address.HorizontalAlignment = 1;              //0=Left, 1=Centre, 2=Right
                    table.AddCell(Cell_Address);

                    Cell_AnimalNumaber = new PdfPCell(new Phrase(tbl.Rows[i - 1].ItemArray[4].ToString(), NormalArial));
                    Cell_AnimalNumaber.HorizontalAlignment = 1;     //0=Left, 1=Centre, 2=Right
                    table.AddCell(Cell_AnimalNumaber);

                    Cell_Tuberkuloza = new PdfPCell(new Phrase("", NormalArial));
                    Cell_Tuberkuloza.HorizontalAlignment = 1;     //0=Left, 1=Centre, 2=Right
                    table.AddCell(Cell_Tuberkuloza);

                    Cell_CMT = new PdfPCell(new Phrase(tbl.Rows[i - 1].ItemArray[6].ToString(), NormalArial));
                    Cell_CMT.HorizontalAlignment = 1;     //0=Left, 1=Centre, 2=Right
                    table.AddCell(Cell_CMT);

                    Cell_FormNumber = new PdfPCell(new Phrase(tbl.Rows[i - 1].ItemArray[4].ToString(), NormalArial));
                    Cell_FormNumber.HorizontalAlignment = 1;     //0=Left, 1=Centre, 2=Right
                    table.AddCell(Cell_FormNumber);

                    table.CompleteRow();
                }

                document.Add(table);

                paragraph.Clear();
                paragraph.Add("\n\t");

                document.Add(paragraph);

                //Close pdf file
                document.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void CreatePdfVakcinacija(string fileName, DataTable tbl)
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            FontFactory.RegisterDirectory(path + "\\res\\");

            Font HeaderArial = FontFactory.GetFont("Arial", BaseFont.CP1250.ToString(), 10, Font.BOLD);
            Font NormalArial = FontFactory.GetFont("Arial", BaseFont.CP1250.ToString(), 8, Font.NORMAL);
            DateTime CurrTime = DateTime.Now;
            Document document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());

            PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));
            Image jpg = Image.GetInstance(path + "\\res\\LOGO.jpg");


            //global::Data.Properties.Resources.arial.ttf

            try
            {
                document.Open();

                Paragraph paragraph = new Paragraph("JP 'VETERINARSKA STANICA' DOO CAZIN", HeaderArial);
                paragraph.Font = HeaderArial;

                //Setting Paragraph options
                paragraph.Alignment = Element.ALIGN_JUSTIFIED;

                //Setting Image options
                jpg.ScaleToFit(70f, 70f);
                jpg.Alignment = Image.TEXTWRAP | Image.ALIGN_RIGHT;
                jpg.IndentationLeft = 9f;
                jpg.SpacingAfter = 9f;
                document.Add(jpg);
                document.Add(paragraph);

                paragraph.Clear();
                paragraph.Add("OPĆINA CAZIN".ToUpper());
                paragraph.Alignment = Element.ALIGN_JUSTIFIED;
                document.Add(paragraph);

                paragraph.Clear();
                paragraph.Add("\n\t");
                paragraph.Add("\n\t");
                paragraph.Add("\n\t");
                paragraph.Add("\n\t");

                DateTime tmpYear = Convert.ToDateTime(tbl.Rows[1].ItemArray[5]);

                paragraph.Add("EVIDENCIJA CIJEPLJENIH GOVEDA, OVACA KOZA I KOPITARA PROTIV ANTRAKSA - BEDERNICE");
                paragraph.Alignment = Element.ALIGN_CENTER;
                document.Add(paragraph);
                paragraph.Clear();

                paragraph.Add("NASELJENO MJESTO: " + tbl.Rows[1].ItemArray[6].ToString().ToUpper() + ", DATUM VAKCINISANJA: ".ToUpper() + tmpYear.ToShortDateString());
                paragraph.Alignment = Element.ALIGN_CENTER;
                paragraph.Add("\n\t");
                document.Add(paragraph);

                //Number of columns in table
                PdfPTable table = new PdfPTable(6);
                //actual width of table in points
                table.TotalWidth = 770f;
                //fix the absolute width of the table
                table.LockedWidth = true;

                //relative col widths in proportions - 1/3 and 2/3
                float[] widths = new float[] { 0.3f, 1.5f, 0.9f, 0.6f, 0.9f, 0.6f };
                table.SetWidths(widths);
                table.HorizontalAlignment = 0;
                //leave a gap before and after the table
                table.SpacingBefore = 20f;
                table.SpacingAfter = 30f;

                PdfPCell Cell_Number = new PdfPCell(new Phrase("Redni\nbroj", HeaderArial));
                PdfPCell Cell_OwnerName = new PdfPCell(new Phrase("Prezime i Ime", HeaderArial));
                PdfPCell Cell_Jmbg = new PdfPCell(new Phrase("JMBG", HeaderArial));
                PdfPCell Cell_Address = new PdfPCell(new Phrase("Adresa Vlasnika", HeaderArial));
                PdfPCell Cell_AnimalNumaber = new PdfPCell(new Phrase("Broj ušne markice", HeaderArial));
                PdfPCell Cell_VaccinationDate = new PdfPCell(new Phrase("Datum vakcinacije", HeaderArial));

                Cell_Number.HorizontalAlignment = 1;            //0=Left, 1=Centre, 2=Right
                Cell_OwnerName.HorizontalAlignment = 1;         //0=Left, 1=Centre, 2=Right
                Cell_Jmbg.HorizontalAlignment = 1;              //0=Left, 1=Centre, 2=Right
                Cell_Address.HorizontalAlignment = 1;           //0=Left, 1=Centre, 2=Right
                Cell_AnimalNumaber.HorizontalAlignment = 1;     //0=Left, 1=Centre, 2=Right
                Cell_VaccinationDate.HorizontalAlignment = 1;   //0=Left, 1=Centre, 2=Right

                Cell_Number.VerticalAlignment = Element.ALIGN_MIDDLE;
                Cell_OwnerName.VerticalAlignment = Element.ALIGN_MIDDLE;
                Cell_Jmbg.VerticalAlignment = Element.ALIGN_MIDDLE;
                Cell_Address.VerticalAlignment = Element.ALIGN_MIDDLE;
                Cell_AnimalNumaber.VerticalAlignment = Element.ALIGN_MIDDLE;
                Cell_VaccinationDate.VerticalAlignment = Element.ALIGN_MIDDLE;

                table.AddCell(Cell_Number);
                table.AddCell(Cell_OwnerName);
                table.AddCell(Cell_Jmbg);
                table.AddCell(Cell_Address);
                table.AddCell(Cell_AnimalNumaber);
                table.AddCell(Cell_VaccinationDate);

                for (int i = 1; i <= tbl.Rows.Count; i++)
                {
                    Cell_Number = new PdfPCell(new Phrase(i.ToString(), NormalArial));
                    Cell_Number.HorizontalAlignment = 1;         //0=Left, 1=Centre, 2=Right
                    table.AddCell(Cell_Number);

                    Cell_OwnerName = new PdfPCell(new Phrase(tbl.Rows[i - 1].ItemArray[0].ToString() + " " + tbl.Rows[i - 1].ItemArray[1].ToString(), NormalArial));
                    Cell_OwnerName.HorizontalAlignment = 1;         //0=Left, 1=Centre, 2=Right
                    table.AddCell(Cell_OwnerName);

                    Cell_Jmbg = new PdfPCell(new Phrase(tbl.Rows[i - 1].ItemArray[2].ToString(), NormalArial));
                    Cell_Jmbg.HorizontalAlignment = 1;       //0=Left, 1=Centre, 2=Right
                    table.AddCell(Cell_Jmbg);

                    Cell_Address = new PdfPCell(new Phrase(tbl.Rows[i - 1].ItemArray[3].ToString(), NormalArial));
                    Cell_Address.HorizontalAlignment = 1;              //0=Left, 1=Centre, 2=Right
                    table.AddCell(Cell_Address);

                    Cell_AnimalNumaber = new PdfPCell(new Phrase(tbl.Rows[i - 1].ItemArray[4].ToString(), NormalArial));
                    Cell_AnimalNumaber.HorizontalAlignment = 1;     //0=Left, 1=Centre, 2=Right
                    table.AddCell(Cell_AnimalNumaber);

                    DateTime tmpDate = Convert.ToDateTime(tbl.Rows[i - 1].ItemArray[5]);
                    Cell_VaccinationDate = new PdfPCell(new Phrase(tmpDate.Date.ToShortDateString(), NormalArial));
                    Cell_VaccinationDate.HorizontalAlignment = 1;      //0=Left, 1=Centre, 2=Right
                    table.AddCell(Cell_VaccinationDate);

                    table.CompleteRow();
                }

                document.Add(table);

                paragraph.Clear();
                paragraph.Add("\n\t");

                document.Add(paragraph);

                //Close pdf file
                document.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void CreatePdfBruceloza(string fileName, DataTable tbl)
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            FontFactory.RegisterDirectory(path + "\\res\\");

            Font HeaderArial = FontFactory.GetFont("Arial", BaseFont.CP1250.ToString(), 10, Font.BOLD);
            Font NormalArial = FontFactory.GetFont("Arial", BaseFont.CP1250.ToString(), 8, Font.NORMAL);
            DateTime CurrTime = DateTime.Now;
            Document document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());

            PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));
            Image jpg = Image.GetInstance(path + "\\res\\LOGO.jpg");


            //global::Data.Properties.Resources.arial.ttf

            try
            {
                document.Open();

                Paragraph paragraph = new Paragraph("JP 'VETERINARSKA STANICA' DOO CAZIN", HeaderArial);
                paragraph.Font = HeaderArial;

                //Setting Paragraph options
                paragraph.Alignment = Element.ALIGN_JUSTIFIED;

                //Setting Image options
                jpg.ScaleToFit(70f, 70f);
                jpg.Alignment = Image.TEXTWRAP | Image.ALIGN_RIGHT;
                jpg.IndentationLeft = 9f;
                jpg.SpacingAfter = 9f;
                document.Add(jpg);
                document.Add(paragraph);

                paragraph.Clear();
                paragraph.Add("OPĆINA CAZIN".ToUpper());
                paragraph.Alignment = Element.ALIGN_JUSTIFIED;
                document.Add(paragraph);

                paragraph.Clear();
                paragraph.Add("\n\t");
                paragraph.Add("\n\t");

                DateTime tmpYear = Convert.ToDateTime(tbl.Rows[0].ItemArray[4]);

                paragraph.Add("EVIDENCIJA DIJAGNOSTIČKIH ISPITANI GOVEDA NA BRUCELOZU, TBC I CMT U ".ToUpper() + tmpYear.Year);
                paragraph.Alignment = Element.ALIGN_CENTER;
                paragraph.Add("\n\t");
                document.Add(paragraph);

                PdfPTable table = new PdfPTable(7);
                //actual width of table in points
                table.TotalWidth = 770f;
                //fix the absolute width of the table
                table.LockedWidth = true;

                //relative col widths in proportions - 1/3 and 2/3
                float[] widths = new float[] { 1.5f, 0.8f, 0.8f, 0.9f, 0.8f, 0.6f, 0.6f };
                table.SetWidths(widths);
                table.HorizontalAlignment = 0;
                //leave a gap before and after the table
                table.SpacingBefore = 20f;
                table.SpacingAfter = 30f;

                PdfPCell Cell_OwnerName = new PdfPCell(new Phrase("Ime i Prezime vlasnika", HeaderArial));
                PdfPCell Cell_Address = new PdfPCell(new Phrase("Adresa", HeaderArial));
                PdfPCell Cell_Municipality = new PdfPCell(new Phrase("Općina", HeaderArial));
                PdfPCell Cell_AnimalNumaber = new PdfPCell(new Phrase("Identifikacijski broj životinje", HeaderArial));
                PdfPCell Cell_ExaminationFor = new PdfPCell(new Phrase("Provedena Mjera", HeaderArial));
                PdfPCell Cell_OrgName = new PdfPCell(new Phrase("Naziv organizacije\nkoja je\nuzorkovala", HeaderArial));
                PdfPCell Cell_ExaminationResult = new PdfPCell(new Phrase("Rezulatati", HeaderArial));

                Cell_OwnerName.HorizontalAlignment = 1;         //0=Left, 1=Centre, 2=Right
                Cell_Address.HorizontalAlignment = 1;           //0=Left, 1=Centre, 2=Right
                Cell_Municipality.HorizontalAlignment = 1;      //0=Left, 1=Centre, 2=Right
                Cell_AnimalNumaber.HorizontalAlignment = 1;     //0=Left, 1=Centre, 2=Right
                Cell_ExaminationFor.HorizontalAlignment = 1;    //0=Left, 1=Centre, 2=Right
                Cell_OrgName.HorizontalAlignment = 1;           //0=Left, 1=Centre, 2=Right
                Cell_ExaminationResult.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right

                Cell_OwnerName.VerticalAlignment = Element.ALIGN_MIDDLE;
                Cell_Address.VerticalAlignment = Element.ALIGN_MIDDLE;
                Cell_Municipality.VerticalAlignment = Element.ALIGN_MIDDLE;
                Cell_AnimalNumaber.VerticalAlignment = Element.ALIGN_MIDDLE;
                Cell_ExaminationFor.VerticalAlignment = Element.ALIGN_MIDDLE;
                Cell_OrgName.VerticalAlignment = Element.ALIGN_MIDDLE;
                Cell_ExaminationResult.VerticalAlignment = Element.ALIGN_MIDDLE;

                table.AddCell(Cell_OwnerName);
                table.AddCell(Cell_Address);
                table.AddCell(Cell_Municipality);
                table.AddCell(Cell_AnimalNumaber);
                table.AddCell(Cell_ExaminationFor);
                table.AddCell(Cell_OrgName);
                table.AddCell(Cell_ExaminationResult);

                foreach (DataRow row in tbl.Rows)
                {
                    Cell_OwnerName = new PdfPCell(new Phrase(row.ItemArray[0].ToString() + " " + row.ItemArray[1].ToString(), NormalArial));
                    Cell_OwnerName.HorizontalAlignment = 1;         //0=Left, 1=Centre, 2=Right
                    table.AddCell(Cell_OwnerName);

                    Cell_Address = new PdfPCell(new Phrase(row.ItemArray[2].ToString(), NormalArial));
                    Cell_Address.HorizontalAlignment = 1;              //0=Left, 1=Centre, 2=Right
                    table.AddCell(Cell_Address);

                    Cell_Municipality = new PdfPCell(new Phrase("Cazin", NormalArial));
                    Cell_Municipality.HorizontalAlignment = 1;       //0=Left, 1=Centre, 2=Right
                    table.AddCell(Cell_Municipality);

                    Cell_AnimalNumaber = new PdfPCell(new Phrase(row.ItemArray[3].ToString(), NormalArial));
                    Cell_AnimalNumaber.HorizontalAlignment = 1;     //0=Left, 1=Centre, 2=Right
                    table.AddCell(Cell_AnimalNumaber);

                    if (row.ItemArray[5].ToString().ToLower() == "true")
                        Cell_ExaminationFor = new PdfPCell(new Phrase("krv", NormalArial));
                    if (row.ItemArray[6].ToString().ToLower() == "true")
                        Cell_ExaminationFor.Phrase.Add(", mljeko");
                    if (row.ItemArray[7].ToString().ToLower() == "true")
                        Cell_ExaminationFor.Phrase.Add(", ostalo");

                    Cell_ExaminationFor.HorizontalAlignment = 1;           //0=Left, 1=Centre, 2=Right
                    table.AddCell(Cell_ExaminationFor);

                    Cell_OrgName = new PdfPCell(new Phrase("VZ Bihać", NormalArial));
                    Cell_OrgName.HorizontalAlignment = 1;       //0=Left, 1=Centre, 2=Right
                    table.AddCell(Cell_OrgName);

                    if (row.ItemArray[8].ToString().ToLower() == "true")
                        Cell_ExaminationResult.Phrase = new Phrase("Pozitivno", NormalArial);
                    else if (row.ItemArray[8].ToString().ToLower() == "false")
                        Cell_ExaminationResult.Phrase = new Phrase("Negativno", NormalArial);

                    Cell_ExaminationResult.Rotation = 0;
                    Cell_ExaminationResult.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right

                    table.AddCell(Cell_ExaminationResult);

                    table.CompleteRow();
                }

                document.Add(table);

                paragraph.Clear();
                paragraph.Add("\n\t");

                document.Add(paragraph);

                //Close pdf file
                document.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void CreatePdfTuberkulinizacija(string fileName, DataTable tbl)
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            FontFactory.RegisterDirectory(path + "\\res\\");

            Font HeaderArial = FontFactory.GetFont("Arial", BaseFont.CP1250.ToString(), 10, Font.BOLD);
            Font NormalArial = FontFactory.GetFont("Arial", BaseFont.CP1250.ToString(), 8, Font.NORMAL);
            DateTime CurrTime = DateTime.Now;
            Document document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());

            PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));
            Image jpg = Image.GetInstance(path + "\\res\\LOGO.jpg");


            //global::Data.Properties.Resources.arial.ttf

            try
            {
                document.Open();

                Paragraph paragraph = new Paragraph("JP 'VETERINARSKA STANICA' DOO CAZIN", HeaderArial);
                paragraph.Font = HeaderArial;

                //Setting Paragraph options
                paragraph.Alignment = Element.ALIGN_JUSTIFIED;

                //Setting Image options
                jpg.ScaleToFit(70f, 70f);
                jpg.Alignment = Image.TEXTWRAP | Image.ALIGN_RIGHT;
                jpg.IndentationLeft = 9f;
                jpg.SpacingAfter = 9f;
                document.Add(jpg);
                document.Add(paragraph);

                paragraph.Clear();
                paragraph.Add("OPĆINA CAZIN".ToUpper());
                paragraph.Alignment = Element.ALIGN_JUSTIFIED;
                document.Add(paragraph);

                paragraph.Clear();
                paragraph.Add("\n\t");
                paragraph.Add("\n\t");
                paragraph.Add("GOVEDA TUBERKULINIZACIJA".ToUpper());
                paragraph.Alignment = Element.ALIGN_CENTER;
                paragraph.Add("\n\t");
                document.Add(paragraph);

                PdfPTable table = new PdfPTable(8);
                //actual width of table in points
                table.TotalWidth = 770f;
                //fix the absolute width of the table
                table.LockedWidth = true;

                //relative col widths in proportions - 1/3 and 2/3
                float[] widths = new float[] { 1.5f, 0.8f, 0.8f, 0.9f, 0.8f, 0.6f, 0.6f, 0.6f };
                table.SetWidths(widths);
                table.HorizontalAlignment = 0;
                //leave a gap before and after the table
                table.SpacingBefore = 20f;
                table.SpacingAfter = 30f;

                PdfPCell Cell_OwnerName = new PdfPCell(new Phrase("Ime i Prezime vlasnika", HeaderArial));
                PdfPCell Cell_jmbg = new PdfPCell(new Phrase("JMBG", HeaderArial));
                PdfPCell Cell_SifraImanja = new PdfPCell(new Phrase("Šifra Imanja", HeaderArial));
                PdfPCell Cell_AnimalNumaber = new PdfPCell(new Phrase("Broj ušne markice", HeaderArial));
                PdfPCell Cell_Address = new PdfPCell(new Phrase("Adresa", HeaderArial));
                PdfPCell Cell_SamplingDate = new PdfPCell(new Phrase("Datum\n\taplikacije\n\ttuberkulina", HeaderArial));
                PdfPCell Cell_ExaminationDate = new PdfPCell(new Phrase("Datum kontrole", HeaderArial));
                PdfPCell Cell_ExaminationResult = new PdfPCell(new Phrase("Rezulatati", HeaderArial));

                Cell_OwnerName.HorizontalAlignment = 1;         //0=Left, 1=Centre, 2=Right
                Cell_jmbg.HorizontalAlignment = 1;              //0=Left, 1=Centre, 2=Right
                Cell_SifraImanja.HorizontalAlignment = 1;       //0=Left, 1=Centre, 2=Right
                Cell_AnimalNumaber.HorizontalAlignment = 1;     //0=Left, 1=Centre, 2=Right
                Cell_Address.HorizontalAlignment = 1;           //0=Left, 1=Centre, 2=Right
                Cell_SamplingDate.HorizontalAlignment = 1;      //0=Left, 1=Centre, 2=Right
                Cell_ExaminationDate.HorizontalAlignment = 1;   //0=Left, 1=Centre, 2=Right
                Cell_ExaminationResult.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right

                Cell_OwnerName.VerticalAlignment = Element.ALIGN_MIDDLE;         
                Cell_jmbg.VerticalAlignment = Element.ALIGN_MIDDLE;              
                Cell_SifraImanja.VerticalAlignment = Element.ALIGN_MIDDLE;       
                Cell_AnimalNumaber.VerticalAlignment = Element.ALIGN_MIDDLE;     
                Cell_Address.VerticalAlignment = Element.ALIGN_MIDDLE;           
                Cell_SamplingDate.VerticalAlignment = Element.ALIGN_MIDDLE;      
                Cell_ExaminationDate.VerticalAlignment = Element.ALIGN_MIDDLE;   
                Cell_ExaminationResult.VerticalAlignment = Element.ALIGN_MIDDLE; 

                Cell_SamplingDate.Rotation = 90;
                Cell_ExaminationDate.Rotation = 90;
                Cell_ExaminationResult.Rotation = 90;

                table.AddCell(Cell_OwnerName);
                table.AddCell(Cell_jmbg);
                table.AddCell(Cell_SifraImanja);
                table.AddCell(Cell_AnimalNumaber);
                table.AddCell(Cell_Address);
                table.AddCell(Cell_SamplingDate);
                table.AddCell(Cell_ExaminationDate);
                table.AddCell(Cell_ExaminationResult);

                foreach (DataRow row in tbl.Rows)
                {
                    Cell_OwnerName = new PdfPCell(new Phrase(row.ItemArray[0].ToString() + " " + row.ItemArray[1].ToString(), NormalArial));
                    Cell_OwnerName.HorizontalAlignment = 1;         //0=Left, 1=Centre, 2=Right
                    table.AddCell(Cell_OwnerName);

                    Cell_jmbg = new PdfPCell(new Phrase(row.ItemArray[2].ToString(), NormalArial));
                    Cell_jmbg.HorizontalAlignment = 1;              //0=Left, 1=Centre, 2=Right
                    table.AddCell(Cell_jmbg);

                    Cell_SifraImanja = new PdfPCell(new Phrase(row.ItemArray[3].ToString(), NormalArial));
                    Cell_SifraImanja.HorizontalAlignment = 1;       //0=Left, 1=Centre, 2=Right
                    table.AddCell(Cell_SifraImanja);

                    Cell_AnimalNumaber = new PdfPCell(new Phrase(row.ItemArray[4].ToString(), NormalArial));
                    Cell_AnimalNumaber.HorizontalAlignment = 1;     //0=Left, 1=Centre, 2=Right
                    table.AddCell(Cell_AnimalNumaber);

                    Cell_Address = new PdfPCell(new Phrase(row.ItemArray[5].ToString(), NormalArial));
                    Cell_Address.HorizontalAlignment = 1;           //0=Left, 1=Centre, 2=Right
                    table.AddCell(Cell_Address);

                    DateTime tmpDate = Convert.ToDateTime(row.ItemArray[6]);
                    Cell_SamplingDate = new PdfPCell(new Phrase(tmpDate.Date.ToShortDateString(), NormalArial));
                    Cell_SamplingDate.HorizontalAlignment = 1;      //0=Left, 1=Centre, 2=Right
                    table.AddCell(Cell_SamplingDate);

                    tmpDate = Convert.ToDateTime(row.ItemArray[7]);
                    Cell_ExaminationDate = new PdfPCell(new Phrase(tmpDate.Date.ToShortDateString(), NormalArial));
                    Cell_ExaminationDate.HorizontalAlignment = 1;   //0=Left, 1=Centre, 2=Right
                    table.AddCell(Cell_ExaminationDate);
                   
                    if (row.ItemArray[8].ToString().ToLower() == "true")
                        Cell_ExaminationResult.Phrase = new Phrase("Pozitivno", NormalArial);
                    else if (row.ItemArray[8].ToString().ToLower() == "false")
                        Cell_ExaminationResult.Phrase = new Phrase("Negativno", NormalArial);

                    Cell_ExaminationResult.Rotation = 0;
                    Cell_ExaminationResult.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right

                    table.AddCell(Cell_ExaminationResult);

                    table.CompleteRow();
                }

                document.Add(table);

                paragraph.Clear();
                paragraph.Add("\n\t");

                document.Add(paragraph);

                //Close pdf file
                document.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
