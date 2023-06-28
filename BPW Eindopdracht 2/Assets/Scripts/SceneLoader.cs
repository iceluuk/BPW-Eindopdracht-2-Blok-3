using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Update()
    {
        // Als er op de "R"-toets wordt gedrukt, roep resetScene-functie aan
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetScene();
        }
    }

    // Functie om een scene te openen
    public void OpenScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Functie om de huidige scene te resetten
    public void ResetScene()
    {
        // Laad de huidige scene opnieuw
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
