using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Diary : MonoBehaviour {
    public Animator diaryAnim;
    public Animator bgAnim;
    public GameObject diary;
    public DiaryHandler diaryHandler;

    public void OnMouseDown() {
        if (this.gameObject.name == "DiaryTable") {
            diaryHandler.isDiaryOpen = true;
            diary.SetActive(false);
            diaryAnim.SetBool("isOn", true);
            bgAnim.SetBool("isOn", true);
        }
        else if (this.gameObject.name == "Back") {
            diaryHandler.isDiaryOpen = false;
            diary.SetActive(true);
            diaryAnim.SetBool("isOn", false);
            bgAnim.SetBool("isOn", false);
        }
    }
}
