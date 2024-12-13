using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Recipe", menuName = "Cooking/Recipe")]
public class Recipe_SO : ScriptableObject
{
    public FoodBase_SO[] ingredients;
    public FoodBase_SO result;
}
