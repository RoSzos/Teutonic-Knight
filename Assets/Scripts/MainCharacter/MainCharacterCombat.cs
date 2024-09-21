using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterCombat : MonoBehaviour
{
    [SerializeField] MainCharacterInfo _mainInfo;

    [SerializeField] MainCharacterMovement _mainMove;

    private bool _canRoll = true;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Roll();
    }
    void Roll()
    {
        if (_canRoll && Input.GetKeyDown(KeyCode.Space) && _mainMove._movementDirection.magnitude > 0 && _mainInfo.GetCurrentState() != MainCharacterInfo.STATE.ROLL)
        {
            StartCoroutine(RollTimer());


        }
    }
    IEnumerator RollTimer()
    {
        float timer = _mainInfo._invecibilityTime;
        float cooldown = _mainInfo._rollCooldown;
        _canRoll = false;
        _mainMove.ChangeMovementBool(false);
        _mainInfo.StateChange(MainCharacterInfo.STATE.ROLL);
        while (timer > 0)
        {
            transform.Translate(_mainMove._movementDirection * Time.deltaTime * _mainInfo._rollSpeed);
            timer -= Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        _mainMove.ChangeMovementBool(true);
        while (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        _canRoll = true;


    }
}
