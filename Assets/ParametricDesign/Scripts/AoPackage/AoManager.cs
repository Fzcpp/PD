using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class AoManager
{

    public static readonly AoManager Instance = new AoManager();

    public IReactiveCollection<AoPackage> AoPackages = new ReactiveCollection<AoPackage>();

    public void AddAoPackage(AoPackage aoPackage)
    {

    }

    public void RemoveAoPackage(AoPackage aoPackage)
    {

    }

}