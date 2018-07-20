using System;
using JenkinsFW.Models;
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

        public void SaveRecipe(SaveRecipeModel data)
        {
            mxDB.Open();
            var tran = mxDB.BeginTransaction();
            try
            {
                string sql = "insert into Recipes (Title, Description, PrepTime, CookTime, Servings, Instructions) values (@Title, @Description, @PrepTime, @CookTime, @Servings, @Instructions)";
                SqliteCommand cmd = new SqliteCommand(sql,mxDB,tran);
                cmd.Parameters.Add(new SqliteParameter("@Title", data.title));
                cmd.Parameters.Add(new SqliteParameter("@Description", data.description));
                cmd.Parameters.Add(new SqliteParameter("@PrepTime", data.prepTime));
                cmd.Parameters.Add(new SqliteParameter("@CookTime", data.cookTime));
                cmd.Parameters.Add(new SqliteParameter("@Servings", data.servings));
                cmd.Parameters.Add(new SqliteParameter("@Instructions", data.instructions));
                cmd.ExecuteNonQuery();
                
                var cmd2 = new SqliteCommand("select last_insert_rowid()",mxDB,tran);
                var recipeid = ((cmd2.ExecuteScalar() as long?).Value as int?).Value;
                foreach(var i in data.ingredients)
                {
                    var icmd = new SqliteCommand("insert into ingredients (RecipeID, Name, Amount, DisplayOrder) values (@RecipeID, @Name, @Amount, @DisplayOrder)",mxDB,tran);
                    icmd.Parameters.Add(new SqliteParameter("@RecipeID", recipeid));
                    icmd.Parameters.Add(new SqliteParameter("@Name", i.name));
                    icmd.Parameters.Add(new SqliteParameter("@Amount", i.amount));
                    icmd.Parameters.Add(new SqliteParameter("@DisplayOrder", i.displayOrder));
                    icmd.ExecuteNonQuery();
                }
                tran.Commit();
            }
            catch(Exception e)
            {
                tran.Rollback();
                Console.WriteLine(e.Message);
            }
            finally
            {
                mxDB.Close();
            }
        }
    }
}
