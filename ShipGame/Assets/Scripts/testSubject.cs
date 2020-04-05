using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSubject : MonoBehaviour
{
    //public GameObject Subscriber;

    // Start is called before the first frame update
    void Start()
    {
        //Subscriber.GetComponent<testSubscriber>()
        testSubscriber.onEnemyHit += Damage;
    }

   void Damage(Color color)
    {
        transform.GetComponent<Renderer>().material.color = color;
    }

    private void OnDisable()
    {
        testSubscriber.onEnemyHit -= Damage;
    }
}
