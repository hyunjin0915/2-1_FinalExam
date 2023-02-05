using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Change : MonoBehaviour
{
     public void Hat() //버튼 눌렀을 때 도토리 회전
    {
        GameObject dotori = GameObject.Find("dotori");
        dotori.transform.Rotate(0, 0, 72);
        
    }
   
    public void TryAgain() //다시 시도 버튼, 게임 화면으로 씬전환
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void BacktoRoad() //게임화면으로 씬전환
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void BacktoMain() //맨 처음 메인화면으로 씬전환
    {
        SceneManager.LoadScene("Start");
    }
    public void HowtoPlay() //게임방법 화면으로씬전환
    {
        SceneManager.LoadScene("HowtoPlay");
    }
    public void Ending() //엔딩화면으로 씬전환
    {
        SceneManager.LoadScene("Ending");
    }
    public void Rain() //다음 스테이지 이동
    {
        SceneManager.LoadScene("Rain");
    }
}
