using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryBox : MonoBehaviour
{

    [SerializeField]
    private GameObject _spawnPointA;
    [SerializeField]
    private GameObject _spawnPointB;

    public GameObject SpawnPointA { get => _spawnPointA; set => _spawnPointA = value; }
    public GameObject SpawnPointB { get => _spawnPointB; set => _spawnPointB = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {           
            EnemyBaseClass bb = other.gameObject.GetComponent<EnemyBaseClass>();
            float randomX = Random.Range(SpawnPointA.transform.position.x, SpawnPointB.transform.position.x);
            bb.transform.position = new Vector3(randomX, SpawnPointA.transform.position.y, 0);
        }
        if(other.tag == "Asteroid")
        {
            Destroy(other.gameObject);
        }
    }

    public void moz()
    {

    }
}
