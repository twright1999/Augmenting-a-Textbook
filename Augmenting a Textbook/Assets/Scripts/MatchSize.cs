using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchSize : MonoBehaviour
{
    public bool width;
    public bool height;
    public bool matchParent;
    public bool matchCanvas;

    private RectTransform sizeToMatch;
    private RectTransform canvasSize;
    // Start is called before the first frame update
    void Start()
    {
        if (matchParent)
        {
            sizeToMatch = gameObject.transform.parent.GetComponent<RectTransform>();
        }
        else if (matchCanvas)
        {
            sizeToMatch = GameObject.Find("Canvas").GetComponent<RectTransform>();
        }
        else
        {
            sizeToMatch = gameObject.GetComponent<RectTransform>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float w = gameObject.GetComponent<RectTransform>().sizeDelta.x;
        float h = gameObject.GetComponent<RectTransform>().sizeDelta.y;

        if (width)
        {
            w = sizeToMatch.sizeDelta.x;
        }
        if (height)
        {
            h = sizeToMatch.sizeDelta.y;
        }

        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(w,h);

    }
}
