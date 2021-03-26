using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleObj : MonoBehaviour
{
    int _limitDamge;

    // Start is called before the first frame update
    void Start()
    {
        _limitDamge = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("Hit" + _limitDamge);
        _limitDamge--;
        if(_limitDamge <= 0)
        {
            Destroy(gameObject);
        }
    }
}
