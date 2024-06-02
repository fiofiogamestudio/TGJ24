using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppShoppingOrder : MonoBehaviour
{
    [SerializeField]
    Text ShopText;
    [SerializeField]
    Text GoodText;
    [SerializeField]
    Text PriceText;
    [SerializeField]
    Text AddressText;
    [SerializeField]
    Image IconImage;

    public void SetData(String shop, String good, String price, String address, Sprite icon)
    {
        ShopText.text = shop;
        GoodText.text = good;
        PriceText.text = "￥" + price;
        AddressText.text = address;
        IconImage.sprite = icon;
    }
}
