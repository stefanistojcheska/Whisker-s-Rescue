using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
