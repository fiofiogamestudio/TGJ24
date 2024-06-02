using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumPadButton : MonoBehaviour
{
    public AppPhone appPhone;
    private string number;

    public void Start()
    {
        number = GetComponentInChildren<Text>().text;
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        Debug.Log(111);
        appPhone.numPadButtonOnClick(number);
    }
}
