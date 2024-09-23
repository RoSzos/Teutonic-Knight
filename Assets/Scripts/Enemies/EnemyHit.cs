using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHit : MonoBehaviour
{
    [SerializeField] private Enemy _enemyInfo;
    private MainCharacterInfo _mainInfo;
    private UnityAction<float> onHit;
    [SerializeField] private List<SpriteRenderer> _enemySprites;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SubscribeToAction(UnityAction<float> value)
    {
        onHit += value;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject != null)
            _mainInfo = other.gameObject.GetComponentInParent<MainCharacterInfo>();
        if (_mainInfo != null && _enemyInfo.GetCurrentState() != Enemy.STATE.DEATH)
        {
            _enemyInfo.StateChange(Enemy.STATE.HIT);
            _enemyInfo.ReduceLife(_mainInfo._damage);
            onHit?.Invoke(_enemyInfo._life);
            StartCoroutine(HitVisualization());
        }
    }
    IEnumerator HitVisualization()
    {
        if (_enemyInfo._life > 0)
        {
            foreach (var item in _enemySprites)
            {
                item.color = Color.red;

            }
            yield return new WaitForSeconds(0.2f);

            foreach (var item in _enemySprites)
            {
                item.color = Color.white;

            }
        }
        else
        {
            foreach (var item in _enemySprites)
            {
                item.enabled = false;

            }

            yield return new WaitForSeconds(0.1f);

            foreach (var item in _enemySprites)
            {
                item.enabled = true;

            }
            yield return new WaitForSeconds(0.1f);
            foreach (var item in _enemySprites)
            {
                item.enabled = false;

            }
            yield return new WaitForSeconds(0.1f);

            foreach (var item in _enemySprites)
            {
                item.enabled = true;

            }
            yield return new WaitForSeconds(0.1f);
            foreach (var item in _enemySprites)
            {
                item.enabled = false;

            }

            yield return new WaitForSeconds(0.1f);

            foreach (var item in _enemySprites)
            {
                item.enabled = true;

            }
        }

    }
}
