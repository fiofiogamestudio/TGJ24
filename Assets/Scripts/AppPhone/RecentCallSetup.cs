using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecentCallSetup : MonoBehaviour
{
    private List<string> phoneList = new(new string[] { "15107611461", "15107611461", "15107611461", "18876996339", "18876996339", "19205756919 ", "15107611461", "13034182394", "15046829005" });
    private List<string> timeList = new(new string[] { "2024年5月30日23:31", "2024年5月30日23:31", "2024年5月30日23:30", "2024年5月30日22:40", "2024年5月29日18:27", "一起放风筝", "一起追剧", "一起坐摩天轮，然后亲亲", "每年看一场音乐会【宫崎骏】", "一起放烟花", "一起通关一个游戏", "一起坐过山车", "一起拔智齿", "一起吃烧烤", "一起健身", "一起看雪堆雪人", "抱在一起看恐怖片", "一起拍vlog", "一起吵架", "一起做旋转木马", "一起做一本相册", "一起盯着对方看谁先笑", "一起睡觉", "一起看展", "一起吃麻小", "一起夜宵", "一起逛超市", "一起划船", "一起打羽毛球", "一起游泳", "一起在操场上散步", "一起看海边日落", "一起看海", "一起看日出", "一起打羽毛球", "一起看樱花", "一起穿情侣装", "一起吃寿司", "一起刷牙", "一起敷面膜" });
    
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
