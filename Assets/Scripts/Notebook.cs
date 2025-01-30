using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class book : MonoBehaviour
{
    [SerializeField] float pageSpeed = 1.7f;
    [SerializeField] List<Transform> pages;
    public int index = -1;
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
    [SerializeField] GameObject RoObject;


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

    [SerializeField] GameObject FirstNote;
    [SerializeField] GameObject SecondNote;
    [SerializeField] GameObject ThirdNote;
    [SerializeField] GameObject FourthNote;
    [SerializeField] GameObject FifthNote;
    [SerializeField] GameObject SixthNote;

    private void Start()
    {
        InitialState();
        
    }

    public void InitialState()
    {
        // sets all of the page rotations to 0
        for (int i=0; i<pages.Count; i++)
        {
            pages[i].transform.rotation=Quaternion.identity;
        }

        // sets all of the first 10 symbols to false since the player hasn't really taken any symbols yet for them to show up in the notebook
        for(int i = 0; i <= 24; i++)
        {
            symbols[i].SetActive(false);
        }
        // this just keeps the notebook on the same page that the player left it on
        if(index > -1) {
            pages[index].SetAsLastSibling();
        } else {
            pages[0].SetAsLastSibling();
        }
        
        // setting the back button to inactive since there's no page before page 1
        backButton.SetActive(false);

    }

    public void RotateForward()
    {
        // checks if page is rotating, makes sure to not do anything when page is rotating to avoid bugs
        if (rotate == true) { return; }
        // if the page is currently not rotating, it will increment the index by 1 and by doing this it will go to the next page
        index++;
        // reorients the current page and flips it by 180 degrees in order to show that the page has flipped
        float angle = 180;
        ForwardButtonActions();
        // we remind the program to stay on this page after closing it
        pages[index].SetAsLastSibling();
        // actually rotates the page and sends a boolean value
        StartCoroutine(Rotate(angle, true));
    }

    public void ForwardButtonActions()
    {
        // this just activates the back button when we are not on page 1
        if (backButton.activeInHierarchy == false)
        {
            backButton.SetActive(true);
        }
        // if we are on the last page, it will deactivate the forward button
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
        if (RoObject.activeSelf == false)
        {
            symbols[15].SetActive(true);
        }
        if (SaObject.activeSelf == false)
        {
            symbols[16].SetActive(true);
        }
        if (ShiObject.activeSelf == false)
        {
            symbols[17].SetActive(true);
        }
        if (SuObject.activeSelf == false)
        {
            symbols[18].SetActive(true);
        }
        if (SeObject.activeSelf == false)
        {
            symbols[19].SetActive(true);
        }
        if (SoObject.activeSelf == false)
        {
            symbols[20].SetActive(true);
        }
        if (NaObject.activeSelf == false)
        {
            symbols[21].SetActive(true);
        }
        if (NeObject.activeSelf == false)
        {
            symbols[22].SetActive(true);
        }
        if (NiObject.activeSelf == false)
        {
            symbols[23].SetActive(true);
        }
        if (NuObject.activeSelf == false)
        {
            symbols[24].SetActive(true);
        }
        if (NoObject.activeSelf == false)
        {
            symbols[25].SetActive(true);
        }
        if (NObject.activeSelf == false)
        {
            symbols[26].SetActive(true);
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
            for (int i = 16; i<21; i++) {
                symbols[i].SetActive(false);
            }
        }

        if (index != 2) {
            for (int i = 10; i<16; i++) {
                symbols[i].SetActive(false);
            }
        }

        if (index != 3) {
            for (int i = 21; i<27; i++) {
                symbols[i].SetActive(false);
            }
        }

        if (index != 4) {
            FirstNote.SetActive(false);
        }

        if (index != 5) {
            SecondNote.SetActive(false);
        }

        if (index != 6) {
            ThirdNote.SetActive(false);
        }

        if (index != 7) {
            FourthNote.SetActive(false);
        }

        if (index != 8) {
            FifthNote.SetActive(false);
        }

        if (index != 9) {
            SixthNote.SetActive(false);
        }

    }





}