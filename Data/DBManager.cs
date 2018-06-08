using System;
using Microsoft.Data.Sqlite;

namespace JenkinsFW.Data{
    public class DBManager{
        SqliteConnection mxDB;
        
        public DBManager ()
        {
            mxDB=new SqliteConnection("Data Source=JenkinsFW.sqlite;");
        }

        public void loadrecipe()
        {
            mxDB.Open();
            SqliteCommand cmd = new SqliteCommand("select * from measuringunits",mxDB);
            SqliteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["Unit"]+" "+reader["ID"]);
            }
        }
    }
}
