using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemySpriteLayerManager : MonoBehaviour
{
    [SerializeField] private SortingGroup _sprite;
    // Start is called before the first frame update
    void Start()
    {
        _sprite = this.gameObject.GetComponent<SortingGroup>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ChangeSortingOrder(true);
    }
    public bool GetPositiveStatus()
    {
        if (_sprite.sortingOrder > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void ChangeSortingOrder(bool value)
    {
        /*  if (!GetPositiveStatus() && value)

              _sprite.sortingOrder = _sprite.sortingOrder += 20;

          else if (GetPositiveStatus() && !value)

              _sprite.sortingOrder = _sprite.sortingOrder -= 20;
  */
        _sprite.sortingOrder = Mathf.FloorToInt(transform.position.y * -1);

    }
}
