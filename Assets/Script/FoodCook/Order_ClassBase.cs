using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Order_ClassBase : MonoBehaviour
{
    public float maxTime;
    public List<FoodBase_SO> DishList = new List<FoodBase_SO>();
    public float timeRemain;
    public GameObject[] checks = new GameObject[4];
    public Image[] images = new Image[4];
    public bool[] isComplete = new bool[4];
    public Image timeBar;
    private int orderComplete;
    public int OrderComplete
    {
        get { return orderComplete; }
        set 
        { 
            orderComplete = value; 
            if(orderComplete >= DishList.Count)
            {
                OrderManager.Instance.orders.Remove(this);
                Destroy(gameObject);
            }
        }
    }

    private void Start()
    {
        OrderComplete = 0;
        timeRemain = maxTime;
        for(int i = 0;i < DishList.Count ; i++)
        {
            images[i].sprite = DishList[i].sprite;
            images[i].gameObject.GetComponent<OrderTips>().thisDish = DishList[i];
            images[i].gameObject.SetActive(true);
        }
    }
    private void Update()
    {
        if (timeRemain <= 0)
        {
            OrderManager.Instance.orders.Remove(this);
            Destroy(gameObject);
        }
        timeRemain -= Time.deltaTime;
        timeBar.fillAmount = timeRemain / maxTime;
      
    }
}
