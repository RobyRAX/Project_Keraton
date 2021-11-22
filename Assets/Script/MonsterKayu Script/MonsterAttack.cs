using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRadius;
    public int damage;
    public GameObject player;
    //bool playerIsInAttackArea;
    //bool monsterAttacking = false;

    const int GameStart = 1;
    const int Win = 2;
    const int Lose = 3;

    Collider[] ObjectsCollide;

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

    void FixedUpdate()
    {
        ObjectsCollide = Physics.OverlapSphere(attackPoint.position, attackRadius);
    }

    void Update()
    {
        if (GameObject.Find("cameraHolder").GetComponent<GameManager>().GetState() == GameStart && GameObject.Find("cameraHolder").GetComponent<GameManager>().GetGameOver() == false)
        {           
                           
        }          
    }

    public void BasicAttack()
    {
        foreach(Collider player in ObjectsCollide)
        {
            if(player.tag == "Player")
            {
                player.GetComponent<Char>().TakeDamage(damage);
            }
        }

    }
}
