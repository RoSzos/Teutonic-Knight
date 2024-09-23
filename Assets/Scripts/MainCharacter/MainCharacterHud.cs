using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCharacterHud : MonoBehaviour
{
    [SerializeField] private MainCharacterHit _mainHit;
    [SerializeField] private MainCharacterInfo _mainInfo;
    [SerializeField] private Image _fillBar;
    // Start is called before the first frame update
    void Start()
    {
        _mainHit.SubscribeToAction(OnHit);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnHit(float life)
    {
        _fillBar.fillAmount = life / _mainInfo.GetMaxLife();
    }
}
