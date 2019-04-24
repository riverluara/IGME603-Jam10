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
    public bool damegeEffect;
    public float cameraShakeTime = 0.25f;

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
        currentTime = Time.time;

        sceneControl = new SceneControl();

        damegeEffect = false;
    }

    private void OnEnable()
    {
        originalPos = cameraTransform.localPosition;
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

    private void FixedUpdate()
    {
        if (damegeEffect)
        {
            if(cameraShakeTime >= 0.0f)
            {
                cameraTransform.localPosition = originalPos + Random.insideUnitSphere * 0.25f;
                cameraShakeTime -= Time.deltaTime;
            }
            else
            {
                cameraTransform.localPosition = originalPos;
                cameraShakeTime = 0.25f;
                damegeEffect = false;
            }
            
        }
    }

    // Take Enemy damage
    public void GetDamage()
    {
        playerHealth -= enemyDamage;

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
            cameraTransform.localPosition = originalPos + Random.insideUnitSphere * 2.0f;
            Debug.Log(cameraTransform.position);
            shakeTime -= Time.deltaTime;
        }
        
        yield return null;
        cameraTransform.localPosition = originalPos;
    }

}
