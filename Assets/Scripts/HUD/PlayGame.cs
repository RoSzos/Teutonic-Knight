using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{

    [SerializeField] private Button _playButton;
    // Start is called before the first frame update
    void Start()
    {
        _playButton.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnClick()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
