using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MovementProvider : MonoBehaviour
{
    public float speed = 1.0f; // 이동속도
    public float gravityMultiplier = 1.0f; // 중력에 영향을 받는 경우를 처리
    public List<XRController> controllers = null; // 컨트롤러 리스트(상황에 따라서 1혹은 n개가 설정될 수 있음)
    private CharacterController characterController = null; // VR Rig의 캐릭터 컨트롤러
    private GameObject head = null; // 카메라의 헤드 위치

    private void Awake() // 스크립트 실행시 한번 호출
    {
        // 캐릭터 컨트롤러 할당 및 카메라 위치 설정
        characterController = GetComponent<CharacterController>();
        head = GetComponent<XRRig>().cameraGameObject; // 헤드에 플레이어 카메라 계속 따라다니기
    }

    void Start()
    {
        PositionController(); // 초기 설정을 처리
    }

    void Update()
    {
        PositionController(); // 현재 위치에 맞게 위치를 설정함
        CheckForInput();
        ApplyGraity();
    }

    void PositionController()
    {
        
        float headHeight = Mathf.Clamp(head.transform.localPosition.y, 1, 2); // 부드러운 이동을 위해서 값을 보간해줌
        characterController.height = headHeight; //

        // 새로운 센터 위치를 얻어옴
        Vector3 newCenter = Vector3.zero;
        newCenter.x = head.transform.localPosition.x;
        newCenter.z = head.transform.localPosition.z;

        characterController.center = newCenter;
    }

    void CheckForInput()
    {
        // 설정된 컨트롤러 중에서 인풋 입력이 있다면 이동 처리 함
        foreach(XRController controller in controllers)
        {
            if(controller.enableInputActions)
            {
                CheckForMovement(controller.inputDevice);
            }
        }
    }

    void CheckForMovement(InputDevice device)
    {
        // 레버는 Primary2DAxis 값으로 읽어 들일수 있음
        if(device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 position)) // 2D값(position)이 나옴
        {
            StartMove(position);
        }
    }

    void StartMove(Vector2 position)
    {
        // 이동을 위한 방향을 설정
        Vector3 direction = new Vector3(position.x, 0, position.y); // y 축은 영향 받지 않음
        Vector3 headRotation = new Vector3(0, head.transform.eulerAngles.y, 0); // 머리의 회전 방향을 적용

        direction = Quaternion.Euler(headRotation) * direction;

        Vector3 movement = direction * speed;
        characterController.Move(movement * Time.deltaTime);
    }

    void ApplyGraity()
    {
        // 밑으로 떨어지는 경우 중력을 적용
        Vector3 gravity = new Vector3(0, Physics.gravity.y * gravityMultiplier, 0);
        gravity.y *= Time.deltaTime;

        characterController.Move(gravity * Time.deltaTime);
    }
}
