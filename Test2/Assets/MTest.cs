using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 서로 다른 오브젝트 5군데에 이동, 회전, 크기 변화, 보이은 상태
// 보이지 않는 상태, 색깔변화, 소리재생 등의 함수를 넣고
// 마우스를 누르면 5가지 행동을 동시에 할 수 있도록 
public class MTest : OperateTest
{
    
    public override void Action()
    {
        print("특정 행동");
    }
}

public class TTest : OperateTest
{
    public override void Action()
    {
        
    }
}
      
