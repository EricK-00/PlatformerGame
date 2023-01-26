using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoSizeBoxCollider2D : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D boxCollider = gameObject.GetComponentMust<BoxCollider2D>();
        RectTransform rectTransform = gameObject.GetComponentMust<RectTransform>();

        boxCollider.size = rectTransform.sizeDelta;
    }
}