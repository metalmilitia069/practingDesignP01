using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool _isGameOver;

    [SerializeField]
    private GameObject _pauseMenuPanel;

    [SerializeField]
    private bool _flipflop = false;

    [SerializeField]
    private Animator _pauseAnimator;

    // Start is called before the first frame update
    void Start()
    {
        _pauseAnimator = _pauseMenuPanel.GetComponent<Animator>();
        _pauseAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && _isGameOver == true)
        {
            SceneManager.LoadScene("Game");
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            _flipflop = !_flipflop;
            _pauseMenuPanel.SetActive(_flipflop);

            _pauseAnimator.SetBool("isPaused", true);

            if (!_flipflop)
            {
                Time.timeScale = 1.0f;
            }
            else
            {
                Time.timeScale = 0.0f;
            }
        }
    }

    public void GameOver()
    {
        _isGameOver = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        _flipflop = !_flipflop;
        _pauseMenuPanel.SetActive(_flipflop);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
    }

    



}
