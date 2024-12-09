using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMoveManager
{
    public bool HandleingObject = false;
    private static MouseMoveManager _instance;
    private MouseMoveManager() { }

    public static MouseMoveManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new MouseMoveManager();
            }
            return _instance;
        }
    }
}
