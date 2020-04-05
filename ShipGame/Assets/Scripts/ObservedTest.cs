using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObservedTest : MonoBehaviour, ObservedInterTest
{
    [SerializeField]
    public string location;

    [SerializeField]
    public float[] mozo;// = 5;

    [SerializeField]
    public GameObject[] observerArray;

    [SerializeField]
    private List<ObserverInterTest> ObserversList;// = new List<ObserverInterTest>();
    

    // Start is called before the first frame update
    void Start()
    {        
        ObserversList = new List<ObserverInterTest>();

        foreach (var item in observerArray)
        {            
            ObserverInterTest observerItem = item.GetComponent<ObserverInterTest>();            
            AddObservers(observerItem);
        }
    }

    // Update is called once per frame
    void Update()
    {
        NotifyObservers();
    }

    public void AddObservers(ObserverInterTest observer)
    {
        ObserversList.Add(observer);
        Debug.Log("mozo");
    }

    public void DeleteObserver(ObserverInterTest observer)
    {
        ObserversList.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var item in ObserversList)
        {
            item.Update(this);
        }
    }

    
}
