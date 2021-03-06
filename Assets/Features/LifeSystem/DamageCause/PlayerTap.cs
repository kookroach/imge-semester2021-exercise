using System;
using UniRx;
using UnityEngine;

public class PlayerTap : DamageCause
{
    public DamageEffect damageEffect;
    
    [Header("VFX")]
    public GameObject damageVFX;
    private Camera _camera;

    public Sensor sensor;


    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Start()
    {
        sensor.SensorTriggered.Subscribe(DamageCauseSignalDetected);
    }

    public void DamageCauseSignalDetected(EventArgs args)
    {
        damageEffect.Trigger(this);
        
        if (args is SensorEventArgs && ((SensorEventArgs)args).associatedPointerPayload.position != null)
        {
            Vector3 pos = _camera.ScreenToWorldPoint(((SensorEventArgs)args).associatedPointerPayload.position);
            Instantiate(damageVFX, new Vector3(pos.x, pos.y, damageVFX.transform.position.z), Quaternion.identity);
        }
    }
}
