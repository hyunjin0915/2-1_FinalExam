using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class PlayerController_2 : MonoBehaviour
{
    public int money = 0;
    public int Energy=5;
    public Image imgComp;

    //Rigidbody2D player;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ant")
        {
            Energy--; //충돌시 체력 감소
            imgComp.fillAmount -= 0.2f; //우측상단 체력바 게이지 감소

            Destroy(collision.gameObject); //충돌 후 오브젝트 삭제
        }
        else if (collision.gameObject.tag == "dotori")
        {
            money++; //도토리 획득 카운트
            Energy++; //도토리 획득시 체력 증가
            imgComp.fillAmount += 0.2f; //우측상단체력바 게이지 상승
            Destroy(collision.gameObject); //충돌 후 오브젝트 삭제
        }
    }

    void Start()
    {
     // player= GetComponent<Rigidbody2D>();
     

    }
    

    // Update is called once per frame
    void Update()
    {
        //방향키로 좌우 이동
        if (Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            transform.Translate(-3, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(3, 0, 0);
        }
        if(Energy==0) //에너지가 0이 되면
        {
            SceneManager.LoadScene("GameOver"); //GameOver 씬이동

        }
        if(money==10) //도토리를 10개 모으면
        {
            SceneManager.LoadScene("Ending"); //GameOver 씬이동

        }

    }
}
