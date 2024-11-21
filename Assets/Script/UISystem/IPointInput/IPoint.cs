using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class IPoint : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler,IPointerClickHandler
{
    #region Interface  
    public void OnPointerDown(PointerEventData eventData)
    {
        PointDown();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PointEnter();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PointExit();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        PointUp();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PointClick();
    }

    #endregion

    /// <summary>
    /// 按下
    /// </summary>
    public virtual void PointDown()
    {

    }


    /// <summary>
    /// 鼠标进入范围
    /// </summary>
    public virtual void PointEnter()
    {

    }


    /// <summary>
    /// 抬起
    /// </summary>
    public virtual void PointUp()
    {

    }

    /// <summary>
    /// 离开
    /// </summary>
    public virtual void PointExit()
    {

    }

    /// <summary>
    /// 点击  
    /// </summary>
    public virtual void PointClick()
    {

    }

}
