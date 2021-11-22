using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    int bossHealth;
    //public GameObject player;

    void Start()
    {
        bossHealth = GetComponent<MonsterKayu>().GetHealth();
    }

    void Update()
    {
        bossHealth = GetComponent<MonsterKayu>().GetHealth();
        if (bossHealth == 0)
            SendWinMessage();
    }

    void SendWinMessage()
    {
        GameObject.Find("char").GetComponent<CharAnimController>().DeactivateCombo();
        GameObject.Find("cameraHolder").GetComponent<GameManager>().SetGameWin();        
    }
}
