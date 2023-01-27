using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScrollingBgController : ScrollingObjController
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }       //Start

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }       //Update

    protected override void InitObjsPosition()
    {
        float xPos = objSize.x * (scrollingObjCount - 1) * -1 * 0.5f;
        for (int i = 0; i < scrollingObjCount; i++)
        {
            scrollingObjPool[i].SetLocalPos(xPos, 0f, 0f);
            xPos += objSize.x;
        }
    }       //InitObjsPosition

    protected override void RepositionObj()
    {
        float lastObjCurrentXPos = scrollingObjPool[scrollingObjCount - 1].transform.localPosition.x;
        if (lastObjCurrentXPos <= objSize.x * 0.5f)
        {
            float lastObjInitXPos = Mathf.Floor(scrollingObjCount * 0.5f) * objSize.x + (objSize.x * 0.45f);
            scrollingObjPool[0].SetLocalPos(lastObjInitXPos, 0f, 0f);
            scrollingObjPool.Add(scrollingObjPool[0]);
            scrollingObjPool.RemoveAt(0);
        }
    }       //RepositionObj
}
