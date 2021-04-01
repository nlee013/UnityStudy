using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj : MonoBehaviour
{
    [SerializeField] GameObject _prefabEffHitNor;

    int _maxHp;
    int _nowHp;

    bool _isDead;

    public bool _ISDATH // 데드 프로퍼티
    {
        get
        {
            return _isDead;    
        }
    }
   
    void Start()
    {
        _maxHp = _nowHp = 10;
        _isDead = false;
    }

    void Update()
    {
        if (_isDead)
            return;

        if(Input.GetButtonDown("Fire1"))
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            SoundManager._instance.PlayEffect(SoundManager.eTypeEffect.FIRE);

            if(Physics.Raycast(r, out hit))
            {
                GameObject go = Instantiate(_prefabEffHitNor);
                go.transform.position = hit.point;
                Destroy(go, 2);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Zombie"))
        {
            _nowHp--;
            
            if(_nowHp <= 0)
            {
                GetComponent<BoxCollider>().enabled = false;
                _isDead = true;
                SoundManager._instance.PlayEffect(gameObject, SoundManager.eTypeEffect.ZOMBIE_DIE);
            }
        }
    }
}
