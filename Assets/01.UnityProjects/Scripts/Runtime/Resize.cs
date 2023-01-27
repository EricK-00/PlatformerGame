using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localScale = new Vector3 (Screen.width / 100, Screen.height / 100, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}