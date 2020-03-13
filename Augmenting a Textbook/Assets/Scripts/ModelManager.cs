using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelManager : MonoBehaviour
{
    // Sphere: 0, Teapot: 1
    public int currentModel = 0;
    private bool currentModelChange = false;

    private GameObject mainObject;

    [SerializeField]
    private Mesh[] sphereLODMeshes;

    [SerializeField]
    private Mesh[] teapotLODMeshes;

    private float LODValue;
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
                        newTransform = new Vector3(0.4f, 0.4f, 0.4f);
                        break;
                    case 1:
                        newLODMeshes = teapotLODMeshes;
                        newTransform = new Vector3(0.2f, 0.2f, 0.2f);
                        break;
                    default:
                        Debug.LogWarning("Unknown model index, sphere loaded");
                        newLODMeshes = sphereLODMeshes;
                        newTransform = new Vector3(0.4f, 0.4f, 0.4f);
                        break;
                }
                int meshIndex = Mathf.RoundToInt(LODValue * (newLODMeshes.Length - 1));
                mainObject.GetComponent<MeshFilter>().mesh = newLODMeshes[meshIndex];
                mainObject.transform.localScale = newTransform;
            }
        }
    }

    public void setSphere()
    {
        currentModel = 0;
        currentModelChange = true;
    }

    public void setTeapot()
    {
        currentModel = 1;
        currentModelChange = true;
    }
}
