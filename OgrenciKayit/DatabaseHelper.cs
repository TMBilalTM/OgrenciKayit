using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;

namespace OgrenciKayit
{
    public class DatabaseHelper
    {
        // MySQL connection string
        private static string connectionString = "Server=localhost;Database=ogrencikayit;Uid=root;Pwd=;";
        
        // Get connection
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        // Hash a password using SHA256
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Convert the input string to a byte array and compute the hash
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        
        // Verify admin login
        public static bool VerifyLogin(string username, string password)
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();
                    string query = "SELECT password FROM admin WHERE username=@username";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username);

                    string storedHash = command.ExecuteScalar() as string;
                    
                    if (storedHash == null)
                    {
                        return false; // User not found
                    }
                    
                    // Hash the provided password and compare with stored hash
                    string hashedInputPassword = HashPassword(password);
                    return storedHash == hashedInputPassword;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database error: " + ex.Message);
                return false;
            }
        }
        
        // Initialize database if needed
        public static bool InitializeDatabase()
        {
            try
            {
                // Create database if it doesn't exist
                MySqlConnection connectionWithoutDb = new MySqlConnection("Server=localhost;Uid=root;Pwd=;");
                connectionWithoutDb.Open();
                
                string createDbQuery = "CREATE DATABASE IF NOT EXISTS ogrencikayit";
                MySqlCommand createDbCommand = new MySqlCommand(createDbQuery, connectionWithoutDb);
                createDbCommand.ExecuteNonQuery();
                connectionWithoutDb.Close();
                
                // Create tables using our normal connection
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();
                    
                    // Admin table
                    string createAdminTable = @"CREATE TABLE IF NOT EXISTS admin (
                        id INT AUTO_INCREMENT PRIMARY KEY,
                        username VARCHAR(50) NOT NULL UNIQUE,
                        password VARCHAR(255) NOT NULL,
                        created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                    )";
                    
                    // Departments table
                    string createDepartmentsTable = @"CREATE TABLE IF NOT EXISTS Departments (
                        Id INT AUTO_INCREMENT PRIMARY KEY,
                        Name VARCHAR(100) NOT NULL
                    )";

                    // Cities table
                    string createCitiesTable = @"CREATE TABLE IF NOT EXISTS Cities (
                        Id INT AUTO_INCREMENT PRIMARY KEY,
                        Name VARCHAR(100) NOT NULL
                    )";

                    // Schools table (now with CityId)
                    string createSchoolsTable = @"CREATE TABLE IF NOT EXISTS Schools (
                        Id INT AUTO_INCREMENT PRIMARY KEY,
                        Name VARCHAR(100) NOT NULL,
                        CityId INT,
                        FOREIGN KEY (CityId) REFERENCES Cities(Id)
                    )";

                    // Students table (updated with all required fields)
                    string createOgrencilerTable = @"CREATE TABLE IF NOT EXISTS ogrenciler (
                        id INT AUTO_INCREMENT PRIMARY KEY,
                        ogrenci_no VARCHAR(20) NOT NULL UNIQUE,
                        ad VARCHAR(50) NOT NULL,
                        soyad VARCHAR(50) NOT NULL,
                        dogum_tarihi DATE NOT NULL,
                        cinsiyet VARCHAR(10) NOT NULL,
                        email VARCHAR(100),
                        telefon VARCHAR(20),
                        adres VARCHAR(255),
                        bolum_id INT,
                        sinif VARCHAR(10),
                        yil VARCHAR(20),
                        kayit_tarihi DATE NOT NULL DEFAULT CURRENT_DATE,
                        kktc_kimlik_no VARCHAR(10),
                        veli_adi VARCHAR(100),
                        veli_telefon VARCHAR(20),
                        onceki_okul_id INT,
                        okul_id INT,
                        FOREIGN KEY (okul_id) REFERENCES Schools(Id),
                        FOREIGN KEY (bolum_id) REFERENCES Departments(Id),
                        FOREIGN KEY (onceki_okul_id) REFERENCES Schools(Id)
                    )";
                    
                    // Execute creation queries
                    new MySqlCommand(createAdminTable, connection).ExecuteNonQuery();
                    new MySqlCommand(createDepartmentsTable, connection).ExecuteNonQuery();
                    new MySqlCommand(createCitiesTable, connection).ExecuteNonQuery();
                    new MySqlCommand(createSchoolsTable, connection).ExecuteNonQuery();
                    new MySqlCommand(createOgrencilerTable, connection).ExecuteNonQuery();
                    
                    // Insert default admin if not exists
                    string checkAdminQuery = "SELECT COUNT(*) FROM admin";
                    MySqlCommand checkCommand = new MySqlCommand(checkAdminQuery, connection);
                    int adminCount = Convert.ToInt32(checkCommand.ExecuteScalar());
                    
                    if (adminCount == 0)
                    {
                        // Hash the default admin password
                        string defaultPassword = "admin123";
                        string hashedPassword = HashPassword(defaultPassword);
                        
                        string insertAdminQuery = "INSERT INTO admin (username, password) VALUES ('admin', @password)";
                        MySqlCommand insertCommand = new MySqlCommand(insertAdminQuery, connection);
                        insertCommand.Parameters.AddWithValue("@password", hashedPassword);
                        insertCommand.ExecuteNonQuery();
                    }
                    
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database initialization error: " + ex.Message);
                return false;
            }
        }

        // Departments
        public static DataTable GetDepartments(string search = "")
        {
            using (var con = GetConnection())
            using (var cmd = new MySqlCommand(
                "SELECT Id, Name FROM Departments WHERE Name LIKE @search", con))
            using (var da = new MySqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@search", "%" + search + "%");
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static void AddDepartment(string name)
        {
            using (var con = GetConnection())
            using (var cmd = new MySqlCommand("INSERT INTO Departments (Name) VALUES (@name)", con))
            {
                cmd.Parameters.AddWithValue("@name", name);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateDepartment(int id, string name)
        {
            using (var con = GetConnection())
            using (var cmd = new MySqlCommand("UPDATE Departments SET Name=@name WHERE Id=@id", con))
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteDepartment(int id)
        {
            using (var con = GetConnection())
            using (var cmd = new MySqlCommand("DELETE FROM Departments WHERE Id=@id", con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Cities
        public static DataTable GetCities(string search = "")
        {
            using (var con = GetConnection())
            using (var cmd = new MySqlCommand(
                "SELECT Id, Name FROM Cities WHERE Name LIKE @search", con))
            using (var da = new MySqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@search", "%" + search + "%");
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static void AddCity(string name)
        {
            using (var con = GetConnection())
            using (var cmd = new MySqlCommand("INSERT INTO Cities (Name) VALUES (@name)", con))
            {
                cmd.Parameters.AddWithValue("@name", name);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateCity(int id, string name)
        {
            using (var con = GetConnection())
            using (var cmd = new MySqlCommand("UPDATE Cities SET Name=@name WHERE Id=@id", con))
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteCity(int id)
        {
            using (var con = GetConnection())
            using (var cmd = new MySqlCommand("DELETE FROM Cities WHERE Id=@id", con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Schools
        public static DataTable GetSchools(string search = "")
        {
            using (var con = GetConnection())
            using (var cmd = new MySqlCommand(
                @"SELECT s.Id, s.Name, c.Name AS CityName, s.CityId
                  FROM Schools s
                  LEFT JOIN Cities c ON s.CityId = c.Id
                  WHERE s.Name LIKE @search OR c.Name LIKE @search", con))
            using (var da = new MySqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@search", "%" + search + "%");
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static void AddSchool(string name, int cityId)
        {
            using (var con = GetConnection())
            using (var cmd = new MySqlCommand("INSERT INTO Schools (Name, CityId) VALUES (@name, @cityId)", con))
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@cityId", cityId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateSchool(int id, string name, int cityId)
        {
            using (var con = GetConnection())
            using (var cmd = new MySqlCommand("UPDATE Schools SET Name=@name, CityId=@cityId WHERE Id=@id", con))
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@cityId", cityId);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Overloads for backward compatibility (if needed)
        public static void AddSchool(string name)
        {
            AddSchool(name, 0);
        }

        public static void UpdateSchool(int id, string name)
        {
            UpdateSchool(id, name, 0);
        }

        public static void DeleteSchool(int id)
        {
            using (var con = GetConnection())
            using (var cmd = new MySqlCommand("DELETE FROM Schools WHERE Id=@id", con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Students CRUD
        public static DataTable GetStudents(string search = "")
        {
            using (var con = GetConnection())
            using (var cmd = new MySqlCommand(
                @"SELECT o.id, o.ogrenci_no, o.ad, o.soyad, o.dogum_tarihi, o.cinsiyet, o.email, o.telefon, o.adres,
                         d.Name AS bolum, o.bolum_id, o.sinif, o.yil, o.kayit_tarihi, o.kktc_kimlik_no, o.veli_adi, o.veli_telefon,
                         s.Name AS okul, o.okul_id, s2.Name AS onceki_okul, o.onceki_okul_id
                  FROM ogrenciler o
                  LEFT JOIN Departments d ON o.bolum_id = d.Id
                  LEFT JOIN Schools s ON o.okul_id = s.Id
                  LEFT JOIN Schools s2 ON o.onceki_okul_id = s2.Id
                  WHERE o.ogrenci_no LIKE @search OR o.ad LIKE @search OR o.soyad LIKE @search OR o.email LIKE @search", con))
            using (var da = new MySqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@search", "%" + search + "%");
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static bool StudentNumberExists(string ogrenciNo, int? excludeId = null)
        {
            using (var con = GetConnection())
            using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM ogrenciler WHERE ogrenci_no=@no" + (excludeId.HasValue ? " AND id<>@id" : ""), con))
            {
                cmd.Parameters.AddWithValue("@no", ogrenciNo);
                if (excludeId.HasValue)
                    cmd.Parameters.AddWithValue("@id", excludeId.Value);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        public static void AddStudent(
            string ogrenciNo, string ad, string soyad, DateTime dogumTarihi, string cinsiyet, string email, string telefon,
            string adres, int bolumId, string sinif, string yil, string kktcKimlikNo, string veliAdi, string veliTelefon, int okulId, int oncekiOkulId)
        {
            using (var con = GetConnection())
            using (var cmd = new MySqlCommand(
                @"INSERT INTO ogrenciler
                (ogrenci_no, ad, soyad, dogum_tarihi, cinsiyet, email, telefon, adres, bolum_id, sinif, yil, kktc_kimlik_no, veli_adi, veli_telefon, okul_id, onceki_okul_id)
                VALUES
                (@ogrenci_no, @ad, @soyad, @dogum_tarihi, @cinsiyet, @email, @telefon, @adres, @bolum_id, @sinif, @yil, @kktc_kimlik_no, @veli_adi, @veli_telefon, @okul_id, @onceki_okul_id)", con))
            {
                cmd.Parameters.AddWithValue("@ogrenci_no", ogrenciNo);
                cmd.Parameters.AddWithValue("@ad", ad);
                cmd.Parameters.AddWithValue("@soyad", soyad);
                cmd.Parameters.AddWithValue("@dogum_tarihi", dogumTarihi);
                cmd.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@telefon", telefon);
                cmd.Parameters.AddWithValue("@adres", adres);
                cmd.Parameters.AddWithValue("@bolum_id", bolumId);
                cmd.Parameters.AddWithValue("@sinif", sinif);
                cmd.Parameters.AddWithValue("@yil", yil);
                cmd.Parameters.AddWithValue("@kktc_kimlik_no", kktcKimlikNo);
                cmd.Parameters.AddWithValue("@veli_adi", veliAdi);
                cmd.Parameters.AddWithValue("@veli_telefon", veliTelefon);
                cmd.Parameters.AddWithValue("@okul_id", okulId);
                cmd.Parameters.AddWithValue("@onceki_okul_id", oncekiOkulId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateStudent(
            int id, string ogrenciNo, string ad, string soyad, DateTime dogumTarihi, string cinsiyet, string email, string telefon,
            string adres, int bolumId, string sinif, string yil, string kktcKimlikNo, string veliAdi, string veliTelefon, int okulId, int oncekiOkulId)
        {
            using (var con = GetConnection())
            using (var cmd = new MySqlCommand(
                @"UPDATE ogrenciler SET
                ogrenci_no=@ogrenci_no, ad=@ad, soyad=@soyad, dogum_tarihi=@dogum_tarihi, cinsiyet=@cinsiyet, email=@email, telefon=@telefon,
                adres=@adres, bolum_id=@bolum_id, sinif=@sinif, yil=@yil, kktc_kimlik_no=@kktc_kimlik_no, veli_adi=@veli_adi, veli_telefon=@veli_telefon,
                okul_id=@okul_id, onceki_okul_id=@onceki_okul_id
                WHERE id=@id", con))
            {
                cmd.Parameters.AddWithValue("@ogrenci_no", ogrenciNo);
                cmd.Parameters.AddWithValue("@ad", ad);
                cmd.Parameters.AddWithValue("@soyad", soyad);
                cmd.Parameters.AddWithValue("@dogum_tarihi", dogumTarihi);
                cmd.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@telefon", telefon);
                cmd.Parameters.AddWithValue("@adres", adres);
                cmd.Parameters.AddWithValue("@bolum_id", bolumId);
                cmd.Parameters.AddWithValue("@sinif", sinif);
                cmd.Parameters.AddWithValue("@yil", yil);
                cmd.Parameters.AddWithValue("@kktc_kimlik_no", kktcKimlikNo);
                cmd.Parameters.AddWithValue("@veli_adi", veliAdi);
                cmd.Parameters.AddWithValue("@veli_telefon", veliTelefon);
                cmd.Parameters.AddWithValue("@okul_id", okulId);
                cmd.Parameters.AddWithValue("@onceki_okul_id", oncekiOkulId);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteStudent(int id)
        {
            using (var con = GetConnection())
            using (var cmd = new MySqlCommand("DELETE FROM ogrenciler WHERE id=@id", con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
