using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("player"); //플레이어를 찾아 player에 넣어주기
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = this.player.transform.position; //playerPos에 플레이어 위치 저장
        transform.position = new Vector3(
            playerPos.x, playerPos.y, transform.position.z);
        //플레이어의 위치로 카메라 이동
    }
}
