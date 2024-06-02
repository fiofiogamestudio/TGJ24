using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppShoppingOrder : MonoBehaviour
{
    String shop;
    String good;
    String price;
    String address;

    [SerializeField]
    Text ShopText;
    [SerializeField]
    Text GoodText;
    [SerializeField]
    Text PriceText;
    [SerializeField]
    Text AddressText;

    public void SetData(String shop, String good, String price, String address)
    {
        this.shop = shop;
        this.good = good;
        this.price = price;
        this.address = address;

        ShopText.text = shop;
        GoodText.text = good;
        PriceText.text = "￥" + price;
        AddressText.text = address;
    }
}
