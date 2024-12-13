using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// 0：允许使用预制菜 1：不允许使用预制菜
    /// </summary>
    public int prefabFood;
    /// <summary>
    /// 0；商店正常运行 1：商店倒闭进入坏结局
    /// </summary>
    public int closeDown;
    /// <summary>
    /// 衡量目前餐厅的浪费量
    /// </summary>
    public float wastedCount;

    private float earn;
    public float Earn
    {
        get { return earn; }
        set
        {
            earn = value;
            if(earn<0)
            {
                closeDown = 1;
            }
        }
    }
    public static GameManager Instance { get; private set; }
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }
}
