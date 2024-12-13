using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BookIngrediantTip : IPoint
{
    public FoodBase_SO thisIngrediant;
    public Image tips;
    public TMP_Text tipText;
    public Image thisImage;
    void Start()
    {
        tipText.text = thisIngrediant.foodName;
        thisImage.sprite = thisIngrediant.sprite;
    }

    // Update is called once per frame
    public override void PointEnter()
    {
        tips.gameObject.SetActive(true);
    }
    public override void PointExit()
    {
        tips.gameObject.SetActive(false);
    }
}
