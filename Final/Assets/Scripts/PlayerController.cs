using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public GameManager manager; //게임 매니저 생성
    Rigidbody2D Player; //플레이어 물리엔진 선언
    Animator animator; // 에니메이션을 위해 
    float jumpForce = 800.0f;//뛰는 힘 
    float walkForce = 50.0f;
    float maxWalkSpeed = 3.0f;
    public int playerEnergy=5;
    public Image imgComp;

    public AudioClip jump;
    public AudioClip dotori;
    public AudioClip hurt;
   
    AudioSource audioSrc;

    public int money=0;
    public int boom=0; //우측 상단에 도토리 획득 표시를 위한 충돌 횟수 체크용

 
    //충돌 출돌 충돌
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "dotori")
        {
            boom++; // 횟수 +
            manager.UpdatedotoriIcon(boom); //충돌 횟수를 매개변수로 전달
            money++; // 도토리 획득 개수 + 

            audioSrc.PlayOneShot(dotori, 0.5f);

            Destroy(collision.gameObject); //부딪힌 물체 제거
            if(playerEnergy<5) //플레이어 체력이 5보다 작다면
            {
                playerEnergy += 1; //체력 증가
                imgComp.fillAmount += 0.2f; //우측상단체력바 게이지 상승

            }


        }
        else if(collision.gameObject.name=="Market") //Market과 충돌했다면
        {
            if(money>=5) //도토리를 5개이상 모아서 도착했다면
            {
                SceneManager.LoadScene("Market"); //Market으로 씬이동
            }
            else if(money < 5) //도토리를 5개이상 모으지 못했다면
            {
                SceneManager.LoadScene("Fail"); //Fail로 씬이동

            }
          
        }

        else if(collision.name.Contains("Monster")) //Monster와 충돌했다면
        {
            playerEnergy -= 1; //플레이어 에너지 1 감소
            imgComp.fillAmount -= 0.2f; //우측상단 체력바 게이지 감소
            animator.SetTrigger("HurtTrigger"); //충돌시 애니메이션 재생
            audioSrc.PlayOneShot(hurt, 0.5f); // 부딪혔을 때 음향효과 추가 
        }

    }

    void Start()
    {
        audioSrc = GetComponent<AudioSource>(); //음향효과 오브젝트 제어를 위해 추가 

        this.Player = GetComponent<Rigidbody2D>(); //플레이어 오브젝트 제어를 위해 추가 
        this.animator = GetComponent<Animator>();//애니메이션 오브젝트 제어를 위해 추가 
      
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y<-20)//만약 y좌표가 -20아래로 떨어진다면(추락시)
        {
            SceneManager.LoadScene("GameOver"); //게임오버로 씬전환
        }
        //점프하기
        if(Input.GetKeyDown(KeyCode.Space)&&this.Player.velocity.y==0) // 스페이스바 점프 구현, 계속 점프 불가능하게 y좌표 0일때만 가능
        {
           animator.SetTrigger("JumpTrigger"); //애니메이션 트리거를 이용해 점프 애니메이션 재생
           Player.AddForce(transform.up * this.jumpForce); //위로 이동 (점프)
           audioSrc.PlayOneShot(jump, 0.5f); // 음향효과 추가
        }

        //좌우이동
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1; 
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        float speedx = Mathf.Abs(this.Player.velocity.x);

        //스피드 제한
        if(speedx<this.maxWalkSpeed)
        {
            this.Player.AddForce(transform.right * key * this.walkForce);

        }
        //좌우 반전
        if(key!=0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        //플레이어 속도에 맞춰 애니메이션 속도를 바꾼다
        if (this.Player.velocity.y == 0) //점프 안 할때
        {
            this.animator.speed = speedx / 2.0f;
        }
        else//점프할때
        {
            this.animator.speed = 1.0f;
        }


        if (playerEnergy == 0) //플레이어의 에너지가 0일 때
        {
            SceneManager.LoadScene("GameOver"); //게임오버로 씬전환
        }
    }

   
}
