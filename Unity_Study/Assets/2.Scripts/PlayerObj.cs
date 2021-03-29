using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj : MonoBehaviour
{
    [SerializeField] GameObject _prefabEffHitNor;
   
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(r, out hit))
            {
                GameObject go = Instantiate(_prefabEffHitNor);
                go.transform.position = hit.point;
                Destroy(go, 2);
            }
        }
    }
}
