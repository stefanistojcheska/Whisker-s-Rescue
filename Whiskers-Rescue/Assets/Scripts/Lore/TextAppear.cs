using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class TextAppear : MonoBehaviour
{
    [SerializeField] private TextMeshPro textMesh;
    [SerializeField] private TextMeshPro hintText;

    public string message;
    public float delay = 0.05f;

    private bool finishedTyping = false;

    void Start()
    {
        hintText.gameObject.SetActive(false);
        StartCoroutine(TypeText());
    }

    void Update()
    {
        if (finishedTyping && Input.GetKeyDown(KeyCode.W))
        {
            SceneManager.LoadScene("Level1");
        }
    }

    IEnumerator TypeText()
    {
        textMesh.text = "";

        foreach (char letter in message)
        {
            textMesh.text += letter;
            yield return new WaitForSeconds(delay);
        }

        finishedTyping = true;
        hintText.gameObject.SetActive(true);
    }
}