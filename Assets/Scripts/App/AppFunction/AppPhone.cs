using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppPhone : AppBase
{
    public List<GameObject> gameObjects;
    public GameObject deleteButton;
    public GameObject numberArea;
    private int currentMode = 0;

    protected override void Awake()
    {
        base.Awake();
    }

    public void numPadButtonOnClick(string number)
    {
        if (number == "")
        {
            Debug.Log("call " + numberArea.GetComponent<Text>().text);
            numberArea.GetComponent<Text>().text = "";
            return;
        }
        numberArea.GetComponent<Text>().text += number;
        deleteButton.SetActive(true);
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
}
