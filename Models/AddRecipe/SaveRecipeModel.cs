namespace JenkinsFW.Models{

public class SaveRecipeModel
{
       public string title{get;set;}
       public string description{get;set;}
       public string prepTime{get;set;}
       public string cookTime{get;set;}
       public string servings{get;set;}
       public string instructions{get;set;}
       public SaveIngredientModel[] ingredients{get;set;}
}

}