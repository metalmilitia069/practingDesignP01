using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    #region Singleton
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("There is more than one GameManager in the Scene");
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion

    [SerializeField]
    private bool _isGameOver;
    
    [SerializeField]
    private bool _flipflop = false;
    
    [Serializable]   
    public struct SetofSubManagers
    {
        public GameObject UIManager;
        public GameObject SpawnManager;
    }

    [SerializeField]
    [Header("Sub-Managers")]
    [Space(20)]
    private SetofSubManagers _setofSubManagers;


    // Start is called before the first frame update
    void Start()
    {        
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene aScene, LoadSceneMode aMode)
    {
        SpawnSubManagers();
        
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            UIManager.instance.SetOfUIPanels.mainMenuPanel.SetActive(true);
            UIManager.instance.SetOfUIPanels.pausePanel.SetActive(false);
            UIManager.instance.SetOfUIPanels.playerUIPanel.SetActive(false);
            _flipflop = !_flipflop;
            Time.timeScale = 1.0f;
        }
        else
        {
            UIManager.instance.SetOfUIPanels.playerUIPanel.SetActive(true);
            UIManager.instance.SetOfUIPanels.mainMenuPanel.SetActive(false);
            UIManager.instance.SetOfUIPanels.pausePanel.SetActive(false);
            UIManager.instance.SetOfUIPanels.gameOverPanel.SetActive(false);
        }
    }

    public void SpawnSubManagers()
    {
        Instantiate(_setofSubManagers.UIManager, transform.position, Quaternion.identity);
        Instantiate(_setofSubManagers.SpawnManager, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && _isGameOver == true)
        {
            SceneManager.LoadScene("Game");

            _isGameOver = false;
            UIManager.instance.ResetSequence();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            _flipflop = !_flipflop;            

            UIManager.instance.SetPauseMenu(_flipflop);

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
       
        UIManager.instance.SetPauseMenu(_flipflop);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        UIManager.instance.SetOfUIPanels.mainMenuPanel.SetActive(true);
        UIManager.instance.SetOfUIPanels.pausePanel.SetActive(false);
        UIManager.instance.SetOfUIPanels.playerUIPanel.SetActive(false);
        _flipflop = !_flipflop;
        Time.timeScale = 1.0f;

    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");        
    }

    private void OnEnable()
    {
        SpawnSubManagers();
    }
}
