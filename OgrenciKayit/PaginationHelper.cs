using System;
using System.Data;

namespace OgrenciKayit
{
    public static class PaginationHelper
    {
        public static DataTable GetStudentsPaged(string search, int page, int pageSize, out int total)
        {
            var all = DatabaseHelper.GetStudents(search) as DataTable;
            total = all?.Rows.Count ?? 0;
            return PaginateTable(all, page, pageSize);
        }

        public static DataTable GetDepartmentsPaged(string search, int page, int pageSize, out int total)
        {
            var all = DatabaseHelper.GetDepartments(search) as DataTable;
            total = all?.Rows.Count ?? 0;
            return PaginateTable(all, page, pageSize);
        }

        public static DataTable GetSchoolsPaged(string search, int page, int pageSize, out int total)
        {
            var all = DatabaseHelper.GetSchools(search) as DataTable;
            total = all?.Rows.Count ?? 0;
            return PaginateTable(all, page, pageSize);
        }

        public static DataTable GetCitiesPaged(string search, int page, int pageSize, out int total)
        {
            var all = DatabaseHelper.GetCities(search) as DataTable;
            total = all?.Rows.Count ?? 0;
            return PaginateTable(all, page, pageSize);
        }

        private static DataTable PaginateTable(DataTable table, int page, int pageSize)
        {
            if (table == null) return null;
            var paged = table.Clone();
            int start = (page - 1) * pageSize;
            int end = Math.Min(start + pageSize, table.Rows.Count);
            for (int i = start; i < end; i++)
                paged.ImportRow(table.Rows[i]);
            return paged;
        }
    }
}
