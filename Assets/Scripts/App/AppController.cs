using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AppBase))]
public class AppController : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        // 进行射线检测
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        var result = results[0];
        if (result.gameObject == gameObject)
        {
            // 处理点击事件
            this.GetComponent<AppBase>().Open();
            Debug.Log("Clicked on " + gameObject.name);
        }
    }
}
