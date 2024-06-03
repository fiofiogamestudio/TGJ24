using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppNote : AppBase
{
    public GameObject notes;
    public List<GameObject> gameObjects;
    public List<GameObject> usersAnswer;
    private List<string> correctAnswer = new (new string[] { "0513", "小小", "古湖区香园街道253号" });
    private int currentMode = 0;
    public GameObject incorrectInfo;

    public void checkAnswer()
    {
        for (int i = 0; i < correctAnswer.Count; i++)
        {
            if (usersAnswer[i].GetComponent<InputField>().text.Trim() != correctAnswer[i])
            {
                wrongInfo();
                return;
            }
        }
        gameObjects[currentMode].SetActive(false);
        notes.SetActive(true);
    }

    public void switchLogin(int mode)
    {
        if (mode == currentMode)
        {
            return;
        }
        gameObjects[currentMode].SetActive(false);
        gameObjects[mode].SetActive(true);
        currentMode = mode;
    }

    public void wrongInfo()
    {
        incorrectInfo.SetActive(true);
    }

    public void unlock()
    {
        notes.SetActive(true);
        foreach (GameObject gameObject in gameObjects)
        {
            gameObject.SetActive(false);
        }
    }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
        incorrectInfo.SetActive(false);
        for (int i = 0; i < gameObjects.Count; i++)
        {
            gameObjects[i].SetActive(false);
        }
        gameObjects[currentMode].SetActive(true);
    }
}
