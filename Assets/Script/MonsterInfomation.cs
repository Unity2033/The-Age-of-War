using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterInfomation : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject, 5);
        }
    }

    private void OnDestroy() // 게임 오브젝트가 파괴되었을 때 호출되는 함수입니다. 
    {
        
    }
}
