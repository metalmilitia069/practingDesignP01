using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _cannon01Position;
    [SerializeField]
    private float _fireRate = 0.15f;

    private float _canFire = -1f;
    private float _horizontalAxis = 0f;
    private float _verticalAxis = 0f;

    


    // Start is called before the first frame update
    void Start()
    {        
        this.transform.position = new Vector3(0, 0, 0);
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
        transform.Translate(direction * _speed * Time.deltaTime);

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
         Instantiate(_laserPrefab, _cannon01Position.transform.position, Quaternion.identity);        
    }
}
