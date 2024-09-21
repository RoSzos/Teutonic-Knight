using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class MainCharacterInfo : MonoBehaviour
{
    [SerializeField] protected internal float _life;
    [SerializeField] protected internal float _mana;
    [SerializeField] protected internal float _walkSpeed;
    [SerializeField] protected internal float _runSpeed;
    [SerializeField] protected internal float _invecibilityTime;
    [SerializeField] protected internal float _rollSpeed;
    [SerializeField] protected internal float _rollCooldown;
    private STATE _currentState;
    public UnityAction<STATE> onStateChange;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_currentState);
    }
    public void StateChange(STATE value)
    {
        _currentState = value;
        onStateChange.Invoke(_currentState);
    }
    public void SubscribeToAction(UnityAction<STATE> action)
    {
        onStateChange += action;
    }
    public void UnsubscribeToAction(UnityAction<STATE> action)
    {
        onStateChange -= action;
    }
    public STATE GetCurrentState()
    {
        return _currentState;
    }

    public enum STATE
    {
        IDLE,
        WALK,
        RUN,
        ATTACK_A,
        KICK,
        ATTACK_C,
        FIREBALL,
        ARROW,
        ROLL,
        DEATH,
        TAUNT
    }

}
