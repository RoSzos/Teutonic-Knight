using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAnimation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private GameObject _releasedButtonText;
    [SerializeField] private GameObject _clickedButtonText;
    public void OnPointerDown(PointerEventData eventData)
    {
        _releasedButtonText.SetActive(false);
        _clickedButtonText.SetActive(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _releasedButtonText.SetActive(true);
        _clickedButtonText.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
