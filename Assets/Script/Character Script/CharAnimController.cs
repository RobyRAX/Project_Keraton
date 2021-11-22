using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnimController : MonoBehaviour
{
    Animator animator;
    bool isAttacking;
    bool touchInputCombo;
    bool isDash;

    public float inputComboTimer;
    public float inputComboResetTimer;
    float comboTimer;
    float comboResetTimer;

    public float inputDashTimer;
    float dashTimer;

    int comboStep;

    public GameObject parentObject;

    // Start is called before the first frame update
    void Start()
    {
        dashTimer = inputDashTimer;
        touchInputCombo = false;
        animator = this.GetComponent<Animator>();
        isAttacking = false;
        comboStep = 0; //0 = Idle
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDash)
        {
            /*
            if (Input.GetKeyDown(KeyCode.Space))
            {
                activateCombo();
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("P");
                animator.SetBool("isWalking", true);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                animator.SetBool("isWalking", false);
            }
            */
            ComboSystem();
        }     
    }

    void ComboSystem()
    {
        if(touchInputCombo)
        {
            isAttacking = true;
            comboResetTimer = inputComboResetTimer;
        }

        if(isAttacking)
        {
            comboTimer -= Time.deltaTime;
            comboResetTimer -= Time.deltaTime;
            animator.SetBool("isAttacking", true);

            if(comboStep == 0 && touchInputCombo && comboTimer < 0)
            {
                comboTimer = inputComboTimer;
                comboStep = 1;
                animator.SetInteger("comboStep", 1);
                //GameObject.Find("Main Camera").GetComponent<CameraEffect>().CallShake(.1f, .05f);                
            }
            if (comboStep == 1 && touchInputCombo && comboTimer < 0)
            {
                comboTimer = inputComboTimer;
                comboStep = 2;
                animator.SetInteger("comboStep", 2);
                //GameObject.Find("Main Camera").GetComponent<CameraEffect>().CallShake(.1f, .05f);
            }
            if (comboStep == 2 && touchInputCombo && comboTimer < 0)
            {
                comboTimer = inputComboTimer;
                comboStep = 3;
                animator.SetInteger("comboStep", 3);
                //GameObject.Find("Main Camera").GetComponent<CameraEffect>().CallShake(.1f, .05f);
            }
            if (comboStep == 3 && touchInputCombo && comboTimer < 0)
            {
                comboTimer = inputComboTimer + 0.3f ;
                comboStep = 4;
                animator.SetInteger("comboStep", 4);
                //GameObject.Find("Main Camera").GetComponent<CameraEffect>().CallShake(.1f, .05f);
            }
            if (comboStep == 4 && touchInputCombo && comboTimer < 0)
            {
                comboTimer = inputComboTimer + 0.125f;
                comboStep = 1;
                animator.SetInteger("comboStep", 1);
                
            }

            if (comboResetTimer < 0)
            {
                isAttacking = false;
                comboStep = 0;
                animator.SetInteger("comboStep", 0);
                animator.SetBool("isAttacking", false);
            }
        }
    }

    public void WalkOn()
    {
        animator.SetBool("isWalking", true);
    }
    public void WalkOff()
    {
        animator.SetBool("isWalking", false);
    }

    public void ActivateCombo()
    {
        touchInputCombo = true;
    }
    public void DeactivateCombo()
    {
        touchInputCombo = false;
    }

    public void ActivateDash()
    {
        if(!isDash)
        {
            StartCoroutine(Dash());            
        }      
    }

    IEnumerator Dash()
    {
        Debug.Log("Dash");
        isDash = true;
        animator.SetBool("isDash", true);
        isAttacking = false;
        comboStep = 0;
        animator.SetInteger("comboStep", 0);
        animator.SetBool("isAttacking", false);
        yield return new WaitForSeconds(inputDashTimer);
        isDash = false;
        animator.SetBool("isDash", false);
    }

    public bool GetIsDash()
    {
        return isDash;
    }

    public void CallBasicAttack()
    {
        parentObject.GetComponent<CharAttack>().BasicAttack();
        GameObject.Find("Main Camera").GetComponent<CameraEffect>().CallShake(.025f, .025f);
        this.GetComponent<AudioSource>().Play();
    }

    public void Die()
    {
        animator.SetBool("isDie", true);
    }
}
