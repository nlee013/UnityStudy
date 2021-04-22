using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public float attackAmout = 20.0f;
    public AudioClip swordClip;
    AudioSource swordAudio;

    void Start()
    {
        swordAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag =="Monster")
        {
            BulletSpawner bulletmonster = other.GetComponent<BulletSpawner>();

            if(bulletmonster != null)
            {
                bulletmonster.GetDamage(attackAmout);
            }

            swordAudio.PlayOneShot(swordClip);
        }
        else if(other.tag == "Monster2")
        {
            MonsterCtrl alien = other.GetComponent<MonsterCtrl>();

            if(alien != null)
            {
                alien.GetDamage(attackAmout);
            }

            swordAudio.PlayOneShot(swordClip);
        }
    }
}
