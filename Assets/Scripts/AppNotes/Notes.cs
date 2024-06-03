using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notes : MonoBehaviour
{
    private List<string> titles = new(new string[] { "����¼", "���˹���trip", "��˾����ܽ���", "����", "�ͱ���һ������10����" });
    public List<Transform> transforms;
    public GameObject closeButton;
    public Text title;
    public ScrollRect scroll;
    private int currentIndex = 0;

    public void EnterNote(int index)
    {
        if (index != 0)
        {
            closeButton.SetActive(true);
        }
        title.text = titles[index];
        scroll.content = transforms[index].GetComponent<RectTransform>();
        transforms[currentIndex].gameObject.SetActive(false);
        transforms[index].gameObject.SetActive(true);
        currentIndex = index;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
