using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType02 : EnemyBaseClass
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        FiringSystem();
    }

    protected new void FiringSystem()
    {
        if (Time.time > _canFire)
        {
            _fireRate = Random.Range(1f, 2f);
            _canFire = Time.time + _fireRate;
            GameObject[] enemylasers = { Instantiate(_laserPrefab, _laserCannon01.transform.position, Quaternion.identity),
                                         Instantiate(_laserPrefab, _laserCannon02.transform.position, Quaternion.identity) };

            enemylasers[0].GetComponent<Projectile>().SetEnemyLaser();
            enemylasers[1].GetComponent<Projectile>().SetEnemyLaser();
        };
    }
}
