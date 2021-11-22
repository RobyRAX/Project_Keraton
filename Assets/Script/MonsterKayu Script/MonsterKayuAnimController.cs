using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterKayuAnimController : MonoBehaviour
{
    Animator anim;

    public GameObject parentObject;

    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void ChaseAnim()
    {
        anim.SetBool("isChasing", true);
    }

    public void PatrolAnim()
    {
        anim.SetBool("isChasing", false);
    }

    public void AttackAnim()
    {
        anim.SetTrigger("attack");
        anim.SetBool("isChasing", false);
    }

    public void DieAnim()
    {
        anim.SetBool("isDie", true);
    }

    public void CallAttack()
    {
        parentObject.GetComponent<MonsterAttack>().BasicAttack();
        //Debug.Log("Musuh Menyerang");
        //parentObject.GetComponent<MonsterAttack>().DisableAttack();
    }
}
