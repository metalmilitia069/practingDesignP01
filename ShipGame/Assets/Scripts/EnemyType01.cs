using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType01 : EnemyBaseClass
{

    protected int _sideDirection = 0;

    // Start is called before the first frame update
    void Start()
    {
        _sideDirection = Random.Range(-1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        FiringSystem();        
    }

    protected new void CalculateMovement()
    {
        //int mozo = Random.Range(-1, 2);

        Vector3 direction = new Vector3(_sideDirection, -1, 0);

        transform.Translate(direction * _speed * Time.deltaTime);//(Vector3.down * _speed * Time.deltaTime);


        //if (transform.position.y < -6.5f)
        //{
        //    float randomX = Random.Range(-9, 9);
        //    transform.position = new Vector3(randomX, 7, 0);
        //}


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
