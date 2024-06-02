using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppShopping : AppBase
{
    protected override void Awake()
    {
        base.Awake();
    }

    [SerializeField]
    List<String> shops;
    [SerializeField]
    List<String> goods;
    [SerializeField]
    List<String> prices;
    [SerializeField]
    List<String> addresses;
    [SerializeField]
    List<Sprite> goodIcons;

    [SerializeField]
    GameObject orderPrefab;
    [SerializeField]
    GameObject prefabHolder;

    [SerializeField]
    RectTransform scrollView;

    void Start()
    {
        for (int i = 0; i < shops.Count; i++)
        {
            // 生成一个订单
            GameObject order = Instantiate(orderPrefab, prefabHolder.transform);
            AppShoppingOrder orderScript = order.GetComponent<AppShoppingOrder>();
            orderScript.SetData(shops[i], goods[i], prices[i], addresses[i], goodIcons[i]);
        }

        // 计算scrollView的高度
        float height = shops.Count * 180 + shops.Count * 2 - 2;
        scrollView.sizeDelta = new Vector2(scrollView.sizeDelta.x, height);
    }
}
