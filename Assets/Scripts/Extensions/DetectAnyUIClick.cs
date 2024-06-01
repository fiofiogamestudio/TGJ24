using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

public class DetectAnyUIClick : MonoBehaviour
{
    // 更新函数中检查鼠标点击
    void Update()
    {
        // 检查鼠标左键是否被点击
        if (Input.GetMouseButtonDown(0))
        {
            // 检测当前鼠标是否点击在UI元素上
            if (EventSystem.current.IsPointerOverGameObject())
            {
                PointerEventData pointerData = new PointerEventData(EventSystem.current)
                {
                    position = Input.mousePosition // 设置当前鼠标位置
                };

                // 列表用于收集鼠标指针下的所有UI元素
                List<RaycastResult> results = new List<RaycastResult>();
                EventSystem.current.RaycastAll(pointerData, results);

                Debug.Log("Start ------------------------------");
                // 输出所有被点击的UI元素名称
                foreach (RaycastResult result in results)
                {
                    Debug.Log("Clicked on UI: " + GetGameObjectPath(result.gameObject));
                }
            }
            else
            {
                Debug.Log("Clicked on non-UI element");
            }
        }
    }

    // 构造GameObject层级路径的函数
    private string GetGameObjectPath(GameObject obj)
    {
        StringBuilder path = new StringBuilder(obj.name);
        while (obj.transform.parent != null)
        {
            obj = obj.transform.parent.gameObject;
            path.Insert(0, obj.name + "/");
        }
        return path.ToString();
    }
}
