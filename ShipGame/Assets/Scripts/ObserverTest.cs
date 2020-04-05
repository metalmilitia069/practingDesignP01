using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverTest : MonoBehaviour, ObserverInterTest
{
    public string location;
    public bool alert = false;
    public string notifications;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Update(ObservedTest observed)
    {
        if(this.location == observed.location)
        {
            this.alert = true;
            this.notifications = "Attention: Enemy Nearby!!!!";
        }
        else
        {
            this.alert = false;
            this.notifications = "No Enemy Here! Go to Sleep!";
        }

        SendAlerts();
    }

    public void SendAlerts()
    {
        if (alert)
        {
            //Debug.Log("Alert: " + notifications + " Agents in " + this.location);
        }
        else
        {
            //Debug.Log(notifications);
        }
    }
}
