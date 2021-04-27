using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameObject EnemyPrefabs;
    [SerializeField] private float EnemySpeed = 5f;


    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(Vector3.down * EnemySpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);

        Destroy(gameObject);
    }
}
