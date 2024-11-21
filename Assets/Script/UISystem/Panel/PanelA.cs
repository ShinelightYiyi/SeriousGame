using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelA : BasePanel
{
    private static string name = "PanelA";
    private static string path = "Panel/PanelA";

    public static UIType uiType = new UIType(name, path);
    public PanelA() : base(uiType)
    {

    }


}
