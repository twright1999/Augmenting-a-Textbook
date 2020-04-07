using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlinnPhongManager : MonoBehaviour
{

    [SerializeField]
    private GameObject shaderUI;

    private Slider ambientSlider;
    private Slider diffuseSlider;
    private Slider specularSlider;
    private Slider shininessSlider;
    private Renderer mainObjectRenderer;

    private TextMeshProUGUI ambientValueText;
    private TextMeshProUGUI diffuseValueText;
    private TextMeshProUGUI specularValueText;
    private TextMeshProUGUI shininessValueText;

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

            ambientValueText = GameObject.Find("AmbientValue").GetComponent<TextMeshProUGUI>();
            diffuseValueText = GameObject.Find("DiffuseValue").GetComponent<TextMeshProUGUI>();
            specularValueText = GameObject.Find("SpecularValue").GetComponent<TextMeshProUGUI>();
            shininessValueText = GameObject.Find("ShininessValue").GetComponent<TextMeshProUGUI>();
        }
        else if (GameObject.Find("ARShaderObject") == null && shaderUI.activeSelf)
        {
            shaderUI.SetActive(false);
        }

        if (GameObject.Find("ARShaderObject") != null)
        {
            mainObjectRenderer.material.SetFloat("_AmbientIntensity", ambientSlider.value);
            mainObjectRenderer.material.SetFloat("_DiffuseIntensity", diffuseSlider.value);
            mainObjectRenderer.material.SetFloat("_SpecularIntensity", specularSlider.value);
            mainObjectRenderer.material.SetFloat("_Shininess", shininessSlider.value);

            ambientValueText.text = ambientSlider.value.ToString("F2");
            diffuseValueText.text = diffuseSlider.value.ToString("F2");
            specularValueText.text = specularSlider.value.ToString("F2");
            shininessValueText.text = shininessSlider.value.ToString("F2");
        }
    }
}
