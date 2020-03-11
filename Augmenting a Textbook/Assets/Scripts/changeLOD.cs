using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeLOD : MonoBehaviour
{

    [SerializeField]
    private Mesh[] LODMeshes;

    private float LODValue;
    private Slider LODSlider;

    void Update()
    {
        if (LODSlider == null)
        {
            LODSlider = GameObject.Find("LODSlider").GetComponent<Slider>();
        }
        else
        {
            LODValue = LODSlider.value;
            int meshIndex = Mathf.RoundToInt(LODValue * (LODMeshes.Length - 1));
            GetComponent<MeshFilter>().mesh = LODMeshes[meshIndex];
        }
    }
}
