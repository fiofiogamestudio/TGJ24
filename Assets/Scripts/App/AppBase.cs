using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppBase : MonoBehaviour
{
    public GameObject ScreenObject;
    protected virtual void Awake()
    {
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        // 测试
        // if (Input.GetKeyDown(KeyCode.W)) Close();
    }
    
    
    [ReadOnly]
    public bool isOpening = false;
    [ReadOnly]
    public bool hasOpened = false; 
    public Vector3 CenterPos = new Vector3(960, 540);
    
    public virtual void Open() 
    {
        if (isOpening) return;
        if (hasOpened) return;
        hasOpened = true;
        ScreenObject.SetActive(true);
        StartCoroutine(IEOpenOrClose(0.1f, 1.0f, transform.position, CenterPos));
        // Change Header Text Color
        MobileManager.instance.OnOpenApp();
    }

    IEnumerator IEOpenOrClose(float startScale, float endScale, Vector3 startPos, Vector3 targetPos, System.Action endAction = null, float openTime = 0.15f)
    {
        isOpening = true;
        
        ScreenObject.transform.localScale = Vector3.one * startScale;
        ScreenObject.transform.position = startPos;
        for (float time = 0; time < openTime; time += 0.02f)
        {
            float t = time / openTime;
            
            ScreenObject.transform.localScale = Vector3.one * Mathf.Lerp(startScale, endScale, t);
        ScreenObject.transform.position = Vector3.Lerp(startPos, targetPos, t);
            yield return new WaitForSeconds(0.02f);
        }

        ScreenObject.transform.localScale = Vector3.one * endScale;
        ScreenObject.transform.position = targetPos;

        isOpening = false;
        if (endAction != null) endAction();
    }

    

    public virtual void Close()
    {
        if (isOpening) return;
        if (!hasOpened) return;
        hasOpened = false;
        StartCoroutine(IEOpenOrClose(1.0f, 0.1f, CenterPos, transform.position, ()=>{
            ScreenObject.SetActive(false);
        }));

        // Change Header Text Color
        MobileManager.instance.OnCloseApp();
    }
}
