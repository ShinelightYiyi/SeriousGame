using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GenerateFoodBase : MonoBehaviour
{
    public FoodBase_SO foodBase;
    public GameObject newFood;
    Transform newfoodTrans;
    Canvas canvas;

    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        GenerateNew();
    }
    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            if((newfoodTrans.position - transform.position).magnitude >2f)
            {
                GenerateNew();
            }
            else
            {
                newfoodTrans.position = transform.position;
            }    
        }
    }
    void GenerateNew()
    {
        newFood = Instantiate(Resources.Load<GameObject>("Prefab/FoodBasicPrefab"));
        newFood.GetComponent<FoodBasic>().food_SO = foodBase;
        newFood.transform.SetParent(canvas.transform);
        newFood.transform.position = transform.position;
        newFood.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        newfoodTrans = newFood.transform;
    }
}
