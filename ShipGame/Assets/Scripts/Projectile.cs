using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float _laserSpeed = 8.0f;
    [SerializeField]
    private bool _isEnemyLaser = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
        if(!_isEnemyLaser)
        {
            MoveUp();
        }
        else
        {
            MoveDown();
        }
    }

    void MoveUp()
    {
        transform.Translate(Vector3.up * _laserSpeed * Time.deltaTime);

        if (transform.position.y >= 8.0f)
        {
            Destroy(this.gameObject);
        }
    }

    void MoveDown()
    {
        transform.Translate(Vector3.down * _laserSpeed * Time.deltaTime);

        if (transform.position.y < -8.0f)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetEnemyLaser()
    {
        _isEnemyLaser = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && _isEnemyLaser)
        {
            Player player = other.GetComponent<Player>();

            if(player != null)
            {
                player.Damage();
                Destroy(this.gameObject);
            }
        }
    }
}
