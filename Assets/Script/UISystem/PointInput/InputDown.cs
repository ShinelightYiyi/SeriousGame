using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class InputDown : IPoint
{

    public override void PointEnter()
    {
        gameObject.transform.DOScale(1.1f, 0.2f);
        Debug.Log("Enter " + gameObject.name);
        base.PointEnter();
    }

    public override void PointExit()
    {
        gameObject.transform.DOScale(1f, 0.2f);
        Debug.Log("Exit " + gameObject.name);
        base.PointExit();
    }



    public override void PointClick()
    {
        EventCenter.Instance.EventTrigger("Input");
        UIManager.Instance.Push(new PanelB(),true);
        base.PointClick();
    }
}
