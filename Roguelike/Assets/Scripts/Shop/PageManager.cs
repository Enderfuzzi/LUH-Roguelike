using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageManager : MonoBehaviour
{
    private int pageIndicator = 0;

    [SerializeField] private GameObject[] pages;

    private bool firstInit = true;

    void Awake()
    {
        if (firstInit)
        {
            pages = GameObject.FindGameObjectsWithTag("Page");
            firstInit = false;
        }
        pageIndicator = 0;
        setPagesToValue(false);
        pages[pageIndicator].SetActive(true);
    }

    public void nextPage()
    {
        pages[pageIndicator].SetActive(false);
        pageIndicator = ++pageIndicator % pages.Length;
        pages[pageIndicator].SetActive(true);
    }

    private void setPagesToValue(bool value)
    {
        
        foreach (GameObject page in pages)
        {
            page.SetActive(value);
        }
       
    }

    void OnDisable()
    {
        
    }


}
