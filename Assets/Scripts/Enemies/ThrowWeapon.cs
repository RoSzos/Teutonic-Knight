using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowWeapon : Enemy
{
    [SerializeField] private float _moveSpeed = 15;
    [SerializeField] private float _timeAlive = 4;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x < 0)
        {
            transform.Translate(Vector2.left * Time.deltaTime * _moveSpeed);
        }
        else if (transform.localScale.x > 0)
        {
            transform.Translate(Vector2.right * Time.deltaTime * _moveSpeed);
        }
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(_timeAlive);
        Destroy(gameObject);
    }
}
