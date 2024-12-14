using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartGame : IPoint
{
    public override void PointEnter()
    {
        gameObject.transform.DOScale(1.05f, 0.2f);
        base.PointEnter();
    }

    public override void PointExit()
    {
        gameObject.transform.DOScale(1f, 0.2f);
        base.PointExit();
    }

    public override void PointClick()
    {
        SceneController.Instance.LoadSceneAsyn("FoodA");
        base.PointClick();
    }
}
