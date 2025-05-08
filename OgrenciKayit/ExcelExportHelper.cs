using System;
using System.Data;
using System.IO;
using System.Text;
using ClosedXML.Excel; // ClosedXML ile Excel export

namespace OgrenciKayit
{
    public static class ExcelExportHelper
    {
        // Basit CSV export (herkesin kullanabileceði)
        public static void ExportToCsv(DataTable table, string filePath)
        {
            var sb = new StringBuilder();

            // Sütun baþlýklarý
            for (int i = 0; i < table.Columns.Count; i++)
            {
                sb.Append(table.Columns[i].ColumnName);
                if (i < table.Columns.Count - 1)
                    sb.Append(";");
            }
            sb.AppendLine();

            // Satýrlar
            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    sb.Append(row[i]?.ToString()?.Replace(";", " "));
                    if (i < table.Columns.Count - 1)
                        sb.Append(";");
                }
                sb.AppendLine();
            }

            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }

        // ClosedXML ile Excel export (Office baðýmsýz)
        public static void ExportToExcel(DataTable table, string filePath)
        {
            using (var workbook = new XLWorkbook())
            {
                var ws = workbook.Worksheets.Add("Veriler");
                ws.Cell(1, 1).InsertTable(table, "Tablo", true);
                ws.Columns().AdjustToContents();
                workbook.SaveAs(filePath);
            }
        }
    }
}
