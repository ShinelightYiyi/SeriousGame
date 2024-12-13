using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// 0������ʹ��Ԥ�Ʋ� 1��������ʹ��Ԥ�Ʋ�
    /// </summary>
    public int prefabFood;
    /// <summary>
    /// 0���̵��������� 1���̵굹�ս��뻵���
    /// </summary>
    public int closeDown;
    /// <summary>
    /// ����Ŀǰ�������˷���
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
