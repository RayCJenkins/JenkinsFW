namespace JenkinsFW.Models{

public class SaveRecipeModel
{
       public string Title{get;set;}
       public string Description{get;set;}
       public string PrepTime{get;set;}
       public string CookTime{get;set;}
       public string Servings{get;set;}
       public string Instructions{get;set;}
       public SaveIngredientModel[] Ingredients{get;set;}
}

}