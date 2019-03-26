using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform targetTransform;
    public float speed = 1.0f;
    public CombatManager combatManager;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        combatManager = (CombatManager)FindObjectOfType(typeof(CombatManager));
    }

    // Update is called once per frame
    void Update()
    {
        direction =Vector3.Normalize(targetTransform.position - this.transform.position );
        this.transform.position += direction * speed * Time.deltaTime;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("collision happens");
        if (collision.transform.tag.Equals("Player"))
        {
            //Player Get Damage
            combatManager.GetDamage(collision);
            Destroy(this.gameObject);
            
        }
    }
}
