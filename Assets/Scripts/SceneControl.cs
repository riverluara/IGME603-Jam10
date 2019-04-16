using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

// Manages scene changing throughout the game
public class SceneControl : MonoBehaviour
{
    public Image img;
    public Animator anim;

    private GameObject mainMenu;
    private GameObject creditsMenu;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Start")
        {
            mainMenu = GameObject.FindGameObjectWithTag("Main Menu");
            creditsMenu = GameObject.FindGameObjectWithTag("Credit");

            mainMenu.SetActive(true);
            creditsMenu.SetActive(false);

            PlayerPrefs.DeleteKey("number");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Fading("CombatLevel1"));
            //PlayerPrefs.SetInt("number", PlayerPrefs.GetInt("number"));
        }
    }

    // Loading level
    public void LoadScene(string sceneName)
    {
        StartCoroutine(Fading(sceneName));
    }

    // Restarting Level
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Show credits
    public void ShowCredits()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    // Hide credits
    public void HideCredits()
    {
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }

    // Exit Game
    public void Quit()
    {
        Application.Quit();
    }

    // Fade in-between scenes
    public IEnumerator Fading(string sceneName)
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => img.color.a == 1);
        SceneManager.LoadScene(sceneName);
    }
}
