using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiaryHandler : MonoBehaviour {
    public int pageNumber = 0;

    public TextAsset file;
    public string[] pages;
    public TMP_Text leftPage;
    public TMP_Text rightPage;
    public TMP_Text lNb;
    public TMP_Text rNb;
    public SpriteRenderer diarySprite;
    public Sprite diaryBase;
    public Sprite diaryNoRight;
    public Sprite diaryNoLeft;
    public GameObject arrowLeft;
    public GameObject arrowRight;
    public Animator diaryAnim;
    public Animator bgAnim;
    public GameObject diaryTable;
    
    public bool isDiaryOpen = false;

    private string[] separators = { "---\n", "---\r", "---\r\n" };

    void Start() {
        pages = file.text.Split(separators, StringSplitOptions.None);
        PageChange(0);
    }


    public void PageChange(int dir) {
        if (dir == 1 && pageNumber+2 <= pages.Length) pageNumber += 2;
        else if (dir == -1 && pageNumber-2 >= 0) pageNumber -= 2;
        if (pageNumber > 0 && pageNumber < pages.Length) {
            diarySprite.sprite = diaryBase;
            leftPage.text = pages[pageNumber-1].Substring(1,pages[pageNumber-1].Length-1);
            lNb.text = pageNumber.ToString();
            rightPage.text = pages[pageNumber].Substring(1,pages[pageNumber].Length-1);
            rNb.text = (pageNumber+1).ToString();
            arrowLeft.SetActive(true);
            arrowRight.SetActive(true);
        }
        else if (pageNumber == 0){
            diarySprite.sprite = diaryNoLeft;
            leftPage.text = "";
            lNb.text = "";
            rightPage.text = pages[pageNumber];
            rNb.text = (pageNumber+1).ToString();
            arrowLeft.SetActive(false);
        }
        else if (pageNumber == pages.Length) {
            diarySprite.sprite = diaryNoRight;
            leftPage.text = pages[pageNumber-1].Substring(1,pages[pageNumber-1].Length-1);
            lNb.text = pageNumber.ToString();
            arrowRight.SetActive(false);
            rightPage.text = "";
            rNb.text = "";
        }
    }
    
    public void OnButtonUp() {
        isDiaryOpen = true;
        diaryTable.SetActive(false);
        diaryAnim.SetBool("isOn", true);
        bgAnim.SetBool("isOn", true);
    }
    public void OnButtonDown() {
        isDiaryOpen = false;
        diaryTable.SetActive(true);
        diaryAnim.SetBool("isOn", false);
        bgAnim.SetBool("isOn", false);
    }
}
