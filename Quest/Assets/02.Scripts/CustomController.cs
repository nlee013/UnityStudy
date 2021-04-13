using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CustomController : MonoBehaviour // 퀘스트 + 다른 컨트롤러
{
    public InputDeviceCharacteristics characteristics;// 컨트롤러 사용을 위함 만들어진 함수를 가져옴
    [SerializeField]
    private List<GameObject> controllerModels; // 오큘러스 퀘스트 외에 터치나 바이브 Model을 가져오기 위한 리스트
    private GameObject controllerInstance; // 사용중인 컨트롤러 저장
    private InputDevice availableDevice; // 이용중인 디바이스

    public bool renderController; // Hand와 Controller 사이를 변경할 변수
    public GameObject handModel; // 핸드 모델
    private GameObject handinstance;  // 핸드 인스턴스

    private Animator handModelAnimator; // 핸드 모델 애니메이션 변수

    void Start()
    {
        TryInitialize();
    }

    void Update()
    {
        // 초기 오큘러스 퀘스트가 셋팅이 안된는 경우 다시 초기화해줌
        if (!availableDevice.isValid) 
        {
            TryInitialize();
            return;
        }

        if(renderController)
        {
            handinstance.SetActive(false);
            controllerInstance.SetActive(true);
        }
        else
        {
            handinstance.SetActive(true);
            controllerInstance.SetActive(false);
            UpdateHandAnimation(); // 핸드 애니메이션은 여기서만 수행
        }
    }

    private void TryInitialize() // 시작시 동기화할 함수
    {
        List<InputDevice> devices = new List<InputDevice>(); // devices라는 리스트를 만들어서 

        InputDevices.GetDevicesWithCharacteristics(characteristics, devices); // 코드 상에서 저장된 devices 넣어줌

        foreach(var device in devices)
        {
            // 반복적으로 devices를 디바이스 이름과 현재 설정된 Characteristic을 디버그로드 해서 보여줌
            Debug.Log($"Available Device Name: {device.name}, Characteristic: {device.characteristics}");
        }

        if(devices.Count > 0) // 디바이스가 있으면
        {
            availableDevice = devices[0]; // 첫번째 디바이스를 availbleDevice에 넣어줌

            string name = "맴에 안들어";
            if ("Oculus Touch Controller - Left" == availableDevice.name)
            {
                name = "Oculus Quest Controller - Left";
            }
            else if ("Oculus Touch Controller - Right" == availableDevice.name)
            {
                name = "Oculus Quest Controller - Right";
            }

            // currentControllerMode에 넣어준 컨트롤러 모델에 controller함수를 만들어서
            // 컨트롤러 이름이 availableDevice에 저장된 이름과 같은 것을 찾아서 넣어줌
            GameObject currentControllerModel = controllerModels.Find(controller => controller.name == availableDevice.name);
            
            if(currentControllerModel) // currentControllerModel이 있으면
            {
                controllerInstance = Instantiate(currentControllerModel, transform); // controllerInstance에 인스턴스해 줌
            }
            else
            {
                Debug.LogError("Didn't get suitable controller model"); // 에러보여줌
                controllerInstance = Instantiate(controllerModels[0], transform); // 첫번째 컨트롤러모델을 인스턴스해 줌
            }

            handinstance = Instantiate(handModel, transform); // 핸드 인스턴스 추가
            handModelAnimator = handinstance.GetComponent<Animator>();
            
        }
    }

    private void UpdateHandAnimation()
    {
        if(availableDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue)) // CommonUseages는 터치입력 또는 조이스틱 각 항목과 위치 및 회전값 추적기능
        {
            handModelAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handModelAnimator.SetFloat("Trigger", 0);
        }

        if (availableDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handModelAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handModelAnimator.SetFloat("Grip", 0);
        }
    }
}
