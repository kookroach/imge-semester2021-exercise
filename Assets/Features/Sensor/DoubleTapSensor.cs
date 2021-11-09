using System;
using UniRx;
using UniRx.Triggers;
using System.Linq;

public class DoubleTapSensor: Sensor
{
    private void Awake()
    {
        ObservablePointerDownTrigger trigger = this.gameObject.AddComponent<ObservablePointerDownTrigger>();

        SensorTriggered = trigger.OnPointerDownAsObservable()
            .Buffer(TimeSpan.FromMilliseconds(500))
            .Where(x => x.Count >= 2).FirstOrDefault()
            .Select(x => EventArgs.Empty);
    }
}

