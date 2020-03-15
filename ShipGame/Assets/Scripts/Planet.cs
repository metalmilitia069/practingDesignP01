using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField]
    private GameObject _innerLayer;
    [SerializeField]
    private GameObject _outerLayer;
    [SerializeField]
    private float _innerSpeed;
    [SerializeField]
    private float _outerSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _innerLayer.transform.Rotate(Vector3.forward * _innerSpeed * Time.deltaTime);
        _outerLayer.transform.Rotate(Vector3.forward * _outerSpeed * Time.deltaTime);
    }
}
