using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _rotateSpeed = 5.0f;
    [SerializeField]
    private GameObject _explosionPrefab;

    private SpawnManager _spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        //_spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        RotateAsteroid();
    }

    public void RotateAsteroid()
    {
        transform.Rotate(Vector3.forward * _rotateSpeed * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Laser")
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            //_spawnManager.StartSpawning();
            SpawnManager.instance.StartSpawning();
            Destroy(this.gameObject, 0.25f);
            
        }
    }

}
