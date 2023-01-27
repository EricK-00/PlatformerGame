using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObjController : MonoBehaviour
{
    public string objName;
    public int scrollingObjCount;

    private const float SCROLLING_SPEED = 500;
    private GameObject obj;
    private Vector2 objSize;
    private List<GameObject> scrollingObjPool = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject.FindChildGameObject(objName);
        objSize = obj.GetRectSizeDelta();

        Functions.Assert(obj != null);
        if (scrollingObjPool.Count <= 0)
        {
            for (int i = 0; i < scrollingObjCount; i++)
            {
                GameObject go = Instantiate(obj,
                    obj.transform.position,
                    obj.transform.rotation, transform);

                scrollingObjPool.Add(go);
            }
        }

        obj.SetActive(false);

        //오브젝트 위치 초기화
        //float xPos = 0f;
        float xPos = objSize.x * (scrollingObjCount - 1) * -1 * 0.5f;
        for (int i = 0; i < scrollingObjCount; i++)
        {
            //xPos = (i - 1) * objSize.x;
            scrollingObjPool[i].SetLocalPos(xPos, 0f, 0f);
            xPos += objSize.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (scrollingObjPool == null || scrollingObjPool.Count <= 0)
        {
            return;
        }

        for (int i = 0; i < scrollingObjCount; i++)
        {
            scrollingObjPool[i].AddLocalPos(SCROLLING_SPEED * Time.deltaTime * -1f, 0f, 0f);
        }

        float lastObjCurrentXPos =
            scrollingObjPool[scrollingObjCount - 1].transform.localPosition.x;
        if (lastObjCurrentXPos <= objSize.x * 0.5f)
        {
            float lastObjInitXPos = Mathf.Floor(scrollingObjCount * 0.5f) * objSize.x + (objSize.x * 0.45f);
            scrollingObjPool[0].SetLocalPos(lastObjInitXPos, 0f, 0f);
            scrollingObjPool.Add(scrollingObjPool[0]);
            scrollingObjPool.RemoveAt(0);
        }
    }
}