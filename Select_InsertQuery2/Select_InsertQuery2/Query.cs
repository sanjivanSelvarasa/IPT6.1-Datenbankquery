using Microsoft.Data.Sqlite;
using System;
using System.IO;

namespace Select_InsertQuery2
{
    static class Query
    {
        private static readonly string Root =
            @"C:\Users\sanji\Documents\GitHub\IPT6.1-Datenbankquery\Select_InsertQuery2";

        public static string DbPath =>
            Path.Combine(Root, "Data", "database.db");

        public static SqliteConnection Open()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(DbPath) ?? Root);
            var con = new SqliteConnection($"Data Source={DbPath}");
            con.Open();
            return con;
        }

        public static void Init()
        {
            using (var con = Open())
            {
                // DB ist "ready", wenn z.B. die Role-Tabelle existiert
                if (TableExists(con, "Role")) return;

                ExecuteSqlFile(con, Path.Combine(Root, "Sql", "sqlite_create.sql"));
                ExecuteSqlFile(con, Path.Combine(Root, "Sql", "sqlite_seed.sql"));
            }
        }

        private static bool TableExists(SqliteConnection con, string tableName)
        {
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText =
                    "SELECT 1 FROM sqlite_master WHERE type='table' AND name=$name LIMIT 1;";
                cmd.Parameters.AddWithValue("$name", tableName);

                var result = cmd.ExecuteScalar();
                return result != null;
            }
        }

        private static void ExecuteSqlFile(SqliteConnection con, string fullPath)
        {
            var sql = File.ReadAllText(fullPath);

            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
