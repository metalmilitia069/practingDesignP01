using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ObservedInterTest
{
    void NotifyObservers();
    void AddObservers(ObserverInterTest observer);
    void DeleteObserver(ObserverInterTest observer);
}
