namespace Fitness.Data.Access
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Text;

    using ClosedXML.Excel;
    using Excel;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using iTextSharp.text.pdf.parser;

    /// <summary>
    /// Helper class for working with Excel, PDF and Text files.
    /// </summary>
    public static class FileAccess
    {
        /// <summary>
        /// Read some Text file.
        /// </summary>
        /// <param name="filePath">The path to the Text file.</param>
        /// <returns>Returns a list of strings which represents all rows from the file.</returns>
        public static List<string> ReadText(string filePath)
        {
            var result = new List<string>();
            using (var reader = new StreamReader(filePath, Encoding.GetEncoding("windows-1251")))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    result.Add(line);
                    line = reader.ReadLine();
                }
            }

            return result;
        }

        /// <summary>
        /// Read some Excel file.
        /// </summary>
        /// <param name="filePath">The path to the Excel file.</param>
        /// <param name="sheetName">The Excel sheet name. By default is "Sheet1".</param>
        /// <returns>Returns the Excel input data as data table.</returns>
        public static DataTable ReadExcel(string filePath, string sheetName = "Sheet1")
        {
            var fullPath = Path.GetFullPath(filePath);
            var stream = File.Open(fullPath, FileMode.Open);
            var dataTable = new DataTable();
            using (var excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream))
            {
                excelReader.IsFirstRowAsColumnNames = true;
                dataTable = excelReader.AsDataSet().Tables[sheetName];
            }

            return dataTable;
        }

        /// <summary>
        /// Read some PDF file.
        /// </summary>
        /// <param name="filePath">The path to the PDF file.</param>
        /// <returns>Returns a list of strings.</returns>
        public static List<string> ReadPdf(string filePath)
        {
            var result = new List<string>();
            using (var reader = new PdfReader(filePath))
            {
                for (int page = 1; page <= reader.NumberOfPages; page++)
                {
                    result.Add(PdfTextExtractor.GetTextFromPage(reader, page));
                }
            }

            return result;
        }

        /// <summary>
        /// Writes some string in an Text file.
        /// </summary>
        /// <param name="text">The string.</param>
        /// <param name="filePath">The path where the Text file will be saved.</param>
        /// <param name="append">To append data to the file use 'true' (default) or 'false' to overwrite it.</param>
        public static void WriteText(string text, string filePath, bool append = true)
        {
            using (var writer = new StreamWriter(filePath, append, Encoding.GetEncoding("windows-1251")))
            {
                writer.WriteLine(text);
            }
        }

        /// <summary>
        /// Writes some list of strings in an Text file.
        /// </summary>
        /// <param name="list">The list of strings.</param>
        /// <param name="filePath">The path where the Text file will be saved.</param>
        /// <param name="append">To append data to the file use 'true' (default) or 'false' to overwrite it.</param>
        public static void WriteText(List<string> list, string filePath, bool append = true)
        {
            using (var writer = new StreamWriter(filePath, append, Encoding.GetEncoding("windows-1251")))
            {
                list.ForEach(line => writer.WriteLine(line));
            }
        }

        /// <summary>
        /// Export some data table to an Excel file.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <param name="filePath">The path where will be saved the Excel file.</param>
        /// <param name="sheetName">The Excel sheet name. By default is "Sheet1."</param>
        public static void WriteExcel(DataTable dataTable, string filePath, string sheetName = "Sheet1")
        {
            var workbook = new XLWorkbook();
            workbook.Worksheets.Add(dataTable, sheetName);
            workbook.SaveAs(filePath);
        }

        /// <summary>
        /// Writes some list of strings in an PDF file.
        /// </summary>
        /// <param name="text">The list of strings.</param>
        /// <param name="filePath">The path where will be saved the PDF file.</param>
        public static void WritePdf(List<string> list, string filePath)
        {
            var document = new Document();
            using (var streamer = new FileStream(filePath, FileMode.Create, System.IO.FileAccess.Write, FileShare.None))
            {
                using (var writer = PdfWriter.GetInstance(document, streamer))
                {
                    document.Open();
                    list.ForEach(line => document.Add(new Paragraph(line)));
                    document.Close();
                }
            }
        }

        /// <summary>
        /// Writes some data table in an PDF file.
        /// </summary>
        /// <param name="title">The title of the document.</param>
        /// <param name="dataTable">The data table.</param>
        /// <param name="filePath">The path where will be saved the PDF file.</param>
        public static void WritePdf(string title, DataTable dataTable, string filePath)
        {
            var document = new Document(PageSize.LETTER, 10, 10, 40, 40);
            using (var writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create)))
            {
                document.Open();
                var paragraph = new Paragraph(title);
                paragraph.Alignment = Element.ALIGN_CENTER;

                var table = new PdfPTable(dataTable.Columns.Count);
                table.SpacingBefore = 15;
                for (int rows = -1; rows < dataTable.Rows.Count; rows++)
                {
                    for (int column = 0; column < dataTable.Columns.Count; column++)
                    {
                        var content = rows < 0 ? dataTable.Columns[column].ColumnName : dataTable.Rows[rows][column].ToString();
                        table.AddCell(new PdfPCell(new Phrase(new Chunk(content, FontFactory.GetFont("Arial", 7)))));
                    }
                }

                document.Add(paragraph);
                document.Add(table);
                document.Close();
            }
        }
    }
}