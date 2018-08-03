namespace JenkinsFW.Models{

public class RecipeModel
{
       public int? ID{get;set;}
       public string title{get;set;}
       public string description{get;set;}
       public string prepTime{get;set;}
       public string cookTime{get;set;}
       public string servings{get;set;}
       public string instructions{get;set;}
       public IngredientModel[] ingredients{get;set;}
}

}