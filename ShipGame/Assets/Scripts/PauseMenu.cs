using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void ResumeGame()
    {
        //Time.timeScale = 1.0f;

        GameManager.instance.ResumeGame();
            
         //_flipflop = !_flipflop;

        //_pauseMenuPanel.SetActive(_flipflop);
        //UIManager.instance.SetPauseMenu(_flipflop);
    }
}
