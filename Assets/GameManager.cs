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

    [Header("END")]
    
    public List<GameObject> EndPanelList = new List<GameObject>();

    [ReadOnly]
    public bool endGame = false;
    [ReadOnly]
    public bool successUnlock = false;

    public void EndGame(int index)
    {
        if (!endGame)
        {
            endGame = true;
            StartCoroutine(IEEndGame(index));
        }
    } 

    IEnumerator IEEndGame(int index)
    {
        yield return new WaitForSeconds(1.0f);
        EndPanelList[index].gameObject.SetActive(true);
    }
    
}

public enum GameInteractMode
{
    Interact,  // 交互模式
    Clue // 线索模式
}
