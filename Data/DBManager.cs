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
            //string sql = "insert into ingredients (RecipeID, Name, Amount, DisplayOrder) values (@RecipeID, @Name, @Amount, @DisplayOrder)"
            string sql = "insert into Recipes (Title, Description, PrepTime, CookTime, Servings, Instructions) values (@Title, @Description, @PrepTime, @CookTime, @Servings, @Instructions)";
            SqliteCommand cmd = new SqliteCommand(sql,mxDB);
            cmd.Parameters.Add(new SqliteParameter("@Title", data.title));
            cmd.Parameters.Add(new SqliteParameter("@Description", data.description));
            cmd.Parameters.Add(new SqliteParameter("@PrepTime", data.prepTime));
            cmd.Parameters.Add(new SqliteParameter("@CookTime", data.cookTime));
            cmd.Parameters.Add(new SqliteParameter("@Servings", data.servings));
            cmd.Parameters.Add(new SqliteParameter("@Instructions", data.instructions));
            cmd.ExecuteNonQuery();
            
            var cmd2 = new SqliteCommand("select last_insert_rowid()",mxDB);
            var recipeid = cmd2.ExecuteScalar();
            // if (!recipeid.HasValue)
            // {
            //     throw new InvalidOperationException("Recipe Insert failed to return ID");
            // }
            mxDB.Close();
            Console.WriteLine(string.Format("{0}: {1}:{2}; ",
            nameof(SaveRecipe), nameof(recipeid), recipeid));
        }
    }
}
