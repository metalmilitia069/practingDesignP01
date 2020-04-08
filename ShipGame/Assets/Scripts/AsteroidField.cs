using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidField : MonoBehaviour
{

    [SerializeField]
    protected float _speed01 = 5.0f;
    [SerializeField]
    protected float _speed02 = 5.0f;
    [SerializeField]
    protected GameObject _asteroidPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.up * _speed02 * Time.deltaTime); //(this.transform.position.x, this.transform.position.y * 1 * _speed02, this.transform.position.z) * Time.deltaTime);
        //this.transform.Rotate(new Vector3(1, 1, 1) * _speed01 * Time.deltaTime);
        _asteroidPrefab.transform.Rotate(new Vector3(1, 1, 1) * _speed01 * Time.deltaTime);
        //this.transform.rotation = Quaternion.Euler(Vector3.one * _speed01 * Time.deltaTime);
    }
}
