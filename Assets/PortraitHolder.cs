using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitHolder : MonoBehaviour
{
    public static PortraitHolder instance;
    void Awake()
    {
        if (instance == null) instance = this;
    }

    public List<PortraitMapping> portraitMappingList = new List<PortraitMapping>();

    public Sprite defaultPortrait;

    public Sprite GetPortrait(string name)
    {
        foreach (var mapping in portraitMappingList)
        {
            if (mapping.name == name) return mapping.pic;
        }
        return defaultPortrait;
    }
}

[System.Serializable]
public class PortraitMapping
{
    public string name;
    public Sprite pic;
}
