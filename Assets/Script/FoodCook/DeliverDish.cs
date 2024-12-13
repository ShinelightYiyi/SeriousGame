using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverDish : MonoBehaviour
{

    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public bool checkDishDeliver(FoodBase_SO thisdish)
    {
        foreach(var order in OrderManager.Instance.orders)
        {
            for(int i=0;i < order.DishList.Count;i++)
            {
                if( thisdish.foodName == "Prefab" || thisdish.foodName == "prefab")
                {
                    order.isComplete[i] = true;
                    order.OrderComplete++;
                    order.checks[i].SetActive(true);
                    //못풀
                    DataManager.Instance.Earn += thisdish.price;
                    DataManager.Instance.Cost += thisdish.cost;
                    return true;
                }
                if (order.DishList[i] == thisdish && !order.isComplete[i])
                {
                    order.isComplete[i] = true;
                    order.OrderComplete ++;
                    order.checks[i].SetActive(true);
                    //못풀
                    DataManager.Instance.Earn += thisdish.price;
                    DataManager.Instance.Cost += thisdish.cost;
                    return true;
                }
            }
        }
        return false;
    }
}
