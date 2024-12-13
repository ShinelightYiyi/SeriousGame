using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMouseClick : IPoint
{
    RectTransform canvasRectTransform;
    RectTransform rectTransform;
    public ProcessingObject inAreaProcessing;
    public CuttingObject inAreaCutting;
    public DeliverDish inAreaDeliver;
    bool onDrag = false;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        Canvas canvas = GetComponentInParent<Canvas>();
        canvasRectTransform = canvas.GetComponent<RectTransform>();
    }
    void Update()
    {
        if (onDrag)
        {
            // ��ȡ��ǰ������Ļ����
            Vector2 screenPos = Input.mousePosition;

            Vector2 localPos;
            Camera uiCamera = Camera.main;  // ��ȡ������������Canvas������������������Ϊָ�����������

            // ʹ��ָ�������������ת��
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, screenPos, uiCamera, out localPos);

            // ��UI�����λ������Ϊ����õ��ľֲ�λ��
            GetComponent<RectTransform>().localPosition = localPos;
        }

    }
    public override void PointDown()
    {
        if(MouseMoveManager.Instance.HandleingObject)
        {
            return;
        }
        onDrag = true;
        MouseMoveManager.Instance.HandleingObject = true; 
    }
    public override void PointUp()
    {
        if(onDrag)
        {
            inAreaCutting = null;
            inAreaProcessing = null;
            inAreaDeliver = null;
            onDrag = false;
            MouseMoveManager.Instance.HandleingObject = false;
            GameObject[] allUIObjects = GameObject.FindGameObjectsWithTag("Processing");
            
            foreach(var uiObject in allUIObjects)
            {
                if (uiObject == gameObject)
                    continue;
                RectTransform otherRectTransform = uiObject.GetComponent<RectTransform>();
                if (otherRectTransform != null && IsRectOverlap(rectTransform, otherRectTransform))
                {
                    
                    uiObject.TryGetComponent(out inAreaProcessing);
                    uiObject.TryGetComponent(out inAreaCutting);
                    uiObject.TryGetComponent(out inAreaDeliver);
                }
            }
            if(inAreaProcessing && !inAreaProcessing.OnProcessing)
            {
                if(inAreaProcessing.checkPosibleRecipe(GetComponent<FoodBasic>().food_SO))
                {
                    inAreaProcessing.foodContains.Add(GetComponent<FoodBasic>().food_SO);
                    inAreaProcessing.GenerateNewFoodTip(GetComponent<FoodBasic>().food_SO);
                  
                    Destroy(gameObject);
                }
            }
            else if (inAreaCutting && !inAreaCutting.OnCutting && GetComponent<FoodBasic>().food_SO.cutTrans != null)
            {
                inAreaCutting.FoodContain = GetComponent<FoodBasic>().food_SO;
                Destroy(gameObject);
            }
            else if (inAreaDeliver && inAreaDeliver.checkDishDeliver(GetComponent<FoodBasic>().food_SO))
            {
                Destroy(gameObject);
            }
        }
    }
    bool IsRectOverlap(RectTransform rect1, RectTransform rect2)
    {
        // ��ȡ���� RectTransform ����������
        Rect rect1WorldSpace = GetWorldRect(rect1);
        Rect rect2WorldSpace = GetWorldRect(rect2);

        // �ж����������Ƿ��ص�
        return rect1WorldSpace.Overlaps(rect2WorldSpace);
    }
    Rect GetWorldRect(RectTransform rectTransform)
    {
        Vector3[] worldCorners = new Vector3[4];
        rectTransform.GetWorldCorners(worldCorners);

        // ��ȡԭʼ���ε���С���������
        Vector2 min = worldCorners[0];
        Vector2 max = worldCorners[2];
        // �����������
        Vector2 center = (min + max) / 2;

        // �����ε�ÿ������С��ԭ�ȵ�һ��
        Vector2 newMin = center + (min - center) / 2;
        Vector2 newMax = center + (max - center) / 2;

        return new Rect(newMin, newMax - newMin);
    }

}
