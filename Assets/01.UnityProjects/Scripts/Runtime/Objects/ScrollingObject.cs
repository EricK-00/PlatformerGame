using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float scrollingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * scrollingSpeed * Time.deltaTime);
    }
}