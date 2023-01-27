using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingPlatformController : ScrollingObjController
{
    private bool isStart = true;

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
        Vector2 posOffset = Vector2.zero;

        float xPos = objSize.x * (scrollingObjCount - 1) * -1 * 0.5f;
        float yPos = defaultYPos;

        for (int i = 0; i < scrollingObjCount; i++)
        {
            scrollingObjPool[i].SetLocalPos(xPos, yPos, 0f);

            posOffset = GetRandomPosOffset();
            if (isStart)
            {
                xPos = xPos + objSize.x;
                isStart = false;
            }
            else
            {
                xPos = xPos + objSize.x + posOffset.x;
            }
            yPos = defaultYPos + posOffset.y;
        }
    }       //InitObjsPosition

    protected override void RepositionObj()
    {
        float lastObjCurrentXPos = scrollingObjPool[scrollingObjCount - 1].transform.localPosition.x;
        if (lastObjCurrentXPos <= objSize.x * 0.5f)
        {
            float lastObjInitXPos = Mathf.Floor(scrollingObjCount * 0.5f) * objSize.x + (objSize.x * 0.5f);
            Vector2 posOffset = GetRandomPosOffset();
            
            scrollingObjPool[0].SetLocalPos(lastObjInitXPos + posOffset.x, defaultYPos + posOffset.y, 0f);
            scrollingObjPool.Add(scrollingObjPool[0]);
            scrollingObjPool.RemoveAt(0);
        }
    }

    private Vector2 GetRandomPosOffset()
    {
        Vector2 offset = new Vector2(Random.Range(50f, 300f), Random.Range(-50f, 30f));
        return offset;
    }
}
