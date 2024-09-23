using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private Enemy _enemyInfo;
    // Start is called before the first frame update
    void Start()
    {
        _enemyInfo.SubscribeToAction(AnimationController);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void AnimationController(Enemy.STATE state)
    {
        if (state == Enemy.STATE.IDLE)
        {

            _anim.SetBool("Run", false);

        }

        else if (state == Enemy.STATE.CHASING)
        {
            
            _anim.SetBool("Run", true);
           
        }
         else if (state == Enemy.STATE.DEATH)
        {
            
            _anim.SetBool("Death", true);
           
        }
        else if (state == Enemy.STATE.ATTACK)
        {
            _anim.SetTrigger("Attack"); 
        }
        else if (state == Enemy.STATE.HIT)
        {
            _anim.SetTrigger("Hit");
        }
       

    }
}
