using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneData : MonoBehaviour
{
    public string nextLevel;
    public string badEnding;
    public void NextDay()
    {
        if(GameManager.Instance.closeDown == 0) SceneController.Instance.LoadSceneAsyn(nextLevel);
        else SceneController.Instance.LoadSceneAsyn(badEnding);
    }
}
