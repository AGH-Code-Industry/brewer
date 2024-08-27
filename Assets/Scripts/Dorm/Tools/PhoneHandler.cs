using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class PhoneHandler : MonoBehaviour
{
    public Animator phoneAnim;
    public Animator appsAnim;
    public Animator tasksAnim;
    public Animator ordersAnim;
    public Animator bgAnim;
    public Image bg;
    private Color color;

    public void OnButtonUp() {
        phoneAnim.SetBool("isOn", true);
    }
    public void OnButtonDown() {
        phoneAnim.SetBool("isOn", false);
    }
    public void OnAppsUp() {
        appsAnim.SetBool("appsOn", true);
    }
    public void OnAppsDown() {
        appsAnim.SetBool("appsOn", false);
    }
    public void OnTasksUp() {
        tasksAnim.SetBool("tasksOn", true);
        ColorUtility.TryParseHtmlString("#499478", out color);
        bg.color = color;
        bgAnim.SetBool("bgOn", true);
    }
    public void OnTasksDown() {
        tasksAnim.SetBool("tasksOn", false);
        bgAnim.SetBool("bgOn", false);
    }
    public void OnOrdersUp() {
        ordersAnim.SetBool("ordersOn", true);
        ColorUtility.TryParseHtmlString("#5A569E", out color);
        bg.color = color;
        bgAnim.SetBool("bgOn", true);
    }
    public void OnOrdersDown() {
        ordersAnim.SetBool("ordersOn", false);
        bgAnim.SetBool("bgOn", false);
    }
}
