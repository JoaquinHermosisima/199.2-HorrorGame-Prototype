using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class book : MonoBehaviour
{
    [SerializeField] float pageSpeed = 0.5f;
    [SerializeField] List<Transform> pages;
    public int index = -1;
    int activeSymbols = 0;
    bool rotate = false;
    [SerializeField] GameObject backButton;
    [SerializeField] GameObject forwardButton;
    [SerializeField] List<GameObject> symbols;

    [SerializeField] GameObject AObject;

    [SerializeField] GameObject IObject;

    [SerializeField] GameObject UObject;
    [SerializeField] GameObject EObject;
    [SerializeField] GameObject OObject;

    [SerializeField] GameObject KaObject;
    [SerializeField] GameObject KiObject;
    [SerializeField] GameObject KuObject;
    [SerializeField] GameObject KeObject;
    [SerializeField] GameObject KoObject;

    private void Start()
    {
        InitialState();
        
    }

    public void InitialState()
    {
        for (int i=0; i<pages.Count; i++)
        {
            pages[i].transform.rotation=Quaternion.identity;
        }

        for(int i = 0; i <= 9; i++)
        {
            symbols[i].SetActive(false);
        }
        pages[0].SetAsLastSibling();
        backButton.SetActive(false);
        activeSymbols = 0;

    }

    public void RotateForward()
    {
        if (rotate == true) { return; }
        index++;
        float angle = 180;
        ForwardButtonActions();
        pages[index].SetAsLastSibling();
        StartCoroutine(Rotate(angle, true));

    }

    public void ForwardButtonActions()
    {
        
        if (backButton.activeInHierarchy == false)
        {
            backButton.SetActive(true);
        }
        if (index == pages.Count - 1)
        {
            forwardButton.SetActive(false);
        }
    }

    public void RotateBack()
    {
        if (rotate == true) { return; }
        float angle = 0;
        pages[index].SetAsLastSibling();
        BackButtonActions();
        StartCoroutine(Rotate(angle, false));
    }

    public void BackButtonActions()
    {
        if (forwardButton.activeInHierarchy == false)
        {
            forwardButton.SetActive(true);
        }
        if (index - 1 == -1)
        {
            backButton.SetActive(false);
        }
    }

    IEnumerator Rotate(float angle, bool forward)
    {
        float value = 0f;
        while (true)
        {
            rotate = true;
            Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
            value += Time.deltaTime * pageSpeed;
            pages[index].rotation = Quaternion.Slerp(pages[index].rotation, targetRotation, value);
            float angle1 = Quaternion.Angle(pages[index].rotation, targetRotation);
            if (angle1 < 0.1f)
            {
                if (forward == false)
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
        if (AObject.activeSelf == false)
        {
            symbols[0].SetActive(true);
        }
        if (IObject.activeSelf == false)
        {
            symbols[1].SetActive(true);
        }
        if (UObject.activeSelf == false)
        {
            symbols[2].SetActive(true);
        }
        if (EObject.activeSelf == false)
        {
            symbols[3].SetActive(true);
        }
        if (OObject.activeSelf == false)
        {
            symbols[4].SetActive(true);
        }
        if (KaObject.activeSelf == false)
        {
            symbols[5].SetActive(true);
        }
        if (KiObject.activeSelf == false)
        {
            symbols[6].SetActive(true);
        }
        if (KuObject.activeSelf == false)
        {
            symbols[7].SetActive(true);
        }
        if (KeObject.activeSelf == false)
        {
            symbols[8].SetActive(true);
        }
        if (KoObject.activeSelf == false)
        {
            symbols[9].SetActive(true);
        }

        // When leaving the first page, the symbols are set to false
        // in order to not "bleed" unto the next page
        if (index != -1) {
            symbols[0].SetActive(false);
            symbols[1].SetActive(false);
            symbols[2].SetActive(false);
            symbols[3].SetActive(false);
            symbols[4].SetActive(false);
        } 
        // Similar logic for the second page
        if (index != 0) {
            symbols[5].SetActive(false);
            symbols[6].SetActive(false);
            symbols[7].SetActive(false);
            symbols[8].SetActive(false);
            symbols[9].SetActive(false);
        }

    }



}