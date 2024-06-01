using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.UI;

public class MobileManager : MonoBehaviour
{
    public static MobileManager instance;
    public Text HeaderTime;
    public Text Header5G;
    void Awake()
    {
        if (instance == null) instance = this;
    }

    public void OnOpenApp()
    {
        HeaderTime.color = Color.black;
        Header5G.color = Color.black;
    }

    public void OnCloseApp()
    {
        HeaderTime.color = Color.white;
        Header5G.color = Color.white;
    }
}
