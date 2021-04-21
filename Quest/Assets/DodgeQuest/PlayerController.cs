using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float speed = 8f;

    public float hp = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        //playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void GetDamage(float amount)
    {
        hp -= amount;

        if(hp < 0)
        {
            Die();
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);

        FindObjectOfType<GameManger>().EndGame();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PUNCH")
        {
            GetDamage(10.0f);
        }
    }
}
