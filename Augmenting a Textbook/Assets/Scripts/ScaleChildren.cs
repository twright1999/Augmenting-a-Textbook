using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleChildren : MonoBehaviour
{
    public bool width;
    public bool height;
    public float widthScale;
    public float heightScale;

    // Update is called once per frame
    void Update()
    {
        float widthOfPanel = gameObject.GetComponent<RectTransform>().sizeDelta.x;
        float heightOfPanel = gameObject.GetComponent<RectTransform>().sizeDelta.y;

        foreach (Transform child in gameObject.transform)
        {
            float w = child.GetComponent<RectTransform>().sizeDelta.x;
            float h = child.GetComponent<RectTransform>().sizeDelta.y;

            if (width)
            {
                w = widthOfPanel / widthScale;
            }

            if (height)
            {
                h = heightOfPanel / heightScale;
            }

            child.GetComponent<RectTransform>().sizeDelta = new Vector2(w,h);
        }
    }
}
