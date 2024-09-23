using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MainCameraScript : MonoBehaviour
{
    [SerializeField] private float _maxYValue = 3f;
    [SerializeField] private float _minYValue = -3f;
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    private CinemachineFramingTransposer _framingCamera;

    // Start is called before the first frame update
    void Start()
    {
        _framingCamera = _virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DisableCameraMovement();
    }
    void DisableCameraMovement()
    {
        if (_framingCamera.FollowTarget.gameObject.transform.position.y > _maxYValue || _framingCamera.FollowTarget.gameObject.transform.position.y < _minYValue)
        {
            _framingCamera.m_DeadZoneHeight = 2;
        }
        else
        {
            StartCoroutine(SmoothTransition());
        }
    }
    IEnumerator SmoothTransition()
    {

        while (_framingCamera.m_DeadZoneHeight > 0)
        {
            _framingCamera.m_DeadZoneHeight -= 0.025f;
            yield return new WaitForFixedUpdate();
        }
    }
}
