using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject panelKredit;

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Test_Mechanic");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowCredit()
    {
        panelKredit.SetActive(true);
    }

    public void CloseCredit()
    {
        panelKredit.SetActive(false);
    }
}
