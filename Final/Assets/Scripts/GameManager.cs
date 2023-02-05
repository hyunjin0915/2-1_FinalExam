using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image[] dotoriImage;

    public void UpdatedotoriIcon(int dotori)
    {
       //for문을 이용해 매개변수로 받은 충돌횟수만큼 도토리를 화면에 표시 
        for(int index=0;index<dotori;index++) //도토리를 얻으면 투명도를 1로 올려서 화면에 나타나도록 해주었다
        {
            dotoriImage[index].color = new Color(1, 1, 1, 1);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
