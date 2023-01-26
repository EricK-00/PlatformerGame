using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : GComponent
{
    private float width;

    protected override void Awake()
    {
        base.Awake();

        width = gameObject.GetRectSizeDelta().x;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (transform.localPosition.x <= -width)
        {
            Reposition();
        }
    }

    private void Reposition()
    {
        Vector3 offset = new Vector3(width * 2f, 0f, 0f);
        transform.localPosition = transform.localPosition + offset;
    }
}