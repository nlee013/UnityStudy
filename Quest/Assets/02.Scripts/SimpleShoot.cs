using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class SimpleShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // 총알 프리팹
    public GameObject casingPrefab; // 탄피 프리팹
    public GameObject muzzleFlashPrefab; // 총구 이팩트 효과
    public Transform barrelLocation; // 총구 위치
    public Transform casingExitLocation; // 탄피 배출 위치

    public float shotPower = 100f;

    public bool isGrab = false;

    public AudioClip fireClip; // 총 발사 사운드 클립
    AudioSource fireAudio; // 핸드건에 추가한 오디오소스 컴포넌트를 담을 변수

    public HandState currentGrab; // 현재 HandGun을 잡은 손을 표시할 변수

    private void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;

        fireAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GetComponent<Animator>().SetTrigger("Fire");
        }
    }

    public void GrabGun()
    {
        isGrab = true;
    }

    public void dropGun()
    {
        isGrab = false;
    }

    public void Shoot()
    {
        if (isGrab == true)
        {
            GameObject tempFlash;
            Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
            tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

            fireAudio.PlayOneShot(fireClip);
        }
       
    }

    void CasingRelease()
    {
        GameObject casing;
        casing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        casing.GetComponent<Rigidbody>().AddExplosionForce(550f,
            (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        casing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(10f, 1000f)), ForceMode.Impulse);
    }

    public void SteGraspState(HandState state)
    {
        currentGrab = state;
    }

    public void SetGraspNONE()
    {
        if (!GetComponent<XRGrabInteractable>().isSelected)
            currentGrab = HandState.NONE;
    }

    public void SetGraspLEFT()
    {
        currentGrab = HandState.LEFT;
    }

    public void SetGraspRIGHT()
    {
        currentGrab = HandState.RIGHT;
    }


}
