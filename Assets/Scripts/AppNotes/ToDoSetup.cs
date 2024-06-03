using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToDoSetup : MonoBehaviour
{
    //private List<string> todoList = new(new string[] { "一起看极光", "一起买菜做饭", "一起放孔明灯", "一起去爬山【雪山】", "一起去迪士尼", "一起露营，搭帐篷", "一起潜水", "一起养宠物", "一起去福利院做义工", "一起滑雪", "一起拍写真", "一起通宵", "一起做热气球", "一起做饼干", "一起泡脚", "一起种草莓", "一起玩密室", "一起坐电车", "一起存钱", "一起生火", "一起去情侣影院", "每年一起许愿", "一起泡温泉", "一起去动物园", "一起唱ktv", "一起走我们走过的地方", "一起洗碗", "坐宝宝开的车", "一起学一个乐器", "一起看海豚", "一起去乡间田野", "一起理发", "一起参加舞会", "一起蹦极", "生病时照顾对方", "给对方挑衣服【比谁的好看】", "一起为对方化妆", "一起吃烛光晚餐", "一起种一棵树", "一起永远在一起", "一起视频一整天", "一起回母校" });
    //private List<string> doneList = new(new string[] { "春夏秋冬在同一个地方拍照", "一起逛一个城市", "吹头发吹头发", "一起去猫咖", "一起拼拼图", "一起放风筝", "一起追剧", "一起坐摩天轮，然后亲亲", "每年看一场音乐会【宫崎骏】", "一起放烟花", "一起通关一个游戏", "一起坐过山车", "一起拔智齿", "一起吃烧烤", "一起健身", "一起看雪堆雪人", "抱在一起看恐怖片", "一起拍vlog", "一起吵架", "一起做旋转木马", "一起做一本相册", "一起盯着对方看谁先笑", "一起睡觉", "一起看展", "一起吃麻小", "一起夜宵", "一起逛超市", "一起划船", "一起打羽毛球", "一起游泳", "一起在操场上散步", "一起看海边日落", "一起看海", "一起看日出", "一起打羽毛球", "一起看樱花", "一起穿情侣装", "一起吃寿司", "一起刷牙", "一起敷面膜" });
    private List<string> todoList = new(new string[] { "一起看极光", "一起买菜做饭", "一起放孔明灯", "一起去爬山【雪山】", "一起去迪士尼" });
    private List<string> doneList = new(new string[] { "春夏秋冬在同一个地方拍照", "一起逛一个城市", "吹头发吹头发", "一起去猫咖", "一起拼拼图" });

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
