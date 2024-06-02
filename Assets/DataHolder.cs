using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder : MonoBehaviour
{
    public static DataHolder instance;
    void Awake() 
    {
        if (instance == null) instance = this;
        loadData();
    }



    void loadData()
    {
        var wrapper = DataLoader.LoadJson<GameDataWrapper>(PathConfig.GAME_DATA_PATH);

        // 加载初始信息
        initMessageList.Clear();
        initMessageList.AddRange(wrapper.initMessages);
    }

    [ReadOnly]
    public List<int> initMessageList = new List<int>();


}

[System.Serializable]
public class GameDataWrapper
{
    public int[] initMessages;
}


