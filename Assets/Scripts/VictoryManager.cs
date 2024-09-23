using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemies = new List<GameObject>();
    [SerializeField] private GameObject _victoryScreen;
    bool victoryAchieved = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (var item in _enemies)
        {
            if (item != null)
            {
                victoryAchieved = false;
                break;
            }
            else
                victoryAchieved = true;
        }
        if (victoryAchieved)
        {
            _victoryScreen.SetActive(true);
        }
    }
}
