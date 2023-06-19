using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrigger : MonoBehaviour, ITriggerable
{
    public event Action Triggered;

    private void Start() => Triggered?.Invoke();
}
