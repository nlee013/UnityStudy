using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public enum eTypeBGM
    {
        STAGE1 = 0,
        STAGE2,

    }

    public enum eTypeEffect
    {
        BUTTON =0,
        FIRE,
        ZOMBIE_DIE
    }

    [SerializeField] AudioClip[] _bmgClips;
    [SerializeField] AudioClip[] _effectClips;

    static SoundManager _uniqueInstance;
    AudioSource _bgmPlayer;

    List<AudioSource> _ltEffectPlayers;

    public static SoundManager _instance
    {
        get
        {
            return _uniqueInstance;
        }
    }

    private void Awake()
    {
        _uniqueInstance = this;
        _bgmPlayer = GetComponent<AudioSource>();
        _ltEffectPlayers = new List<AudioSource>();
    }

    void Start()
    {
        
    }


    void LateUpdate()
    {
        foreach (AudioSource item in _ltEffectPlayers)
        {
            if (item.isPlaying == false)
            {
                _ltEffectPlayers.Remove(item);
                Destroy(item.gameObject);
            }
        }
    }

    public void PlayBGM(eTypeBGM type, float volum = 1.0f, bool loop = true)
    {
        _bgmPlayer.clip = _bmgClips[(int)type]; // 클립 넣기
        _bgmPlayer.volume = volum;
        _bgmPlayer.loop = loop;

        _bgmPlayer.Play();
    }

    public void PlayEffect(eTypeEffect type, float volum = 1.0f, bool loop = false)
    {
        GameObject go = new GameObject("EffectSound"); // 빈 게임오브젝트 만듦
        go.transform.SetParent(transform); // SoundManager 하위에 붙음
       
        AudioSource AS = go.AddComponent<AudioSource>();
        AS.clip = _effectClips[(int)type];
        AS.volume = volum;
        AS.loop = loop;

        AS.Play();

        _ltEffectPlayers.Add(AS);
    }

    public void PlayEffect(GameObject obj, eTypeEffect type, float volum = 1.0f, bool loop = false)
    {
        GameObject go = new GameObject("EffectSound");
        go.transform.SetParent(obj.transform);
        go.transform.localPosition = Vector3.zero;

        AudioSource AS = go.AddComponent<AudioSource>();
        AS.clip = _effectClips[(int)type];
        AS.volume = volum;
        AS.loop = loop;

        AS.Play();

        _ltEffectPlayers.Add(AS);
    }
}
