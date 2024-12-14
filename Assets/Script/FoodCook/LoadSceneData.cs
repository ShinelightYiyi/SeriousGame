using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneData : MonoBehaviour
{
    public string nextLevel;
    public string badEnding;
    public void NextDay()
    {
        SceneController.Instance.LoadSceneAsyn(nextLevel);
    }
}
