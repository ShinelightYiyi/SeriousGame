using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Unity.VisualScripting;

public class ProcessingObject : IPoint
{
    [Header("DoTween参数")]
    public float shakeDuration = 1f;
    public float shakeStrength = 1f; 
    public int shakeFrequency = 10;
    [Header("其他")]
    public Recipe_SO[] recipes;
    public List<FoodBase_SO> foodContains;
    public Recipe_SO onProcessingRecipe = null;
    public float processingTime;
    private bool onProcessing;
    Tween shakeTween;
    Canvas canvas;

    public bool OnProcessing
    {
        get { return onProcessing; }
        set 
        { 
            onProcessing = value;
            if (onProcessing)
            {
                shakeTween.Play();
            }   
            else
            {
                shakeTween.Pause();
                transform.DORotate(new Vector3(0, 0, 0), 0.5f);
            }
        }
    }
    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        shakeTween = GetComponent<RectTransform>().DORotate(new Vector3(0, 0, shakeStrength), shakeDuration, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Yoyo)  // 设置无限循环并反向播放
            .Pause();
    }
    public Recipe_SO checkPosibleRecipe()
    {
        foreach (var recipe in recipes)
        {
            bool posibleRecipe = true;
            
            foreach (var food in recipe.ingredients)
            {
                if (!foodContains.Contains(food))
                {
                    posibleRecipe = false;
                    break;
                }
            }
            if (posibleRecipe)
            {
                return recipe;
            }
        }
        return null;
    }
    public void TryProcessing()
    {
        if(onProcessingRecipe = checkPosibleRecipe())
        {
            ClearTips();
            OnProcessing = true;
            GenerateNewFoodTip(onProcessingRecipe.result);
            StartCoroutine(Processing());
        }
    }
    public override void PointClick()
    {
        TryProcessing();
    }
    public Recipe_SO checkPosibleRecipe(FoodBase_SO curFood)
    {
        foreach (var recipe in recipes)
        {
            bool posibleRecipe = true;
            foreach (var food in foodContains)
            {
                if (!recipe.ingredients.Contains(food))
                {
                    posibleRecipe = false;
                    break;
                }
            }
            if (posibleRecipe && recipe.ingredients.Contains(curFood))
            {
                return recipe;
            }
        }
        return null;
    }
    public void GenerateNewFoodTip(FoodBase_SO foodBase)
    {
        GameObject Tips = Instantiate(Resources.Load<GameObject>("Prefab/IngredientsTip"));
        Tips.transform.SetParent(transform);
        Tips.GetComponent<Image>().sprite = foodBase.sprite;
    }
    
    public void ClearTips()
    {
        foreach(Transform tips in transform)
        {
            Destroy(tips.gameObject);
        }
    }
    IEnumerator Processing()
    {
        foodContains.Clear();
        float Timer = 0;
        while (Timer < processingTime)
        {
            Timer += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        OnProcessing = false;
        GenerateResult();
        onProcessingRecipe = null;
        ClearTips();
    }
    void GenerateResult()
    {
        GameObject newFood = Instantiate(Resources.Load<GameObject>("Prefab/FoodBasicPrefab"));
        newFood.GetComponent<FoodBasic>().food_SO = onProcessingRecipe.result;
        newFood.transform.SetParent(canvas.transform);
        newFood.transform.position = transform.position + new Vector3( 0, -1, 0);
        newFood.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
    }
}
