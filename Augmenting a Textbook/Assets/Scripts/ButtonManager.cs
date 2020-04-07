using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    private GameObject mainObject;

    private GameObject toolPanel;
    private GameObject toolPanelStartPos;
    private GameObject toolPanelActivePos;
    private GameObject toggleToolPanel;

    private GameObject activeHighlight;

    [SerializeField]
    private GameObject meshUI;

    [SerializeField]
    private Material flatShading;
    [SerializeField]
    private Material gouraudShading;
    [SerializeField]
    private Material blinnPhongShading;

    public void enableFlatShading() {
        mainObject.GetComponent<MeshRenderer>().material = flatShading;
        GameObject button = GameObject.Find("FlatShadingButton");
        activeHighlight.transform.position = button.transform.position;
    }

    public void enableGouraudShading()
    {
        mainObject.GetComponent<MeshRenderer>().material = gouraudShading;
        GameObject button = GameObject.Find("GouraudShadingButton");
        activeHighlight.transform.position = button.transform.position;
    }

    public void enableBlinnPhongShading()
    {
        mainObject.GetComponent<MeshRenderer>().material = blinnPhongShading;
        GameObject button = GameObject.Find("BlinnPhongShadingButton");
        activeHighlight.transform.position = button.transform.position;
    }

    public void toggleToolMenu() {
        if (toolPanel.transform.position == toolPanelStartPos.transform.position)
        {
            toolPanel.transform.position = toolPanelActivePos.transform.position;
            toggleToolPanel.GetComponentInChildren<Text>().text = "Close";
        }
        else
        {
            toolPanel.transform.position = toolPanelStartPos.transform.position;
            toggleToolPanel.GetComponentInChildren<Text>().text = "Tools";
        }
    }

    private void Update()
    {
        if (GameObject.Find("ARMeshObject") != null && !meshUI.activeSelf)
        {
            mainObject = GameObject.Find("ARMeshObject");
            meshUI.SetActive(true);

            toolPanel = GameObject.Find("ToolPanel");
            toolPanelStartPos = GameObject.Find("ToolPanelStartPos");
            toolPanelActivePos = GameObject.Find("ToolPanelActivePos");
            toggleToolPanel = GameObject.Find("ToggleToolPanel");

            activeHighlight = GameObject.Find("ShaderActive");

            toolPanel.transform.position = toolPanelStartPos.transform.position;
        }
        else if (GameObject.Find("ARMeshObject") == null && meshUI.activeSelf)
        {
            meshUI.SetActive(false);
        }
    }
}
