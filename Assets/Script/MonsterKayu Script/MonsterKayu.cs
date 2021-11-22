using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterKayu : MonoBehaviour
{
    public int inputHealth;
    int health;
    bool isLife;

    public NavMeshAgent agent;
    float navSpeed;
    
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    public GameObject monsterModel;

    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetWeenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    const int GameStart = 1;
    const int Win = 2;
    const int Lose = 3;

    void Awake()
    {
        player = GameObject.Find("charController").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        isLife = true;
        navSpeed = agent.speed;
        health = inputHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("cameraHolder").GetComponent<GameManager>().GetState() == GameStart && GameObject.Find("cameraHolder").GetComponent<GameManager>().GetGameOver() == false)
        {
            if (isLife)
            {
                //Check for sight and attack range
                playerInSightRange = Physics.CheckSphere(this.transform.position, sightRange, whatIsPlayer);
                playerInAttackRange = Physics.CheckSphere(this.transform.position, attackRange, whatIsPlayer);

                if (!playerInSightRange && !playerInAttackRange)
                    Patrolling();
                else if (playerInSightRange && !playerInAttackRange)
                    ChasePlayer();
                else if (playerInSightRange && playerInAttackRange)
                    AttackPlayer();
            }
            else
            {
                Invoke(nameof(Delete), 2f);
            }
        }            
    }

    void Patrolling()
    {
        if (!walkPointSet)
            SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = this.transform.position - walkPoint;

        //WalkPoint Reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;

        //Patroll Anim
        monsterModel.GetComponent<MonsterKayuAnimController>().PatrolAnim();

    }

    void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(this.transform.position.x + randomX, this.transform.position.y, this.transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    void ChasePlayer()
    {
        agent.SetDestination(player.position);
        monsterModel.GetComponent<MonsterKayuAnimController>().ChaseAnim();
        SearchWalkPoint();

    }

    void AttackPlayer()
    {
        //make sure enemy doesn't move
        agent.speed = 0;

        //transform.LookAt(player);

        if (!alreadyAttacked)
        {
            ///Attack Code Here
            monsterModel.GetComponent<MonsterKayuAnimController>().AttackAnim();
            this.GetComponent<AudioSource>().Play(0);
            ///

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetWeenAttacks);
        }
    }

    void ResetAttack()
    {
        alreadyAttacked = false;
        agent.speed = navSpeed; //Reset Speed
    }

    public void TakeDamage(int damageTaken)
    {
        if(health > 0)
        {
            this.GetComponent<AudioSource>().Play(0);
            health -= damageTaken;
            Debug.Log(health);
            GameObject.Find("Main Camera").GetComponent<CameraEffect>().CallShake(.1f, .1f);
        }
        
        if(health == 0)
        {
            Died();
        }
    }

    void Died()
    {
        Debug.Log("Monster Kayu Mati");        
        monsterModel.GetComponent<MonsterKayuAnimController>().DieAnim();
        isLife = false;
    }

    void Delete()
    {
        GameObject.Find("cameraHolder").GetComponent<GameManager>().CountKilledMonster();        
        Destroy(this.gameObject);
    }

    public int GetHealth()
    {
        return health;
    }
}
