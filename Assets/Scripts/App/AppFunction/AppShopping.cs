using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppShopping : AppBase
{
    [SerializeField]
    List<String> shops;
    [SerializeField]
    List<String> goods;
    [SerializeField]
    List<String> prices;
    [SerializeField]
    List<String> addresses;

    [SerializeField]
    GameObject orderPrefab;
    [SerializeField]
    GameObject prefabHolder;

    void Start()
    {
        for (int i = 0; i < shops.Count; i++)
        {
            // 生成一个订单
            GameObject order = Instantiate(orderPrefab, prefabHolder.transform);
            AppShoppingOrder orderScript = order.GetComponent<AppShoppingOrder>();
            orderScript.SetData(shops[i], goods[i], prices[i], addresses[i]);
        }
    }
}
