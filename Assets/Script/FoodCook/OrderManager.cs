using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static OrderManager Instance { get; private set; }  // ����ʵ��
    public GameObject orderPanel;
    public float orderDuration;
    public FoodBase_SO[] dishes;
    public float Timer = 0;
    public List<Order_ClassBase> orders = new List<Order_ClassBase>();
    public float generateOrderDelta;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        // ��ʼ��һЩ���ݣ�������Ҫ��
        GenerateNewOrder();
    }

    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > generateOrderDelta && orders.Count <= 4)
        {
            // �����¶������߼�
            GenerateNewOrder();
            Timer = 0f;  // ���ü�ʱ��
        }
    }

    void GenerateNewOrder()
    {
        GameObject newOrder_obj = Instantiate(Resources.Load<GameObject>("Prefab/NewOrder"));
        newOrder_obj.transform.parent = orderPanel.transform;
        newOrder_obj.transform.localScale = new Vector3 (1, 1, 1);

        Order_ClassBase newOrder = newOrder_obj.GetComponent<Order_ClassBase>();
        int amountRand = Random.Range(0, 100);
        newOrder.DishList.Add(dishes[Random.Range(0, dishes.Length)]);
        if (amountRand > 30) newOrder.DishList.Add(dishes[Random.Range(0, dishes.Length)]);
        if (amountRand > 60) newOrder.DishList.Add(dishes[Random.Range(0, dishes.Length)]);
        if (amountRand > 90) newOrder.DishList.Add(dishes[Random.Range(0, dishes.Length)]);
        newOrder.maxTime = orderDuration;
        orders.Add(newOrder);
    }
}
