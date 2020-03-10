using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    private GameObject mainObject;

    [SerializeField]
    private GameObject meshButtons;

    [SerializeField]
    private Material flatShading;
    [SerializeField]
    private Material gouraudShading;
    [SerializeField]
    private Material blinnPhongShading;

    public void enableFlatShading() {
        mainObject = GameObject.Find("ARSphere");
        mainObject.GetComponent<MeshRenderer>().material = flatShading;
    }

    public void enableGouraudShading()
    {
        mainObject = GameObject.Find("ARSphere");
        mainObject.GetComponent<MeshRenderer>().material = gouraudShading;
    }

    public void enableBlinnPhongShading()
    {
        mainObject = GameObject.Find("ARSphere");
        mainObject.GetComponent<MeshRenderer>().material = blinnPhongShading;
    }

    public void changeMesh() {
        mainObject = GameObject.Find("ARSphere");
        Mesh mesh = mainObject.GetComponent<MeshFilter>().mesh;
    }

    private void Update()
    {
        if (GameObject.Find("ARSphere") != null)
        {
            meshButtons.SetActive(true);
        }
    }
}
