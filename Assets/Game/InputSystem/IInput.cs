using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInput 
{
    public string ActionMapName { get; }
    public void Update();
}
