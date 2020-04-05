using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallBack : MonoBehaviour
{
    //public delegate void OnMessageReceived();
    //public event OnMessageReceived onComplete;

    private void Start()
    {
        //OnMessageReceived test = WriteMessage;
        //test();
        //onComplete += WriteMessage;
        //onComplete();
    }

    void WriteMessage()
    {
        //Debug.Log("Message");
    }
}
