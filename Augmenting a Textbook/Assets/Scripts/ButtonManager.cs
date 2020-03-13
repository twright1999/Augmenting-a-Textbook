using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    private GameObject mainObject;
    private GameObject shaderPanel;
    private GameObject shaderPanelStartPos;
    private GameObject shaderPanelActivePos;
    private GameObject toggleShaderPanel;

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
    }

    public void enableGouraudShading()
    {
        mainObject.GetComponent<MeshRenderer>().material = gouraudShading;
    }

    public void enableBlinnPhongShading()
    {
        mainObject.GetComponent<MeshRenderer>().material = blinnPhongShading;
    }

    public void toggleShaderMenu() {
        if (shaderPanel.transform.position == shaderPanelStartPos.transform.position)
        {
            shaderPanel.transform.position = shaderPanelActivePos.transform.position;
            toggleShaderPanel.GetComponentInChildren<Text>().text = "Close";
        }
        else
        {
            shaderPanel.transform.position = shaderPanelStartPos.transform.position;
            toggleShaderPanel.GetComponentInChildren<Text>().text = "Shaders";
        }
    }

    private void Update()
    {
        if (GameObject.Find("ARMeshObject") != null && !meshUI.activeSelf)
        {
            mainObject = GameObject.Find("ARMeshObject");
            meshUI.SetActive(true);

            shaderPanel = GameObject.Find("ShaderPanel");
            shaderPanelStartPos = GameObject.Find("ShaderPanelStartPos");
            shaderPanelActivePos = GameObject.Find("ShaderPanelActivePos");
            toggleShaderPanel = GameObject.Find("ToggleShaderPanel");

            shaderPanel.transform.position = shaderPanelStartPos.transform.position;
        }
    }
}
