using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    void OnReset()
    {
        if (GUILayout.Button("Reset"))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

}