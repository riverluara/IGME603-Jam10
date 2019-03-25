using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

// Manages scene changing throughout the game
public class SceneControl : MonoBehaviour
{
    public string sceneName;
    public Image img;
    public Animator anim;

    // Loading level
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    // Restarting Level
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Fade in-between scenes
    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => img.color.a == 1);
        LoadScene();
    }
}
