using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObjController : MonoBehaviour
{
    public string objName;
    public int scrollingObjCount;

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

        float xPos = 0f;
        for (int i = 0; i < scrollingObjCount; i++)
        {
            xPos = (i - 1) * objSize.x;
            scrollingObjPool[i].SetLocalPos(xPos, 0f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
