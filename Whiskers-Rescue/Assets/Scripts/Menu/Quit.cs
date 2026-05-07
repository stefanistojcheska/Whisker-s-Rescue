using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    private void OnMouseDown()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
