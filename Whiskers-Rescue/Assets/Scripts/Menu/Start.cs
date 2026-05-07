using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Intro");
    }
}
