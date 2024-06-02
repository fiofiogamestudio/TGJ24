using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppPhoneButton : MonoBehaviour
{
    public int mode;
    public AppPhone appPhone;

    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        Debug.Log(mode);
        appPhone.switchMode(mode);
    }
}
