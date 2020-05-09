using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollManager : MonoBehaviour
{
    private RectTransform toolPanel;
    private GameObject toggleToolPanel;
    private RectTransform toggleToolPanelDefault;

    private bool done = false;
    private GameObject scrollbar;
    private float canvasHeight;

    void Update()
    {
        if (GameObject.Find("ToolPanel") != null && !done)
        {
            toolPanel = GameObject.Find("ToolPanel").GetComponent<RectTransform>();
            toggleToolPanel = GameObject.Find("ToggleToolPanel");
            toggleToolPanelDefault = GameObject.Find("ToggleToolPanelDefault").GetComponent<RectTransform>();

            scrollbar = GameObject.Find("Scrollbar");
            done = true;
        }
        canvasHeight = GameObject.Find("Canvas").GetComponent<RectTransform>().sizeDelta.y;
        if (done)
        {
            if (toolPanel.sizeDelta.y < canvasHeight)
            {
                scrollbar.SetActive(false);
            }
            else
            {
                if (toggleToolPanel.GetComponentInChildren<Text>().text == "Close")
                {
                    scrollbar.SetActive(true);
                }
                else
                {
                    scrollbar.SetActive(false);
                }
            }
        }
    }

    public void changeButtonPos()
    {
        float diffInHeight = toolPanel.sizeDelta.y - canvasHeight;
        float changeYPos = diffInHeight * scrollbar.GetComponent<Scrollbar>().value;

        Vector3 deafaultPos = GameObject.Find("ToolPanelActivePos").transform.position;
        Vector3 scrollPosBefore = scrollbar.GetComponent<RectTransform>().position;

        Vector3 newPosPanel = deafaultPos;
        Vector3 newPosToggle = toggleToolPanelDefault.position;

        newPosPanel.y = deafaultPos.y + changeYPos;
        newPosToggle.y = toggleToolPanelDefault.position.y + changeYPos;

        toolPanel.position = newPosPanel;
        toggleToolPanel.GetComponent<RectTransform>().position = newPosToggle;
        scrollbar.GetComponent<RectTransform>().position = scrollPosBefore;
    }
}
