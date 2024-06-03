using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Awake()
    {
        if (instance == null) instance = this;
    }



    public GameInteractMode interactMode = GameInteractMode.Interact;


    public GameObject PwdPanel;

    public void OpenPwdPanel()
    {
        PwdPanel.gameObject.SetActive(true);
    }

    public void ClosePwdPanel()
    {
        PwdPanel.gameObject.SetActive(false);
    }
    
}

public enum GameInteractMode
{
    Interact,  // 交互模式
    Clue // 线索模式
}
