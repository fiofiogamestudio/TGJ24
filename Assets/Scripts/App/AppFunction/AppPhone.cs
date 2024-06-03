using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AppPhone : AppBase
{
    public List<GameObject> gameObjects;
    public GameObject deleteButton;
    public GameObject numberArea;
    private int currentMode = 0;
    public Transform content;

    protected override void Awake()
    {
        base.Awake();
    }

    public void numPadButtonOnClick(string number)
    {
        if (number == "")
        {
            string text = numberArea.GetComponent<Text>().text;
            if (text == "")
            {
                return;
            }
            InsertHistory(text);
            numberArea.GetComponent<Text>().text = "";
            deleteButton.SetActive(false);
            return;
        }
        numberArea.GetComponent<Text>().text += number;
        deleteButton.SetActive(true);
    }

    private void InsertHistory(string number)
    {
        Transform obj = content.GetChild(0);
        Transform newObj = Instantiate(obj);
        newObj.SetParent(content);
        newObj.SetAsFirstSibling();
        newObj.GetChild(0).GetComponent<Text>().text = number;
        newObj.GetChild(0).GetComponent<Text>().color = Color.black;
        newObj.GetChild(1).GetComponent<Text>().text = "2024��6��3��10:00";
        //��ѯ���ڵ�ʱ�䲢���ø�newObj.GetChild(1).GetComponent<Text>().text
    }

    public void deleteButtonOnClick()
    {
        string text = numberArea.GetComponent<Text>().text;
        numberArea.GetComponent<Text>().text = text.Remove(text.Length - 1);
        if (text.Length == 1)
        {
            deleteButton.SetActive(false);
        }
    }

    public void switchMode(int mode)
    {
        if (mode == currentMode)
        {
            return;
        }
        gameObjects[currentMode].SetActive(false);
        gameObjects[mode].SetActive(true);
        currentMode = mode;
    }

    public bool hasRightDial = false;
    public void ClickDialButton()
    {
        string number = numberArea.GetComponent<Text>().text;
        if (number == "15107611461" || true)
        {
            if (!hasRightDial)
            {
                DialogUIManager.instance.ExecuteEffect("add_chat, Z, 4, 2005");
                DialogUIManager.instance.LoadDialog(3001);
                hasRightDial = true;
            }
            else
            {
                DialogUIManager.instance.LoadDialog(3011);
            }
        }
        else
        {
            DialogUIManager.instance.LoadDialog(3011);
        }
    }
}
