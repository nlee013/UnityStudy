using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float attackAmount = 35.0f;

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Monster")
        {
            BulletSpawner bulletmonster = other.GetComponent<BulletSpawner>();

            if(bulletmonster != null)
            {
                bulletmonster.GetDamage(attackAmount);
            }
        }

        Destroy(gameObject);
    }

}
