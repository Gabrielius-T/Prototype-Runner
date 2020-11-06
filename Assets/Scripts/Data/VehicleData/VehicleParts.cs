using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleParts
{
    [SerializeField]
    public List<string> boughtParts;
    [SerializeField]
    public int wheels;
    [SerializeField]
    public int decals;
    [SerializeField]
    public int spoilers;


    public VehicleParts(int _wheels, int _decals, int _spoilers)
    {
        wheels = _wheels;
        decals = _decals;
        spoilers = _spoilers;
    }
}
