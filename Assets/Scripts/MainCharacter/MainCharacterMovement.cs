using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterMovement : MonoBehaviour
{
    [SerializeField] private MainCharacterInfo _mainInfo;
    [SerializeField] private bool _isRunning = false;
    public Vector2 _movementDirection;
    private bool _canMove = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_canMove && _mainInfo.GetCurrentState() != MainCharacterInfo.STATE.DEATH)
            Movement();
    }
    public void ChangeMovementBool(bool value)
    {
        _canMove = value;
    }
    void Movement()
    {
        _movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (Input.GetKeyDown(KeyCode.LeftShift))
            _isRunning = true;

        if (Input.GetKeyUp(KeyCode.LeftShift))
            _isRunning = false;

        if (_movementDirection.magnitude > 0)
        {
            if (_movementDirection.x > 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * 1, transform.localScale.y, transform.localScale.z);
            }
            else if (_movementDirection.x < 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
            }
            if (!_isRunning)
            {
                _mainInfo.StateChange(MainCharacterInfo.STATE.WALK);
                transform.Translate(_movementDirection * _mainInfo._walkSpeed * Time.deltaTime);
            }

            if (_isRunning)
            {
                _mainInfo.StateChange(MainCharacterInfo.STATE.RUN);
                transform.Translate(_movementDirection * _mainInfo._runSpeed * Time.deltaTime);
            }
        }
        else
        {
            _mainInfo.StateChange(MainCharacterInfo.STATE.IDLE);
        }


    }
}
