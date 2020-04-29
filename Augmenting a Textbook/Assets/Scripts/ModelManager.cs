using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ModelManager : MonoBehaviour
{
    // Sphere: 0, Teapot: 1
    public int currentModel = 0;
    private bool currentModelChange = false;

    private GameObject mainObject;

    private GameObject activeHighlight;

    [SerializeField]
    private Mesh[] sphereLODMeshes;

    [SerializeField]
    private Mesh[] teapotLODMeshes;

    private float LODValue;
    private TextMeshProUGUI LODValueText;
    private Slider LODSlider;

    void Update()
    {
        if (GameObject.Find("ARMeshObject") != null)
        {
            mainObject = GameObject.Find("ARMeshObject");
        }

        if (LODSlider == null && GameObject.Find("LODSlider") != null)
        {
            LODSlider = GameObject.Find("LODSlider").GetComponent<Slider>();
            LODValueText = GameObject.Find("LODValueText").GetComponent<TextMeshProUGUI>();
            LODValueText.text = getLODPercent(mainObject.GetComponent<MeshFilter>().mesh);
        }
        else if (LODSlider != null)
        {
            if (LODValue != LODSlider.value || currentModelChange)
            {
                currentModelChange = false;

                LODValue = LODSlider.value;
                Mesh[] newLODMeshes;
                Vector3 newTransform;

                switch (currentModel) {
                    case 0:
                        newLODMeshes = sphereLODMeshes;
                        newTransform = new Vector3(1f, 1f, 1f);
                        break;
                    case 1:
                        newLODMeshes = teapotLODMeshes;
                        newTransform = new Vector3(0.5f, 0.5f, 0.5f);
                        break;
                    default:
                        Debug.LogWarning("Unknown model index, sphere loaded");
                        newLODMeshes = sphereLODMeshes;
                        newTransform = new Vector3(0.4f, 0.4f, 0.4f);
                        break;
                }
                int meshIndex = Mathf.RoundToInt(LODValue * (newLODMeshes.Length - 1));

                if (mainObject.GetComponent<MeshFilter>().mesh != newLODMeshes[meshIndex])
                {
                    mainObject.GetComponent<MeshFilter>().mesh = newLODMeshes[meshIndex];
                    mainObject.transform.localScale = newTransform;

                    LODValueText.text = getLODPercent(newLODMeshes[meshIndex]);
                }
            }
            activeHighlight = GameObject.Find("MeshActive");
        }
    }

    private string getLODPercent(Mesh mesh) {
        if (mesh.name.Contains("default"))
        {
            return "100%";
        }
        else
        {
            return mesh.name;
        }
    }

    public void setSphere()
    {
        currentModel = 0;
        currentModelChange = true;
        GameObject button = GameObject.Find("SetSphereButton");
        activeHighlight.transform.position = button.transform.position;
    }

    public void setTeapot()
    {
        currentModel = 1;
        currentModelChange = true;
        GameObject button = GameObject.Find("SetTeapotButton");
        activeHighlight.transform.position = button.transform.position;
    }
}
