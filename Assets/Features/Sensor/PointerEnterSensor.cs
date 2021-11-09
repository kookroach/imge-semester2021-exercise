using UniRx;
using UniRx.Triggers;

public class PointerEnterSensor : Sensor
{
    private void Awake()
    {
        ObservablePointerEnterTrigger trigger = this.gameObject.AddComponent<ObservablePointerEnterTrigger>();

        SensorTriggered = trigger.OnPointerEnterAsObservable()
            .Select(pointer => new SensorEventArgs(pointer));
    }
}

