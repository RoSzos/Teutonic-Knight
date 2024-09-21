using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainCharacterAnimation : MonoBehaviour
{
    [SerializeField] private MainCharacterInfo _mainInfo;
    [SerializeField] private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _mainInfo.SubscribeToAction(AnimationController);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void AnimationController(MainCharacterInfo.STATE state)
    {
        if (state == MainCharacterInfo.STATE.IDLE)
        {
            _anim.SetBool("Walk", false);
            _anim.SetBool("Run", false);
        }
        else if (state == MainCharacterInfo.STATE.WALK)
        {
            _anim.SetBool("Walk", true);
            _anim.SetBool("Run", false);
        }
        else if (state == MainCharacterInfo.STATE.RUN)
        {
            _anim.SetBool("Walk", false);
            _anim.SetBool("Run", true);
        }

    }
}
