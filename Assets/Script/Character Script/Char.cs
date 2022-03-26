using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char : MonoBehaviour
{
    public Joystick joystick;
    public float rotateSpeed;
    public float forwardSpeed;
    public float dashSpeed;

    public GameObject charObject;
    public GameObject cameraObject;

    bool isCharDash;

    public int inputHealth;
    int health;

    bool isLife = true;

    const int GameStart = 1;
    const int Win = 2;
    const int Lose = 3;

    // Start is called before the first frame update
    void Start()
    {
        isCharDash = false;
        health = inputHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("cameraHolder").GetComponent<GameManager>().GetState() == GameStart && GameObject.Find("cameraHolder").GetComponent<GameManager>().GetGameOver() == false)
        {
            if (isLife)
            {
                if (isCharDash)
                    transform.Translate(0, 0, dashSpeed * Time.deltaTime);
                else
                    AnalogMovement();
            }
        }      
    }


    void AnalogMovement()
    {
#if UNITY_EDITOR
        //Logic WASD
#elif UNITY_ANDROID
        float angle = Mathf.Atan2(joystick.Horizontal, joystick.Vertical) * Mathf.Rad2Deg;
        Quaternion rotationTarget = Quaternion.Euler(new Vector3(0, angle, 0));
        
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationTarget, rotateSpeed * Time.deltaTime);
            transform.Translate(0, 0, forwardSpeed * Time.deltaTime);
            charObject.GetComponent<CharAnimController>().WalkOn();
            cameraObject.GetComponent<CameraEffect>().WalkEffectOn();          
        }
        else
        {
            charObject.GetComponent<CharAnimController>().WalkOff();
            cameraObject.GetComponent<CameraEffect>().WalkEffectOff();           
        }           
#endif
    }

    public void Dash()
    {
        charObject.GetComponent<CharAnimController>().ActivateDash();
        StartCoroutine(DashMovement());
    }

    IEnumerator DashMovement()
    {
        isCharDash = true;       
        yield return new WaitForSeconds(0.5f);
        isCharDash = false;
    }

    public void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
        //Debug.Log(health);
        GameObject.Find("Canvas").GetComponent<UI>().CallDamageFX(); 

        //Death
        if (health <= 0)
        {
            isLife = false;
            charObject.GetComponent<CharAnimController>().Die();
            GameObject.Find("cameraHolder").GetComponent<GameManager>().SetGameLose();
            this.GetComponent<CharAnimController>().DeactivateCombo();
        }
        GameObject.Find("Canvas").GetComponent<UI>().SetDisplayNyawa(health);
    }
}
