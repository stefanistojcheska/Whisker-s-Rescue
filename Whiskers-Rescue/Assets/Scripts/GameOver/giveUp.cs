using UnityEngine;
using UnityEngine.SceneManagement;

public class giveUp : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
