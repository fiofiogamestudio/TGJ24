using System.Collections;
using System.Collections.Generic;
using System.Security;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MobileManager : MonoBehaviour
{
    public static MobileManager instance;
    [Header("Header Group")]
    public Text HeaderTime;
    public Text Header5G;
    [Header("App Layout")]
    public Transform AppLayout;
    void Awake()
    {
        if (instance == null) instance = this;
    }

    public void OnOpenApp()
    {
        HeaderTime.color = Color.black;
        Header5G.color = Color.black;
        setAppIconVisibilityAndInteractivity(false);
    }

    public void OnCloseApp()
    {
        HeaderTime.color = Color.white;
        Header5G.color = Color.white;
        setAppIconVisibilityAndInteractivity(true);
    }

    void setAppIconVisibilityAndInteractivity(bool flag)
    {
        int count = AppLayout.childCount;
        for (int i = 0; i < count; i++)
        {
            var child = AppLayout.GetChild(i);
            var image = child.GetComponent<Image>();
            var color = image.color;
            var targetColor = new Color(color.r, color.g, color.b, flag ? 1 : 0);
            image.color = targetColor;

            var appController = child.GetComponent<AppController>();
            appController.enabled = flag;
        }
    }

    
}
