using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelB : BasePanel
{

    private static string name = "PanelB";
    private static string path = "Panel/PanelB";

    public static UIType uiType = new UIType(name, path);
    public PanelB() : base(uiType)
    {

    }
}
