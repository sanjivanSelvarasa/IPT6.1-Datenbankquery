using Select_InsertQuery2;

Query.Init();

using var con = Query.Open();
using var cmd = con.CreateCommand();
cmd.CommandText = "SELECT Name FROM Role";
using var r = cmd.ExecuteReader();
while (r.Read()) Console.WriteLine(r.GetString(0));
