using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerT : MonoBehaviour
{

    private int inputNub = 0;
    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.Push(new PanelA(),true);
        EventCenter.Instance.AddEventListener("Input", () => AcceptInput());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void AcceptInput()
    {
        inputNub++;
        Debug.Log(inputNub);
    }
}
