using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyScript : MonoBehaviour
{

    public NavMeshAgent agent;
    public enum EnemyState
    {
        PATROL = 1,
        DETECTION=2,
        SHOOT=3
    };
    public Rigidbody bulletPrefab;
    public float coolDown;
    public EnemyState state;
    public Transform[] players;
    Transform playerDetected = null;

    public Transform[] patrolPoints;

    public float health;
    public float speed;

    public int nextPoint = -1;
    public float timer;
    public float waittimer;

    public float viewrange;
    public float viewAngle;
    public float audioRange;

    //Firing vars
    public Transform GunPoint;
    public float cooldown;
    public float tmpCooldown;

    // Start is called before the first frame update
    void Start()
    {
        nextPoint = -1;
        agent.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {

        if (state == EnemyState.PATROL)
        {
            //Patrol Pattern
            if (waittimer <= 0)
            {
                nextPoint = (nextPoint + 1 < patrolPoints.Length) ? nextPoint + 1 : 0;
                waittimer = timer;
                agent.SetDestination(patrolPoints[nextPoint].position);
            }
            else
            {

                Vector3 pos = transform.position;
                pos.y = patrolPoints[nextPoint].position.y;
                //Debug.Log(Vector3.Distance(pos, PatrolPoints[nextPoint]));
                if (Vector3.Distance(pos, patrolPoints[nextPoint].position) < 20 * agent.radius)
                {
                    waittimer -= Time.deltaTime;

                }
            }
            isPlayerInRange();

        }
        else if(state == EnemyState.DETECTION)
        {

            float distanceToPlayer = Vector3.Distance(playerDetected.position, transform.position);
   
           
            
            agent.SetDestination(playerDetected.position );
            if (Vector3.Distance(playerDetected.position, transform.position) <= 20f)
            {
                agent.isStopped = true;
                state = EnemyState.SHOOT;
            }

            isPlayerInRange();
        }

        else if(state == EnemyState.SHOOT)
        {
            if(tmpCooldown<=0)
            {
                Vector3 dirToPlayer = playerDetected.position - transform.position;
                Rigidbody bullet = Instantiate(bulletPrefab, GunPoint.position, Quaternion.identity) as Rigidbody;
                bullet.AddForce(Vector3.Normalize(dirToPlayer) * 2000);
                tmpCooldown = cooldown;
            }
            else
            {
                tmpCooldown -= Time.deltaTime;
            }
            isPlayerInRange();
        }
        
    }




    bool isPlayerInRange()
    {
        //Can player be heard or seen?
        foreach (Transform Player in players) {
            

            Vector3 dirToPlayer = transform.position - transform.position;
            float distanceToPlayer = Vector3.Distance(Player.position, transform.position);
            //Checking for audio
            if (distanceToPlayer < audioRange)
            {
                playerDetected = Player;
                state = (state != EnemyState.SHOOT) ? EnemyState.DETECTION : EnemyState.SHOOT;
                Debug.Log("heard");
                return true;
            }

            if (distanceToPlayer < viewrange)
            {
                if (Vector2.Angle(dirToPlayer, transform.position) < viewAngle / 2)
                {
                    Debug.DrawLine(transform.position, Player.position, Color.red);

                    if (!Physics.Raycast(transform.position, dirToPlayer, distanceToPlayer, LayerMask.GetMask("player")))
                    {
                        playerDetected = Player;
                        state = (state!=EnemyState.SHOOT)? EnemyState.DETECTION : EnemyState.SHOOT;
                        Debug.Log("Saw");
                        return true;
                    }
                }
            }

        }
        
        return false;
    }
}
