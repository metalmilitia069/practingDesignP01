using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
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
    [SerializeField]
    private GameManager _gameManager;

    private int _score;
    [SerializeField]
    private int _bestScore;


    private bool _flipflop = false;

    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score: 0";
        _gameOverText.gameObject.SetActive(false);

        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if(_gameManager == null)
        {
            Debug.Log("Gama MAnager is Null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int score)
    {
        _score = score;
        _scoreText.text = "Score: " + score; 

    }

    public void CheckForBestScore()
    {
        if (_score > _bestScore)
        {
            _bestScore = _score;
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
        _gameOverText.gameObject.SetActive(true);
        _restartText.gameObject.SetActive(true);
        StartCoroutine(GameOverFlickerRoutine());
        _gameManager.GameOver();
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
        //_pauseMenuPanel.SetActive(_flipflop);
    }
}
