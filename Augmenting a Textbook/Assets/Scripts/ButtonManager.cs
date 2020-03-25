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

    private GameObject meshPanel;
    private GameObject meshPanelStartPos;
    private GameObject meshPanelActivePos;
    private GameObject toggleMeshPanel;
    private GameObject toggleMeshPos;

    private GameObject closeButtonPos;

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

    public void toggleShaderMenu() {
        if (shaderPanel.transform.position == shaderPanelStartPos.transform.position)
        {
            toggleMeshPanel.SetActive(false);
            shaderPanel.transform.position = shaderPanelActivePos.transform.position;
            toggleShaderPanel.GetComponentInChildren<Text>().text = "Close";
        }
        else
        {
            toggleMeshPanel.SetActive(true);
            shaderPanel.transform.position = shaderPanelStartPos.transform.position;
            toggleShaderPanel.GetComponentInChildren<Text>().text = "Shaders";
        }
    }

    public void toggleMeshMenu() {
        if (meshPanel.transform.position == meshPanelStartPos.transform.position)
        {
            toggleShaderPanel.SetActive(false);
            meshPanel.transform.position = meshPanelActivePos.transform.position;
            toggleMeshPanel.transform.position = closeButtonPos.transform.position;
            toggleMeshPanel.GetComponentInChildren<Text>().text = "Close";
        }
        else
        {
            toggleShaderPanel.SetActive(true);
            meshPanel.transform.position = meshPanelStartPos.transform.position;
            toggleMeshPanel.transform.position = toggleMeshPos.transform.position;
            toggleMeshPanel.GetComponentInChildren<Text>().text = "Meshes";
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

            meshPanel = GameObject.Find("MeshPanel");
            meshPanelStartPos = GameObject.Find("MeshPanelStartPos");
            meshPanelActivePos = GameObject.Find("MeshPanelActivePos");
            toggleMeshPanel = GameObject.Find("ToggleMeshPanel");
            toggleMeshPos = GameObject.Find("ToggleMeshPos");

            closeButtonPos = GameObject.Find("CloseButtonPos");

            activeHighlight = GameObject.Find("ShaderActive");

            shaderPanel.transform.position = shaderPanelStartPos.transform.position;
            meshPanel.transform.position = meshPanelStartPos.transform.position;
        }
    }
}
