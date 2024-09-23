using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected internal float _life;
    [SerializeField] protected internal float _runSpeed;
    [SerializeField] protected internal float _damage;

    [SerializeField] private STATE _currentState;
    public UnityAction<STATE> onStateChange;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StateChange(STATE value)
    {
        _currentState = value;
        onStateChange?.Invoke(_currentState);
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
    public void ReduceLife(float damage)
    {
        _life -= damage;
    }
    public enum STATE
    {
        IDLE,
        CHASING,
        ATTACK,
        HIT,
        DEATH
    }
}
