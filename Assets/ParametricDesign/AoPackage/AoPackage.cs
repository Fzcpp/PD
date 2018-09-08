using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AoPackage
{
    public string Name;

    public object GetRef()
    {
        return this;
    }
}