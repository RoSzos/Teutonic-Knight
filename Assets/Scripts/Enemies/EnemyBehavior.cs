using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private Enemy _enemyInfo;
    [SerializeField] private EnemyChase _enemyChase;
    [SerializeField] private EnemySpriteLayerManager _spriteLayersManager;
    [SerializeField] GameObject _attackHitBox;
    [SerializeField] EnemyHit _enemyHit;
    private bool _canAttack = true;
    private GameObject _target;
    [SerializeField] private float _minDistanceAllowed = 2;
    // Start is called before the first frame update
    void Start()
    {
        _enemyInfo.SubscribeToAction(OnHit);
        _enemyHit.SubscribeToAction(OnDamageTaken);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_enemyChase.GetDistance() < _minDistanceAllowed && _enemyInfo.GetCurrentState() != Enemy.STATE.ATTACK && _canAttack)
        {
            _enemyInfo.StateChange(Enemy.STATE.ATTACK);
        }

        switch (_enemyInfo.GetCurrentState())
        {
            case Enemy.STATE.IDLE:
                {

                    break;
                }
            case Enemy.STATE.CHASING:
                {
                    Chasing();
                    break;
                }
            case Enemy.STATE.ATTACK:
                {

                    Attacking();

                    break;
                }
            case Enemy.STATE.DEATH:
                {

                    break;
                }
        }
        SpriteLayerAjustment();
    }
    void OnDamageTaken(float life)
    {
        if (life <= 0)
        {
            _enemyInfo.StateChange(Enemy.STATE.DEATH);
            OnDeath();
        }

    }
    void OnDeath()
    {
        StopAllCoroutines();
        _attackHitBox.SetActive(false);
        StartCoroutine(DeathTimer());


    }
    void OnHit(Enemy.STATE value)
    {
        if (value == Enemy.STATE.HIT)
        {
            _canAttack = false;
            StopAllCoroutines();
            StartCoroutine(HitTimer());
        }

    }
    void SpriteLayerAjustment()
    {
       /* if (_target != null && transform.position.y < _target.transform.position.y)
        {
            _spriteLayersManager.ChangeSortingOrder(true);
        }
        if (_target != null && transform.position.y > _target.transform.position.y)
        {
            _spriteLayersManager.ChangeSortingOrder(false);
        }
        */
    }
    void Attacking()
    {
        if (_canAttack && _enemyInfo.GetCurrentState() != Enemy.STATE.HIT)
        {
            StartCoroutine(AttackTimer());
            _canAttack = false;
        }
    }
    void Chasing()
    {
        _target = _enemyChase.GetTarget();
        transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, _enemyInfo._runSpeed * Time.deltaTime);
        if (transform.position.x < _target.transform.position.x)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * 1, transform.localScale.y, transform.localScale.z);
        }
        else if (transform.position.x > _target.transform.position.x)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
        }

    }
    IEnumerator AttackTimer()
    {
        yield return new WaitForSeconds(0.25f);
        _attackHitBox.SetActive(true);
        yield return new WaitForSeconds(0.75f);
        _attackHitBox.SetActive(false);
        yield return new WaitForSeconds(0.75f);
        if (transform.position.x < _target.transform.position.x)
        {

            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * 1, transform.localScale.y, transform.localScale.z);
        }
        else if (transform.position.x > _target.transform.position.x)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
        }

        _enemyInfo.StateChange(Enemy.STATE.CHASING);
        _canAttack = true;
    }
    IEnumerator HitTimer()
    {
        if (transform.position.x < _target.transform.position.x)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * 1, transform.localScale.y, transform.localScale.z);
        }
        else if (transform.position.x > _target.transform.position.x)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
        }
        _enemyInfo.StateChange(Enemy.STATE.IDLE);
        yield return new WaitForSeconds(0.65f);
        _canAttack = true;
        if (_enemyChase.GetDistance() > _minDistanceAllowed)
        {
            _enemyInfo.StateChange(Enemy.STATE.CHASING);
        }

    }
    IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
