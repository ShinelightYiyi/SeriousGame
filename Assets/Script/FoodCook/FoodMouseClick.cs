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
            // 获取当前鼠标的屏幕坐标
            Vector2 screenPos = Input.mousePosition;

            Vector2 localPos;
            Camera uiCamera = Camera.main;  // 获取主摄像机（如果Canvas绑定了其他摄像机，则改为指定的摄像机）

            // 使用指定的摄像机进行转换
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, screenPos, uiCamera, out localPos);

            // 将UI物体的位置设置为计算得到的局部位置
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
        // 获取两个 RectTransform 的世界坐标
        Rect rect1WorldSpace = GetWorldRect(rect1);
        Rect rect2WorldSpace = GetWorldRect(rect2);

        // 判断两个矩形是否重叠
        return rect1WorldSpace.Overlaps(rect2WorldSpace);
    }
    Rect GetWorldRect(RectTransform rectTransform)
    {
        Vector3[] worldCorners = new Vector3[4];
        rectTransform.GetWorldCorners(worldCorners);

        // 获取原始矩形的最小和最大坐标
        Vector2 min = worldCorners[0];
        Vector2 max = worldCorners[2];
        // 计算矩形中心
        Vector2 center = (min + max) / 2;

        // 将矩形的每条边缩小至原先的一半
        Vector2 newMin = center + (min - center) / 2;
        Vector2 newMax = center + (max - center) / 2;

        return new Rect(newMin, newMax - newMin);
    }

}
