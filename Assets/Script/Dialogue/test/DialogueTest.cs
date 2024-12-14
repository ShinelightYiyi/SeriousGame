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
        treeController.StartDialogue();
    }


    private void Update()
    {
    }



}
