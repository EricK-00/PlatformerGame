using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObjController : MonoBehaviour
{
    public string objName;
    public int scrollingObjCount;
    public float scrollingSpeed = 100;

    protected GameObject obj;
    protected Vector2 objSize;
    protected List<GameObject> scrollingObjPool = new List<GameObject>();

    // Start is called before the first frame update
    public virtual void Start()
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

        InitObjsPosition();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (scrollingObjPool == null || scrollingObjPool.Count <= 0)
        {
            return;
        }

        if (!GameManager.instance.isGameOver)
        {
            //오브젝트 이동
            for (int i = 0; i < scrollingObjCount; i++)
            {
                scrollingObjPool[i].AddLocalPos(scrollingSpeed * Time.deltaTime * -1f, 0f, 0f);
            }

            RepositionObj();
        }
    }

    protected virtual void InitObjsPosition()
    {
        //오브젝트 위치 초기화
        /* Do something */
    }

    protected virtual void RepositionObj()
    {
        //오브젝트 위치 재지정
        /* Do something */
    }
}