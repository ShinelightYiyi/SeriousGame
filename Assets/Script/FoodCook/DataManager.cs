using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DataManager : MonoBehaviour
{
    public float RegularCost;
    public float Earn;
    public float Cost;
    public float MaxTimer;

    float Timer;

    public GameObject endPanel;
    public TMP_Text EarnText;
    public TMP_Text CostText;
    public TMP_Text RegulerText;
    public TMP_Text ClearEarnText;
    public TMP_Text TimeLack;
    public static DataManager Instance { get; private set; }
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        Timer = MaxTimer;
    }
    private void Update()
    {
        if (Timer <= 0)
        {
            return;
        }
        Timer -= Time.deltaTime;
        TimeLack.text = ((int)(Timer / 60f)).ToString() + "��" + ((int)(Timer % 60f));
        if(Timer <= 0)
        {
            setEndUI();
        }
    }
    public void setEndUI()
    {
        StartCoroutine (SetEndUI());
    }
    IEnumerator SetEndUI()
    {
        endPanel.SetActive(true);
        yield return new WaitForSeconds(1f);

        EarnText.text = "����Ӫ�գ�" + Earn;
        EarnText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);

        CostText.text = "��Ʒ�ɱ���" + Cost;
        CostText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);

        RegulerText.text = "��Ӫ�ɱ���" + RegularCost;
        RegulerText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);

        ClearEarnText.text = "��Ӫ�գ�" + (Earn - Cost - RegularCost);
        ClearEarnText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
    }
}
