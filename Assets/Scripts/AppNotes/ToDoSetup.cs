using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToDoSetup : MonoBehaviour
{
    //private List<string> todoList = new(new string[] { "һ�𿴼���", "һ���������", "һ��ſ�����", "һ��ȥ��ɽ��ѩɽ��", "һ��ȥ��ʿ��", "һ��¶Ӫ��������", "һ��Ǳˮ", "һ��������", "һ��ȥ����Ժ���幤", "һ��ѩ", "һ����д��", "һ��ͨ��", "һ����������", "һ��������", "һ���ݽ�", "һ���ֲ�ݮ", "һ��������", "һ�����糵", "һ���Ǯ", "һ������", "һ��ȥ����ӰԺ", "ÿ��һ����Ը", "һ������Ȫ", "һ��ȥ����԰", "һ��ktv", "һ���������߹��ĵط�", "һ��ϴ��", "���������ĳ�", "һ��ѧһ������", "һ�𿴺���", "һ��ȥ�����Ұ", "һ����", "һ��μ����", "һ��ļ�", "����ʱ�չ˶Է�", "���Է����·�����˭�ĺÿ���", "һ��Ϊ�Է���ױ", "һ���������", "һ����һ����", "һ����Զ��һ��", "һ����Ƶһ����", "һ���ĸУ" });
    //private List<string> doneList = new(new string[] { "�����ﶬ��ͬһ���ط�����", "һ���һ������", "��ͷ����ͷ��", "һ��ȥè��", "һ��ƴƴͼ", "һ��ŷ���", "һ��׷��", "һ����Ħ���֣�Ȼ������", "ÿ�꿴һ�����ֻ᡾���鿥��", "һ����̻�", "һ��ͨ��һ����Ϸ", "һ������ɽ��", "һ����ǳ�", "һ����տ�", "һ����", "һ��ѩ��ѩ��", "����һ�𿴿ֲ�Ƭ", "һ����vlog", "һ�𳳼�", "һ������תľ��", "һ����һ�����", "һ���ŶԷ���˭��Ц", "һ��˯��", "һ��չ", "һ�����С", "һ��ҹ��", "һ��䳬��", "һ�𻮴�", "һ�����ë��", "һ����Ӿ", "һ���ڲٳ���ɢ��", "һ�𿴺�������", "һ�𿴺�", "һ���ճ�", "һ�����ë��", "һ��ӣ��", "һ������װ", "һ�����˾", "һ��ˢ��", "һ�����Ĥ" });
    private List<string> todoList = new(new string[] { "һ�𿴼���", "һ���������", "һ��ſ�����", "һ��ȥ��ɽ��ѩɽ��", "һ��ȥ��ʿ��" });
    private List<string> doneList = new(new string[] { "�����ﶬ��ͬһ���ط�����", "һ���һ������", "��ͷ����ͷ��", "һ��ȥè��", "һ��ƴƴͼ" });

    // Start is called before the first frame update
    void Start()
    {
        Transform todo = transform.GetChild(0);
        Transform done = transform.GetChild(1);
        foreach (string thing in todoList)
        {
            Transform newTodo = Instantiate(todo);
            newTodo.SetParent(transform);
            newTodo.GetComponentInChildren<Text>().text = thing;
            newTodo.localScale = new Vector3(1, 1, 1);
        }
        foreach (string thing in doneList)
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
