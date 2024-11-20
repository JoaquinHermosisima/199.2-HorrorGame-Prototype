using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    [SerializeField] GameObject TaObject;
    [SerializeField] GameObject ChiObject;
    [SerializeField] GameObject TsuObject;
    [SerializeField] GameObject TeObject;
    [SerializeField] GameObject ToObject;


    [SerializeField] GameObject SaObject;
    [SerializeField] GameObject ShiObject;
    [SerializeField] GameObject SuObject;
    [SerializeField] GameObject SeObject;
    [SerializeField] GameObject SoObject;


    [SerializeField] GameObject NaObject;
    [SerializeField] GameObject NeObject;
    [SerializeField] GameObject NiObject;
    [SerializeField] GameObject NuObject;
    [SerializeField] GameObject NoObject;
    [SerializeField] GameObject NObject;

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
        if(index > -1) {
            pages[index].SetAsLastSibling();
        } else {
            pages[0].SetAsLastSibling();
        }
        
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
        if (TaObject.activeSelf == false)
        {
            symbols[10].SetActive(true);
        }
        if (ChiObject.activeSelf == false)
        {
            symbols[11].SetActive(true);
        }
        if (TsuObject.activeSelf == false)
        {
            symbols[12].SetActive(true);
        }
        if (TeObject.activeSelf == false)
        {
            symbols[13].SetActive(true);
        }
        if (ToObject.activeSelf == false)
        {
            symbols[14].SetActive(true);
        }
        if (SaObject.activeSelf == false)
        {
            symbols[15].SetActive(true);
        }
        if (ShiObject.activeSelf == false)
        {
            symbols[16].SetActive(true);
        }
        if (SuObject.activeSelf == false)
        {
            symbols[17].SetActive(true);
        }
        if (SeObject.activeSelf == false)
        {
            symbols[18].SetActive(true);
        }
        if (SoObject.activeSelf == false)
        {
            symbols[19].SetActive(true);
        }
        if (NaObject.activeSelf == false)
        {
            symbols[20].SetActive(true);
        }
        if (NeObject.activeSelf == false)
        {
            symbols[21].SetActive(true);
        }
        if (NiObject.activeSelf == false)
        {
            symbols[22].SetActive(true);
        }
        if (NuObject.activeSelf == false)
        {
            symbols[23].SetActive(true);
        }
        if (NoObject.activeSelf == false)
        {
            symbols[24].SetActive(true);
        }
        if (NObject.activeSelf == false)
        {
            symbols[25].SetActive(true);
        }
 
        if (index != -1) {
            for (int i = 0; i<5; i++) {
                symbols[i].SetActive(false);
            }
        }
        if (index != 0) {
            for (int i = 5; i<10; i++) {
                symbols[i].SetActive(false);
            }
        }

        if (index != 1) {
            for (int i = 15; i<20; i++) {
                symbols[i].SetActive(false);
            }
        }

        if (index != 2) {
            for (int i = 10; i<15; i++) {
                symbols[i].SetActive(false);
            }
        }

        if (index != 3) {
            for (int i = 20; i<26; i++) {
                symbols[i].SetActive(false);
            }
        }
    }





}