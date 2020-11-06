using UnityEngine;

public class VehicleStats {
    [SerializeField]
    public float maxTorque;
    [SerializeField]
    public float maxSpeed;
    [SerializeField]
    public float acceleration;
    [SerializeField]
    public float deacceleration;
    [SerializeField]
    public float maxRotationSpeed;
    [SerializeField]
    public float fuel;
    [SerializeField]
    public int engineLevel;
    [SerializeField]
    public int tiresLevel;
    [SerializeField]
    public int suspensionLevel;

    public VehicleStats(float _maxSpeed, float _acceleration, float _deacceleration, float _maxTorque, float _maxRotationSpeed, float _fuel, int _engineLevel, int _tiresLevel, int _suspensionLevel)
    {
        this.maxSpeed = _maxSpeed;
        this.acceleration = _acceleration;
        this.deacceleration = _deacceleration;
        this.maxTorque = _maxTorque;
        this.maxRotationSpeed = _maxRotationSpeed;
        this.fuel = _fuel;
        this.engineLevel = _engineLevel;
        this.tiresLevel = _tiresLevel;
        this.suspensionLevel = _suspensionLevel;
    }
}
