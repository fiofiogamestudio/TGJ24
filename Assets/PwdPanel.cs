using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PwdPanel : MonoBehaviour
{
    public InputField inputField;
    public Button ConfirmButton;

    void Awake()
    {
        ConfirmButton.onClick.AddListener(()=>{
            if (inputField.text != "")
            {
                // 正确
                DialogUIManager.instance.LoadDialog(20082);
            }
            else
            {
                // 错误
                DialogUIManager.instance.LoadDialog(20081);
            }
            inputField.text = "";
            GameManager.instance.ClosePwdPanel();
        });
    }
}