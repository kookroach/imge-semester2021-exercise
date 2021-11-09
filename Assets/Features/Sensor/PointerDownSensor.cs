using UniRx;
using UniRx.Triggers;

public class PointerDownSensor : Sensor
{
    private void Awake()
    {
        ObservablePointerDownTrigger trigger = this.gameObject.AddComponent<ObservablePointerDownTrigger>();
        SensorTriggered = trigger.OnPointerDownAsObservable()
            .Select(pointer => new SensorEventArgs(pointer));
    }
}