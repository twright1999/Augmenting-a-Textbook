using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetAppVersion : MonoBehaviour
{
    void Start()
    {
        TextMeshProUGUI version = this.GetComponent<TextMeshProUGUI>();
        version.text = "v " + Application.version;
    }
}
