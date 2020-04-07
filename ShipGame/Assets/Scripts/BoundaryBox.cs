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

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Enemy")
    //    {
    //        Debug.Log("saiuuuuuuu");
    //    }
    //}

    public void moz()
    {

    }
}
