using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceptMessage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventCenter.Instance.AddEventListener<int>("Change", (o) => acceptInt(o));
    }

    private void acceptInt(int o)
    {
        Debug.LogWarning("��ǰ����Ϊ" + o);
    }
}
