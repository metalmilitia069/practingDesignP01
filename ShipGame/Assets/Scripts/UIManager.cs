using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    [Header("Variables")]
    [Space(20)]    
    [SerializeField]
    private int _bestScore;
    private int _score;
    private bool _flipflop = false;

    [Header("UI Elements")]
    [Space(20)]
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _bestText;
    [SerializeField]
    private Sprite[] _lifeSprites;
    [SerializeField]
    private Image _livesDisplay;
    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private Text _restartText;



    [Serializable]
    public struct UIPanels
    {
        public GameObject mainMenuPanel;
        public GameObject pausePanel;
        public Animator pauseAnimator;
        public GameObject playerUIPanel;
        public GameObject gameOverPanel;
    }

    [Header("UI Panel Prefabs/References")]
    [Space(20)]
    [SerializeField]
    private UIPanels setOfUIPanels;

    #region Singleton

    public static UIManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("There is More Than One UIManager in the Scene!!!");
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    #endregion


    public Text ScoreText { get => _scoreText; set => _scoreText = value; }
    public UIPanels SetOfUIPanels { get => setOfUIPanels; set => setOfUIPanels = value; }


    // Start is called before the first frame update
    void Start()
    {
        _bestScore = PlayerPrefs.GetInt("HighScore", 0);
        _bestText.text = "Best: " + _bestScore;

        _scoreText.text = "Score: 0";

        setOfUIPanels.pauseAnimator = setOfUIPanels.pausePanel.GetComponent<Animator>();
        setOfUIPanels.pauseAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int score)
    {
        _score = score;
        ScoreText.text = "Score: " + score; 

    }

    public void CheckForBestScore()
    {
        if (_score > _bestScore)
        {
            _bestScore = _score;
            PlayerPrefs.SetInt("HighScore", _bestScore);
            _bestText.text = "Best: " + _bestScore;
        }
    }

    public void UpdateLivesDisplay(int lives)
    {
        _livesDisplay.sprite = _lifeSprites[lives];

        if(lives < 1)
        {
            GameOverSequence();
        }
    }

    public void GameOverSequence()
    {        
        setOfUIPanels.gameOverPanel.SetActive(true);
        StartCoroutine(GameOverFlickerRoutine());
        
        GameManager.instance.GameOver();
    }

    public void ResetSequence()
    {
        _gameOverText.gameObject.SetActive(false);
        _restartText.gameObject.SetActive(false);
        UpdateLivesDisplay(3);
        StopCoroutine(GameOverFlickerRoutine());
    }

    IEnumerator GameOverFlickerRoutine()
    {
        while(true)
        {
            _gameOverText.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            _gameOverText.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        _flipflop = !_flipflop;
    }

    public void SetPauseMenu(bool flipflop)
    {
        setOfUIPanels.pausePanel.SetActive(flipflop);
        setOfUIPanels.pauseAnimator.SetBool("isPaused", flipflop);        
    }
}
