using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterCombat : MonoBehaviour
{
    [SerializeField] MainCharacterInfo _mainInfo;

    [SerializeField] MainCharacterMovement _mainMove;
    [SerializeField] GameObject _attack_A_HitBox;
    [SerializeField] GameObject _KickHitBox;
    [SerializeField] GameObject _attack_C_HitBox;
    private bool _canRoll = true;
    private bool _canAttack = true;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Roll();
        Attack_A();
    }
    void Roll()
    {
        if (_canRoll && Input.GetKeyDown(KeyCode.Space) && _mainMove._movementDirection.magnitude > 0 && _mainInfo.GetCurrentState() != MainCharacterInfo.STATE.ROLL)
        {
            StartCoroutine(RollTimer());


        }
    }

    void Attack_A()
    {
        if (Input.GetKeyDown(KeyCode.J) && _mainInfo.GetCurrentState() != MainCharacterInfo.STATE.ATTACK_A && _canAttack)
        {
            _mainInfo.StateChange(MainCharacterInfo.STATE.ATTACK_A);
            _mainMove.ChangeMovementBool(false);
            StartCoroutine(AttackATimer());
            _canAttack = false;
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
    IEnumerator AttackATimer()
    {
        yield return new WaitForSeconds(0.25f);
        _attack_A_HitBox.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        _attack_A_HitBox.SetActive(false);
        float timer = 0.3f;
        bool recoverMovement = true;
        while (timer > 0)
        {
            if (Input.GetKeyDown(KeyCode.J) && _mainInfo.GetCurrentState() == MainCharacterInfo.STATE.ATTACK_A)
            {
                _mainInfo.StateChange(MainCharacterInfo.STATE.KICK);
                _mainMove.ChangeMovementBool(false);
                recoverMovement = false;
                StartCoroutine(KickTimer());
            }
            timer -= Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        if (recoverMovement)
        {
            _canAttack = true;
            _mainMove.ChangeMovementBool(true);
        }



    }
    IEnumerator KickTimer()
    {
        yield return new WaitForSeconds(0.15f);
        _KickHitBox.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        _KickHitBox.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        float timer = 0.2f;
        bool recoverMovement = true;
        while (timer > 0)
        {
            if (Input.GetKeyDown(KeyCode.J) && _mainInfo.GetCurrentState() == MainCharacterInfo.STATE.KICK)
            {
                _mainInfo.StateChange(MainCharacterInfo.STATE.ATTACK_C);
                _mainMove.ChangeMovementBool(false);
                recoverMovement = false;
                StartCoroutine(AtackCTimer());
            }
            timer -= Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        if (recoverMovement)
        {
            _canAttack = true;
            _mainMove.ChangeMovementBool(true);
        }
    }
    IEnumerator AtackCTimer()
    {
        yield return new WaitForSeconds(0.4f);
        _attack_C_HitBox.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        _attack_C_HitBox.SetActive(false);
        yield return new WaitForSeconds(0.3f);

        bool recoverMovement = true;

        if (recoverMovement)
        {
            _canAttack = true;
            _mainMove.ChangeMovementBool(true);
        }
    }
}
