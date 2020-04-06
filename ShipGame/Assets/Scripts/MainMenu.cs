using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
        GameManager.instance.SpawnSubManagers();

        UIManager.instance.SetOfUIPanels.playerUIPanel.SetActive(true);
        UIManager.instance.SetOfUIPanels.mainMenuPanel.SetActive(false);
        UIManager.instance.SetOfUIPanels.pausePanel.SetActive(false);
        UIManager.instance.SetOfUIPanels.gameOverPanel.SetActive(false);
       
       
    }


}
