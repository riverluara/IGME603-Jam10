using UnityEngine;
using UnityEngine.UI;

public class WordDisplay : MonoBehaviour
{
    public Text text;
    public GameObject enemy;
    public GameObject firePrefab;
    public Transform player;
    private bool isFireAttack = false;
    public GameObject fire = null;
    public float speed;

    void Update()
    {
        if (isFireAttack)
        {
            Vector3 direction = Vector3.Normalize(enemy.transform.position - fire.transform.position);
            fire.transform.forward = direction;
            //fire.transform.position += direction * speed * Time.deltaTime;
        }
             
    }

    public void SetWord(string word)
    {
        text.text = word;
    }

    public void RemoveLetter()
    {
        text.text = text.text.Remove(0, 1);
        text.color = Color.red;
    }

    public void RemoveWord()
    {
        // Destroy enemy
        //Destroy(enemy);
        fireAttack();
    }

    public void fireAttack()
    {
        fire = Instantiate(firePrefab, player.position + new Vector3(0.0f,1.0f,0.0f), Quaternion.identity);
        isFireAttack = true;
    }
}
