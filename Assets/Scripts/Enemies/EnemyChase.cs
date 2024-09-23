using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    [SerializeField] private Enemy _enemyInfo;
    [SerializeField] private GameObject _Target;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {


    }
    public GameObject GetTarget()
    {
        return _Target;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 7 && _Target == null)
        {
            _Target = other.gameObject;
            _enemyInfo.StateChange(Enemy.STATE.CHASING);
        }
    }

    public float GetDistance()
    {
        float _targetDistance = 1000000;
        if (_Target != null)
        {
            _targetDistance = Vector2.Distance(transform.position, _Target.transform.position);
        }
        return _targetDistance;
    }
}
