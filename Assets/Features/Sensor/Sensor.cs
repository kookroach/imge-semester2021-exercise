using System;
using UnityEngine;

public abstract class Sensor : MonoBehaviour
{
    public IObservable<EventArgs> SensorTriggered;
}
