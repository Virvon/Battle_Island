using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetBrokedTrigger : MonoBehaviour, ITriggerable
{
    [SerializeField] private Let _let;

    public event Action Triggered;

    private void OnEnable() => _let.Broked += Triggered;

    private void OnDisable() => _let.Broked -= Triggered;
}
