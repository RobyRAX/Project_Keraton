using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    int displayNyawa;
    public GameObject player;

    public GameObject hati1;
    public GameObject hati2;
    public GameObject hati3;
    public GameObject hati4;
    public GameObject hati5;

    public GameObject UI_Parent;

    public GameObject damageFX;

    public GameObject winBG;
    public GameObject loseBG;

    // Start is called before the first frame update
    void Start()
    {
        displayNyawa = player.GetComponent<Char>().inputHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (displayNyawa == 5)
        {
            hati1.SetActive(true);
            hati2.SetActive(true);
            hati3.SetActive(true);
            hati4.SetActive(true);
            hati5.SetActive(true);
        }
        else if (displayNyawa == 4)
        {
            hati1.SetActive(true);
            hati2.SetActive(true);
            hati3.SetActive(true);
            hati4.SetActive(true);
            hati5.SetActive(false);
        }
        else if(displayNyawa == 3)
        {
            hati1.SetActive(true);
            hati2.SetActive(true);
            hati3.SetActive(true);
            hati4.SetActive(false);
            hati5.SetActive(false);
        }
        else if(displayNyawa == 2)
        {
            hati1.SetActive(true);
            hati2.SetActive(true);
            hati3.SetActive(false);
            hati4.SetActive(false);
            hati5.SetActive(false);
        }
        else if(displayNyawa == 1)
        {
            hati1.SetActive(true);
            hati2.SetActive(false);
            hati3.SetActive(false);
            hati4.SetActive(false);
            hati5.SetActive(false);
        }
        else if (displayNyawa == 0)
        {
            HideUI();              
        }
    }

    public void SetDisplayNyawa(int currentHealth)
    {
        displayNyawa = currentHealth;
    }

    IEnumerator ShowDamageFX()
    {
        damageFX.SetActive(true);
        yield return new WaitForSeconds(.1f);
        damageFX.SetActive(false);
    }

    public void CallDamageFX()
    {
        StartCoroutine(ShowDamageFX());
    }

    public void ShowGameWin()
    {
        winBG.SetActive(true);
        HideUI();
    }

    public void ShowGameLose()
    {
        loseBG.SetActive(true);
        HideUI();
    }

    void HideUI()
    {
        UI_Parent.SetActive(false);
    }
}
