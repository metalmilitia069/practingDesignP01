﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;

    private Player _player;

    [SerializeField]
    private GameObject _laserCannon01;
    [SerializeField]
    private GameObject _laserCannon02;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 3.0f;
    private float _canFire = -1f;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        if(Time.time > _canFire)
        {
            _fireRate = Random.Range(3f, 7f);
            _canFire = Time.time + _fireRate;
            GameObject[] enemylasers = { Instantiate(_laserPrefab, _laserCannon01.transform.position, Quaternion.identity),
                                         Instantiate(_laserPrefab, _laserCannon02.transform.position, Quaternion.identity) };

            enemylasers[0].GetComponent<Projectile>().SetEnemyLaser();
            enemylasers[1].GetComponent<Projectile>().SetEnemyLaser();
        };
    }

    void CalculateMovement()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -6.5f)
        {
            float randomX = Random.Range(-9, 9);
            transform.position = new Vector3(randomX, 7, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            if(player != null)
            {
                player.Damage();
            }
            
            Destroy(this.gameObject);
        }
        else if(other.tag == "Laser")
        {
            if (_player != null)
            {
                _player.AddScore(10);
            }
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
