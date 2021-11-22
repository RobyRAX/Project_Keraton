using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRadius;
    public int damage;

    bool Attack;

    Collider[] hitEnemies;

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

    void FixedUpdate()
    {
        //Detect Enemies
        hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRadius);
        foreach (Collider enemy in hitEnemies)
        {
            //Debug.Log(enemy.name);
        }
    }

    public void BasicAttack()
    {
        //Damage Enemies
        foreach (Collider enemy in hitEnemies)
        {
            Physics.SyncTransforms();
            //Debug.Log("Berhasil Nyerang");

            if(enemy.tag == "Musuh")
                enemy.GetComponent<MonsterKayu>().TakeDamage(damage);
        }
    }              
}
