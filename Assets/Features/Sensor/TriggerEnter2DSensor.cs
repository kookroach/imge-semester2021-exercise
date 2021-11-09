using System;
using UnityEngine;
using UniRx.Triggers;
using UniRx;

public class TriggerEnter2DSensor : Sensor
{
    private void Awake()
    {
        ObservableTrigger2DTrigger trigger = this.gameObject.AddComponent<ObservableTrigger2DTrigger>();
        SensorTriggered = trigger.OnTriggerEnter2DAsObservable()
            .Select(collider => EventArgs.Empty);
    }
}