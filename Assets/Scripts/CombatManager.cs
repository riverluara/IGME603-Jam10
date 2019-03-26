using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CombatManager : MonoBehaviour
{
    public int playerHealth = 50;
    public int playerHealth2 = 50;
    public int enemyDamage = 10;
    public GameObject player;
    public GameObject player2;
    public Transform playerSpawnPosition;
    public Transform playerSpawnPosition2;
    public float enemySpawnTime = 2.0f;
    public Text healthText;
    public Text healthText2;

    public WordControl wordControl;
    public WordControl2 wordControl2;
    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 50;
        playerHealth2 = 50;
        Debug.Log(playerHealth);
        GameObject _player = Instantiate(player, playerSpawnPosition.position, Quaternion.identity);
        GameObject _player2 = Instantiate(player2, playerSpawnPosition2.position, Quaternion.identity);

        currentTime = Time.time;
        healthText.text = playerHealth.ToString();
        healthText2.text = playerHealth2.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(playerHealth);
        if (playerHealth <= 0)
        {
            //Player Die
        }
        if((Time.time - currentTime) > enemySpawnTime)
        {
            EnemySpawn();
            currentTime = Time.time;
        }
        healthText.text = playerHealth.ToString();

    }
    public void GetDamage(Collision collision)
    {
        if (collision.transform.tag.Equals("Enemy1"))
        {
            playerHealth -= enemyDamage;
        }
        if (collision.transform.tag.Equals("Enemy2"))
        {
            playerHealth2 -= enemyDamage;
        }
        
        Debug.Log(playerHealth);
    }
    void EnemySpawn()
    {
        //Instantiate Enemies
        wordControl.AddWord();
        wordControl2.AddWord();
    }
    
}
