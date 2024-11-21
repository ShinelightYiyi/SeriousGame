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
    /// ����
    /// </summary>
    public virtual void PointDown()
    {

    }


    /// <summary>
    /// �����뷶Χ
    /// </summary>
    public virtual void PointEnter()
    {

    }


    /// <summary>
    /// ̧��
    /// </summary>
    public virtual void PointUp()
    {

    }

    /// <summary>
    /// �뿪
    /// </summary>
    public virtual void PointExit()
    {

    }

    /// <summary>
    /// ���  
    /// </summary>
    public virtual void PointClick()
    {

    }

}
