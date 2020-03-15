using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;

    [SerializeField]
    private int _powerUpID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -1 * _speed * Time.deltaTime, 0);
        if (transform.position.y < -6.5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {            
            Player player = other.GetComponent<Player>();           

            switch(_powerUpID)
            {
                case 0:
                    player.EnableTripleShot();
                    break;
                case 1:
                    player.EnableSpeed();
                    break;
                case 2:
                    player.EnableShield();
                    break;
                default:
                    break;

            }

            Destroy(this.gameObject);
        }
    }
}
