using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;
using TMPro;

public class OrderTips : IPoint
{
    public FoodBase_SO thisDish;
    public Image tips;
    public TMP_Text tipText;
    private void Start()
    {
        tipText.text = thisDish.foodName;
    }
    public override void PointEnter()
    {
        tips.gameObject.SetActive(true);
    }
    public override void PointExit()
    {
        tips.gameObject.SetActive(false);
    }
}
