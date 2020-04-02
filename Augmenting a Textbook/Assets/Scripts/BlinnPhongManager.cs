using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinnPhongManager : MonoBehaviour
{

    [SerializeField]
    private GameObject shaderUI;

    private Slider ambientSlider;
    private Slider diffuseSlider;
    private Slider specularSlider;
    private Slider shininessSlider;
    private Renderer mainObjectRenderer;

    private void Start()
    {
        mainObjectRenderer = GameObject.Find("ARShaderObject").GetComponent<Renderer>();
        ambientSlider = GameObject.Find("AmbientSlider").GetComponent<Slider>();
        diffuseSlider = GameObject.Find("DiffuseSlider").GetComponent<Slider>();
        specularSlider = GameObject.Find("SpecularSlider").GetComponent<Slider>();
        shininessSlider = GameObject.Find("ShininessSlider").GetComponent<Slider>();
    }

    private void Update()
    {
        if (GameObject.Find("ARShaderObject") != null && !shaderUI.activeSelf)
        {
            shaderUI.SetActive(true);

            mainObjectRenderer = GameObject.Find("ARShaderObject").GetComponent<Renderer>();
            ambientSlider = GameObject.Find("AmbientSlider").GetComponent<Slider>();
            diffuseSlider = GameObject.Find("DiffuseSlider").GetComponent<Slider>();
            specularSlider = GameObject.Find("SpecularSlider").GetComponent<Slider>();
            shininessSlider = GameObject.Find("ShininessSlider").GetComponent<Slider>();
        }
        else if (GameObject.Find("ARShaderObject") == null && shaderUI.activeSelf)
        {
            shaderUI.SetActive(false);
        }

        mainObjectRenderer.material.SetFloat("_AmbientIntensity", ambientSlider.value);
        mainObjectRenderer.material.SetFloat("_DiffuseIntensity", diffuseSlider.value);
        mainObjectRenderer.material.SetFloat("_SpecularIntensity", specularSlider.value);
        mainObjectRenderer.material.SetFloat("_Shininess", shininessSlider.value);
    }
}
