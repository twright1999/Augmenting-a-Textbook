using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    private GameObject mainObject;
    private GameObject light;


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

    public void toggleLight() {
        mainObject = GameObject.Find("ARSphere");
        light = mainObject.transform.GetChild(0).gameObject;
        if (light.activeSelf)
        {
            light.SetActive(false);
        }
        else
        {
            light.SetActive(true);
        }
    }
}
