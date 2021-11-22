using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool gameStart;
    bool gameOver;

    int state;

    const int GameStart = 1;
    const int Win = 2;
    const int Lose = 3;

    int monsterKilled;

    // Start is called before the first frame update
    void Start()
    {
        gameStart = true;
        gameOver = false;
        state = GameStart;

        monsterKilled = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(state != 3 && GameObject.Find("SpawnerMusuh").GetComponent<Spawner>().GetCurrentEnemies() == 0)
        {
            //SetGameWin();
        }
    }

    public void SetGameStart()
    {
        gameStart = true;
        gameOver = false;
        state = GameStart;
    }

    public void SetGameWin()
    {
        gameStart = true;
        gameOver = true;
        state = Win;
        GameObject.Find("Canvas").GetComponent<UI>().ShowGameWin();
    }

    public void SetGameLose()
    {
        gameStart = true;
        gameOver = true;
        state = Lose;
        GameObject.Find("Canvas").GetComponent<UI>().ShowGameLose();
    }

    public bool GetGameStart()
    {
        return gameStart;
    }

    public bool GetGameOver()
    {
        return gameOver;
    }

    public int GetState()
    {
        return state;
    }

    public void CountKilledMonster()
    {
        monsterKilled++;
    }
}
