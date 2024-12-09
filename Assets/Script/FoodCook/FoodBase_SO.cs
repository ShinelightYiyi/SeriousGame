using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New FoodBase", menuName = "Cooking/FoodBase")]
public class FoodBase_SO : ScriptableObject
{
    public string foodName;
    public FoodBase_SO cutTrans;
    public FoodBase_SO bollTrans;
    public FoodBase_SO fryTrans;
    public Sprite sprite;
    public float cost;
    public float price;
}
