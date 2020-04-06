using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseClass : MonoBehaviour
{
    [SerializeField]
    protected float _speed = 4.0f;

    private Player _player;

    [SerializeField]
    protected GameObject _laserCannon01;
    [SerializeField]
    protected GameObject _laserCannon02;
    [SerializeField]
    protected GameObject _laserPrefab;
    [SerializeField]
    protected float _fireRate = 3.0f;
    protected float _canFire = -1f;
    [SerializeField]
    protected int enemyWorthScore = 10;


    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        FiringSystem();
    }

    protected void FiringSystem()
    {
        if (Time.time > _canFire)
        {
            _fireRate = Random.Range(3f, 7f);
            _canFire = Time.time + _fireRate;
            GameObject[] enemylasers = { Instantiate(_laserPrefab, _laserCannon01.transform.position, Quaternion.identity),
                                         Instantiate(_laserPrefab, _laserCannon02.transform.position, Quaternion.identity) };

            enemylasers[0].GetComponent<Projectile>().SetEnemyLaser();
            enemylasers[1].GetComponent<Projectile>().SetEnemyLaser();
        };
    }

    protected void CalculateMovement()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -6.5f)
        {
            float randomX = Random.Range(-9, 9);
            transform.position = new Vector3(randomX, 7, 0);
        }
    }


    public delegate void PlayerGainScore(int score);
    public static event PlayerGainScore OnLaserHit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }

            Destroy(this.gameObject);
        }
        else if (other.tag == "Laser")
        {
            
            OnLaserHit(enemyWorthScore);

            //if (_player != null)
            //{
                
            //    //_player.AddScore(10);
            //}
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "BoundaryBox")
        {
            BoundaryBox bb = other.gameObject.GetComponent<BoundaryBox>();
            float randomX = Random.Range(bb.SpawnPointA.transform.position.x, bb.SpawnPointB.transform.position.x);
            transform.position = new Vector3(randomX, bb.SpawnPointA.transform.position.y, 0);
        }
    }





}
