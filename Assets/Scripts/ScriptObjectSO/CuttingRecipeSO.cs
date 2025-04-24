using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
[Serializable]
public class CuttingRecipe
{
    public KitchenObjectSO input;
    public KitchenObjectSO output;

}
[CreateAssetMenu()]
public class CuttingRecipeListSO : ScriptableObject
{
    public List<CuttingRecipe> List;
    public KitchenObjectSO GetOutput(KitchenObjectSO input)
    {
        foreach (CuttingRecipe recipe in List)
        {
            if (recipe.input == input)
            {
                return recipe.output;
            }


        }
        return null;
    }
}