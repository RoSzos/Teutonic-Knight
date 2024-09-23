using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainCharacterHit : MonoBehaviour
{
    [SerializeField] private MainCharacterInfo _mainInfo;
    [SerializeField] Enemy _enemyInfo;
    [SerializeField] SpriteRenderer _mainChaSprite;
    public UnityAction<float> onHit;
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
        Debug.Log("hit");
        if (other.gameObject != null)
            _enemyInfo = other.gameObject.GetComponentInParent<Enemy>();
        if (_enemyInfo != null)
        {
            _mainInfo._life -= _enemyInfo._damage;
            onHit?.Invoke(_mainInfo._life);
            if (_mainInfo.GetCurrentState() != MainCharacterInfo.STATE.DEATH)
                StartCoroutine(HitVisualization());

        }

    }
    IEnumerator HitVisualization()
    {
        _mainChaSprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        _mainChaSprite.color = Color.white;
    }
}
