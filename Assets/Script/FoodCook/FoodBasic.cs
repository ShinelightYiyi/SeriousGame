using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodBasic : MonoBehaviour
{
    public FoodBase_SO food_SO;

    private void Start()
    {
        GetComponent<Image>().sprite = food_SO.sprite;
    }
}
