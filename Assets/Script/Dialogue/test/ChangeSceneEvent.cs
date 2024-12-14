using NodeCanvas.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneEvent : ActionTask
{
    public string sceneName;

    protected override void OnExecute()
    {
        SceneController.Instance.LoadSceneAsyn(sceneName);
        EndAction();
    }
}
