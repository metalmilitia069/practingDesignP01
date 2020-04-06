using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    private float _speedMultiplier = 2f;
    [SerializeField]
    private GameObject _singleLaserPrefab;
    [SerializeField]
    private GameObject _tripleLaserPrefab;
    [SerializeField]
    private GameObject _cannon01Position;
    [SerializeField]
    private float _fireRate = 0.15f;
    [SerializeField]
    private int _lives = 3;

    private SpawnManager _spawnManager;

    private float _canFire = -1f;
    private float _horizontalAxis = 0f;
    private float _verticalAxis = 0f;
    [SerializeField]
    private bool _isTripleShotEnabled = false;
    [SerializeField]
    private bool _isSpeedEnabled = false;
    [SerializeField]
    private bool _isShieldOn = false;

    [SerializeField]
    private int _score;

    
    [SerializeField]
    private AudioClip _laserAudioClip;

    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {        
        this.transform.position = new Vector3(0, 0, 0);       

        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _laserAudioClip;
    }

    // Update is called once per frame
    void Update()
    {
        this.CalculateMovement();

        if (Input.GetKey(KeyCode.Space) && Time.time > _canFire)
        {
            this.Fire();
        }

    }

    private void CalculateMovement()
    {
        _horizontalAxis = Input.GetAxis("Horizontal");
        _verticalAxis = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(_horizontalAxis, _verticalAxis, 0);
        if (!_isSpeedEnabled)
        {
            transform.Translate(direction * _speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(direction * _speedMultiplier * _speed * Time.deltaTime);
        }

        if (this.transform.position.x >= 11.10f)
        {
            this.transform.position = new Vector3(-11.10f, this.transform.position.y, this.transform.position.z);
        }
        else if (this.transform.position.x <= -11.15f)
        {
            this.transform.position = new Vector3(11.05f, this.transform.position.y, this.transform.position.z);
        }      

        this.transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.2f, 0), 0);
    }

    private void Fire()
    {        
         _canFire = Time.time + _fireRate;
        if (_isTripleShotEnabled)
        {
            Instantiate(_tripleLaserPrefab, _cannon01Position.transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(_singleLaserPrefab, _cannon01Position.transform.position, Quaternion.identity);
        }

        _audioSource.Play();
    }

    public void Damage()
    {
        if(_isShieldOn)
        {
            _isShieldOn = false;
            return;
        }
        _lives--;        

        UIManager.instance.UpdateLivesDisplay(_lives);

        if(_lives < 1)
        {
            //_spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

            //if(_spawnManager != null)
            //{
            //_spawnManager.OnPlayerDeath();
            SpawnManager.instance.OnPlayerDeath();
            //}
                       
            UIManager.instance.CheckForBestScore();

            Destroy(this.gameObject);
        }
    }

    public void EnableTripleShot()
    {
        _isTripleShotEnabled = true;
    }

    public void EnableSpeed()
    {
        _isSpeedEnabled = true;
        StartCoroutine(SpeedPowerDown());
    }

    IEnumerator SpeedPowerDown()
    {
        yield return new WaitForSeconds(5.0f);
        _isSpeedEnabled = false;
        StopCoroutine(SpeedPowerDown());
    }

    public void EnableShield()
    {
        _isShieldOn = true;
    }

    public void AddScore(int points)
    {
        _score += points;        
        UIManager.instance.UpdateScore(_score);
    }
}
