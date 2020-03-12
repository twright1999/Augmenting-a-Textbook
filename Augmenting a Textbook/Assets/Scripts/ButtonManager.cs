using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    private GameObject mainObject;

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

    public void changeMesh() {
        Mesh mesh = mainObject.GetComponent<MeshFilter>().mesh;
    }

    private void Update()
    {
        if (GameObject.Find("ARMeshObject") != null)
        {
            mainObject = GameObject.Find("ARMeshObject");
            meshUI.SetActive(true);
        }
    }
}
