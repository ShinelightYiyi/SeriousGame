using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabFoodSelfCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.Instance.prefabFood == 0)
        {
            gameObject.SetActive(false);
        }
    }
}