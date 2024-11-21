using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PassPanel : BasePanel
{
    private static string name = "PassPanel";
    private static string path = "Panel/PassPanel";
    private readonly static UIType newUIType = new UIType(name, path);
    public PassPanel() : base(newUIType)
    {

    }

    public override void OnStart()
    {
        base.OnStart();
        PassPanelIn();
        EventCenter.Instance.AddEventListener<float>("¼ÓÔØ³¡¾°" , (o)=>PassPanelOut(o));
    }

    private void PassPanelIn()
    {
        GameObject go;
        go = GameObject.FindGameObjectWithTag("PassPanel");
        if(go == null )
        {
            Debug.LogWarning("NO!");
            return;
        }
        Image image = go.GetComponent<Image>();
        DG.Tweening.Sequence imageSequence = DOTween.Sequence(image);
        imageSequence.Append(image.DOFade(1f, 0.2f));
    }

    private void PassPanelOut(float o)
    {
        if(o == 1f)
        {
            GameObject go;
            go = GameObject.FindGameObjectWithTag("PassPanel");
            if(go == null)
            {
                Debug.LogWarning("NO!");
                return;
            }
            Image image = go.GetComponent<Image>();
            DG.Tweening.Sequence imageSequence = DOTween.Sequence(image);
            imageSequence.Append(image.DOFade(0f, 1f));
            imageSequence.OnComplete(() => GameObject.Destroy(go));
        }
    }
}
