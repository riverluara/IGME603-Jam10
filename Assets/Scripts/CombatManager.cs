using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CombatManager : MonoBehaviour
{
    public int playerHealth = 50;
    public int enemyDamage = 10;
    public float enemySpawnTime = 4.0f;
    public GameObject player;
    //public GameObject player2;
    public Transform playerSpawnPosition;
    //public Transform playerSpawnPosition2;
    public Text healthText;
    public Text scoreText;
    public WordControl wordControl;
    public HealthBarMovement healthBar;
    public Transform cameraTransform;
    private Vector3 originalPos;
   // public WordControl2 wordControl2;

    private float currentTime;
    private int score;
    private SceneControl sceneControl;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(playerHealth);
        playerHealth = 50;
        score = 0;

       

        healthText.text = "Health: " + playerHealth.ToString();
        scoreText.text = "Score: " + score;

        GameObject _player = Instantiate(player, playerSpawnPosition.position, Quaternion.identity);
        //GameObject _player2 = Instantiate(player2, playerSpawnPosition2.position, Quaternion.identity);
        healthBar = _player.GetComponentInChildren<HealthBarMovement>();
       currentTime = Time.time;

        sceneControl = new SceneControl();


    }

    private void OnEnable()
    {
        originalPos = cameraTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0)
        {
            //Player Die
        }

        if ((Time.time - currentTime) > enemySpawnTime)
        {
            EnemySpawn();
            score += 1;
            currentTime = Time.time;
        }

        healthText.text = "Health: " + playerHealth.ToString();
        scoreText.text = "Score: " + score;

        if(PlayerPrefs.GetInt("number") == 9)
        {
            PlayerPrefs.SetInt("number", PlayerPrefs.GetInt("number") + 1);
            SceneManager.LoadScene("overworld_1");
        }

        if(PlayerPrefs.GetInt("number") >= 22)
        {
            SceneManager.LoadScene("End");
        }

        /*
        // Increase level based off score
        if (score >= 25)
            StartCoroutine(sceneControl.Fading("CombatLevel2"));
        if (score >= 60)
            StartCoroutine(sceneControl.Fading("CombatLevel3"));
        */
    }

    // Take Enemy damage
    public void GetDamage()
    {
        playerHealth -= enemyDamage;
        healthBar.ChangeLength(playerHealth / 50.0f);

        //Debug.Log(playerHealth);
    }

    // Instantiate Enemies
    void EnemySpawn()
    {        
        wordControl.AddWord();
       // wordControl2.AddWord();
    }

    public void DamegeEffect()
    {
        StartCoroutine(CameraShake());
    }

    public IEnumerator CameraShake()
    {
        float shakeTime = 1.0f;
        while(shakeTime >= 0.0f)
        {
            cameraTransform.position = originalPos + Random.insideUnitSphere * 0.5f;
            shakeTime -= Time.deltaTime;
        }
        yield return null;
    }

}
