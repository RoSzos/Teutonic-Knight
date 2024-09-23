using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ExitGame : MonoBehaviour
{

    [SerializeField] private Button _exitButton;
    // Start is called before the first frame updat

    void Start()
    {
        _exitButton.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnClick()
    {
        Application.Quit();
    }
}
