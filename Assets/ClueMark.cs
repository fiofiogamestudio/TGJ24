using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClueMark : MonoBehaviour, IPointerClickHandler
{
    public int clueIndex = 0;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (GameManager.instance.interactMode == GameInteractMode.Clue)
        {
            triggerClue();
            eventData.Use(); // 不需要向上传递
        }
        // 不用射线检测，因为可能被子物体挡住

        // // 进行射线检测
        // List<RaycastResult> results = new List<RaycastResult>();
        // EventSystem.current.RaycastAll(eventData, results);

        // var result = results[0];
        // if (result.gameObject == gameObject)
        // {
        //     // 处理点击事件
        //     if (GameManager.instance.interactMode == GameInteractMode.Clue) triggerClue();
        // }
    }

    void triggerClue()
    {
        DialogUIManager.instance.LoadDialog(clueIndex);
    }
}
