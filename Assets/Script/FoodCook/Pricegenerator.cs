using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pricegenerator : MonoBehaviour
{
    public FoodBase_SO thisFood;
    public TMP_Text tmp;
    void Start()
    {
        tmp.text = "成本：" + thisFood.cost + "  售价：" + thisFood.price;
    }
}
