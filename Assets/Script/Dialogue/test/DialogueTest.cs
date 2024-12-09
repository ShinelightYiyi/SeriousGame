using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.DialogueTrees;

public class DialogueTest : MonoBehaviour
{
    DialogueTreeController treeController;
    bool isOnce = true;
    private void Start()
    {
        treeController = GetComponent<DialogueTreeController>();
    }


    private void Update()
    {
        StartTalk();
    }


    private void StartTalk()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnce)
        {
            isOnce = false;
            treeController.StartDialogue();
        }
    }
}
