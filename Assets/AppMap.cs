using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppMap : AppBase
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }

    public override void Open()
    {
        if (GameManager.instance.successUnlock)
        {
            DialogUIManager.instance.LoadDialog(5001);
        }
        else
        {
            DialogUIManager.instance.LoadDialog(5002);
        }
    }
}
