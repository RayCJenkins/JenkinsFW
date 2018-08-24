using System;
using System.Collections.Generic;
using JenkinsFW.Models;
using Microsoft.Data.Sqlite;

namespace JenkinsFW.Data{
    public class DBManager{
        SqliteConnection mxDB;
        
        public DBManager ()
        {
            mxDB=new SqliteConnection("Data Source=JenkinsFW.sqlite;");
        }

        public void SaveRecipe(RecipeModel data)
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
                var recipeid = Convert.ToInt32(cmd2.ExecuteScalar());
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

        public RecipeModel LoadRecipe(int recipeid)
        {
            mxDB.Open();
            SqliteCommand cmd = new SqliteCommand("select ID, Title, Description, PrepTime, CookTime, Servings from Recipes where id = @Recipeid",mxDB);
            cmd.Parameters.Add(new SqliteParameter("@Recipeid", recipeid));    
            SqliteDataReader reader = cmd.ExecuteReader();

        }

        public List<RecipeListItem> LoadRecipes()
        {
            mxDB.Open();
            SqliteCommand cmd = new SqliteCommand("select ID, Title, Description, PrepTime, CookTime, Servings from Recipes order by Title COLLATE NOCASE",mxDB);
            SqliteDataReader reader = cmd.ExecuteReader();
            var Result = new List<RecipeListItem>();

            while (reader.Read())
            {
                var newRecipe = new RecipeListItem{
                    description = Convert.ToString(reader["Description"]),
                    ID = Convert.ToInt32(reader["ID"]),
                    title = Convert.ToString(reader["Title"]),
                    prepTime = Convert.ToString(reader["PrepTime"]),
                    cookTime = Convert.ToString(reader["CookTime"]),
                    servings = Convert.ToString(reader["Servings"])
                };
                Result.Add(newRecipe);
            } 

            return Result;
        }

    }
}
