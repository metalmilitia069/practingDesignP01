using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSubscriber : MonoBehaviour
{
    public delegate void ChangeEnemyColor(Color col);
    public static event ChangeEnemyColor onEnemyHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (onEnemyHit != null)
            {
                onEnemyHit(Color.red);
            }
            else
            {
                Debug.Log("Not Subscribed!");
            }
        }
    }
}
