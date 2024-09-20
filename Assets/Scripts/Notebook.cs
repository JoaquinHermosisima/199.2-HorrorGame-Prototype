using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notebook : MonoBehaviour
{
    [SerializeField] float pageSpeed = 0.5f;
    [SerializeField] List<Transform> pages;
    [SerializeField] GameObject SymbolTestKa;
    [SerializeField] GameObject SymbolTestKi;
    [SerializeField] GameObject SymbolTestKu;

    [SerializeField] GameObject SymbolTestKe;

    [SerializeField] GameObject SymbolTestKo;
    int index = -1;
    bool rotate = false;
    [SerializeField] GameObject previous;
    [SerializeField] GameObject next;

    [SerializeField] List<GameObject> HiraganaSymbols;
    

    public void Start()
    {
        previous.SetActive(false);
        for(int i = 0; i < 5;  i++)
        {
            HiraganaSymbols[i].SetActive(false);
        }
    }

    public void RotateForward()
    {
        if (rotate == true) {return; }
        index++;
        float angle = 180;
        NextButtonActions();
        pages[index].SetAsLastSibling();
        StartCoroutine(Rotate(angle, true));
    }

    public void NextButtonActions()
    {
        if(previous.activeInHierarchy==false)
        {
            previous.SetActive(true);
        }
        if (index == pages.Count - 1)
        {
            next.SetActive(false);
        }
    }

    public void PreviousButtonActions()
    {
        if (next.activeInHierarchy == false)
        {
            next.SetActive(true);
        }
        if (index -1 == -1) 
        {
            previous.SetActive(false);
        }
    }

    public void RotateBack()
    {
        if (rotate == true) {return; }
        float angle = 0;
        pages[index].SetAsLastSibling();
        PreviousButtonActions();
        StartCoroutine(Rotate(angle, false));
    }

    IEnumerator Rotate(float angle, bool forward)
    {
        float value = 0f;
        while (true)
        {
            rotate = true;
            Quaternion targetRotation=Quaternion.Euler(0, angle, 0);
            value += Time.deltaTime * pageSpeed;
            pages[index].rotation = Quaternion.Slerp(pages[index].rotation, targetRotation, value);
            float angle1=Quaternion.Angle(pages[index].rotation, targetRotation);
            if(angle1 < 0.1f)
            {
                if(forward == false)
                {
                    index--;
                }
                rotate = false;
                break;
            }
            yield return null;
        }
    }

    void Update()
    {
        if (SymbolTestKa.activeSelf == false)
        {
            HiraganaSymbols[0].SetActive(true);
        }  
        
        if (SymbolTestKi.activeSelf == false)
        {
            HiraganaSymbols[1].SetActive(true);
        }    

        if (SymbolTestKu.activeSelf == false)
        {
            HiraganaSymbols[2].SetActive(true);
        }    

        if (SymbolTestKe.activeSelf == false)
        {
            HiraganaSymbols[3].SetActive(true);
        }    

        if (SymbolTestKo.activeSelf == false)
        {
            HiraganaSymbols[4].SetActive(true);
        }    
    }
}
