using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CuttingObject : MonoBehaviour
{
    public Transform canvas;
    public float CuttingDuration;
    public Transform tipsTransform;
    private FoodBase_SO foodContain;
    public GameObject Bar;
    public Image BarMask;
    public FoodBase_SO FoodContain
    {
        get { return foodContain; }
        set
        {
            foodContain = value;
            if (foodContain)
            {
                StartCoroutine(Cutting(CuttingDuration));
            }
            
        }
    }
    private bool onCutting = false;
    public bool OnCutting
    {
        get { return onCutting; }
        set
        {
            onCutting = value;
            if (onCutting)
            {
                //shakeTween.Play();
            }
            else
            {
                //shakeTween.Pause();
            }
        }
    }
    void Start()
    {
        Bar.SetActive(false);
    }
    IEnumerator Cutting(float duration)
    {
        Bar.SetActive(true);
        GenerateNewFoodTip(FoodContain.cutTrans);
        OnCutting = true;
        float Timer = 0;
        while (Timer < duration)
        {
            BarMask.fillAmount = Timer/duration;
            yield return new WaitForSeconds(Time.deltaTime);
            Timer += Time.deltaTime;
        }
        GameObject product = Instantiate(Resources.Load<GameObject>("Prefab/FoodBasicPrefab"));
        product.GetComponent<RectTransform>().SetParent(canvas);
        product.GetComponent<RectTransform>().localPosition = GetComponent<RectTransform>().localPosition;
        product.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        product.GetComponent<FoodBasic>().food_SO = FoodContain.cutTrans;
        Bar.SetActive(false);
        FoodContain = null;
        ClearTips();
        OnCutting = false;
        //生成切好的菜品
    }
    public void ClearTips()
    {
        foreach (Transform tips in tipsTransform)
        {
            Destroy(tips.gameObject);
        }
    }
    public void GenerateNewFoodTip(FoodBase_SO foodBase)
    {
        GameObject Tips = Instantiate(Resources.Load<GameObject>("Prefab/IngredientsTip"));
        Tips.transform.SetParent(tipsTransform);
        Tips.GetComponent<Image>().sprite = foodBase.sprite;
    }

}
