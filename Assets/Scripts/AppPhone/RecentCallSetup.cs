using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecentCallSetup : MonoBehaviour
{
    private List<string> phoneList = new(new string[] { "15107611461", "15107611461", "15107611461", "18876996339", "18876996339", "19205756919 ", "15107611461", "13034182394", "15046829005" });
    private List<string> timeList = new(new string[] { "2024��5��30��23:31", "2024��5��30��23:31", "2024��5��30��23:30", "2024��5��30��22:40", "2024��5��29��18:27", "һ��ŷ���", "һ��׷��", "һ����Ħ���֣�Ȼ������", "ÿ�꿴һ�����ֻ᡾���鿥��", "һ����̻�", "һ��ͨ��һ����Ϸ", "һ������ɽ��", "һ����ǳ�", "һ����տ�", "һ����", "һ��ѩ��ѩ��", "����һ�𿴿ֲ�Ƭ", "һ����vlog", "һ�𳳼�", "һ������תľ��", "һ����һ�����", "һ���ŶԷ���˭��Ц", "һ��˯��", "һ��չ", "һ�����С", "һ��ҹ��", "һ��䳬��", "һ�𻮴�", "һ�����ë��", "һ����Ӿ", "һ���ڲٳ���ɢ��", "һ�𿴺�������", "һ�𿴺�", "һ���ճ�", "һ�����ë��", "һ��ӣ��", "һ������װ", "һ�����˾", "һ��ˢ��", "һ�����Ĥ" });
    
    // Start is called before the first frame update
    void Start()
    {
        Transform todo = transform.GetChild(0);
        Transform done = transform.GetChild(1);
        foreach (string thing in phoneList)
        {
            Transform newTodo = Instantiate(todo);
            newTodo.SetParent(transform);
            newTodo.GetComponentInChildren<Text>().text = thing;
            newTodo.localScale = new Vector3(1, 1, 1);
        }
        foreach (string thing in timeList)
        {
            Transform newDone = Instantiate(done);
            newDone.SetParent(transform);
            newDone.GetComponentInChildren<Text>().text = thing;
            newDone.localScale = new Vector3(1, 1, 1);
        }
        todo.gameObject.SetActive(false);
        done.gameObject.SetActive(false);
    }
}
