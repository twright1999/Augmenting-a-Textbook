using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonManager : MonoBehaviour
{
    public void LoadCameraScene() {
        SceneManager.LoadScene("MeshDensity");
    }
}
