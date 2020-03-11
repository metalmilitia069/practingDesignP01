using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;

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

        //this.transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, ))

        //if (this.transform.position.y <= -3.2f)
        //{
        //    this.transform.position = new Vector3(this.transform.position.x, -3.2f, this.transform.position.z);
        //}
        //else if (this.transform.position.y >= 0)
        //{
        //    this.transform.position = new Vector3(this.transform.position.x, 0f, this.transform.position.z);
        //}

        this.transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.2f, 0), 0);
    }
}
