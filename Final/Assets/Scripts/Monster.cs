using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Monster : MonoBehaviour
{
   
    void Update()
    {
        //몬스터가 위아래로 움직이도록 해주기 위해 x, z 좌표는 그대로 그리고 y 좌표는 pingpong을 이용
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, 5), transform.position.z);
     
    }
}
