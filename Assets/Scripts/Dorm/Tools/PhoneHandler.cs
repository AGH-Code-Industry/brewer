using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneHandler : MonoBehaviour
{
    public Animator phoneAnim;

    public void OnButtonUp() {
        phoneAnim.SetBool("isOn", true);
    }
    public void OnButtonDown() {
        phoneAnim.SetBool("isOn", false);
    }
}
