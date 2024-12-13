using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookManager : MonoBehaviour
{
    public GameObject[] pages;
    int curPage;
    private void OnEnable()
    {
        //Time.timeScale = 0;
        pages[curPage].SetActive(false);
        curPage = 0;
        pages[curPage].SetActive(true);
    }
    public void OnNextPage()
    {
        if(curPage >= pages.Length -1) { return; }
        pages[curPage++].SetActive(false);
        pages[curPage].SetActive(true);
    }
    public void OnPrePage()
    {
        if (curPage <= 0) { return; }
        pages[curPage--].SetActive(false);
        pages[curPage].SetActive(true);
    }
    public void OnExitBook()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
    public void OnOpenBook()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }
}
