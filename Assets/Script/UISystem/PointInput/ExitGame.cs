using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : IPoint
{
    public override void PointClick()
    {
        Application.Quit();
        base.PointClick();
    }
}
