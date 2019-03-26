using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CombatManager : MonoBehaviour
{
    public int playerHealth = 50;
    public int enemyDamage = 10;
    public GameObject player;
    public Transform playerSpawnPosition;
    public float enemySpawnTime = 2.0f;
    public Text healthText;
    public WordControl wordControl;
    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 50;
        Debug.Log(playerHealth);
        GameObject _player = Instantiate(player, playerSpawnPosition.position, Quaternion.identity);
        currentTime = Time.time;
        healthText.text = playerHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(playerHealth);
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
    public void GetDamage()
    {
        playerHealth -= enemyDamage;
        
        Debug.Log(playerHealth);
    }
    void EnemySpawn()
    {
        //Instantiate Enemies
        wordControl.AddWord();
    }
    
}
