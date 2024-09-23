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
    [SerializeField] protected internal float _damage;
    private float _maxLife;
    private STATE _currentState;
    public UnityAction<STATE> onStateChange;

    void Start()
    {
        _maxLife = _life;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public float GetMaxLife()
    {
        return _maxLife;
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
