using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCheck : MonoBehaviour
{
    /***************************************************
    * 설명
        CharMove 모듈의 IsJump를 변경시키는 모듈이다.
        점프를 했는지 안했는지에 따라 가능한 JumpCount가 있다.
            JumpCount는 IsJump에 의존적이다.
            
    * 클래스 구성
        * 멤버 변수
            1. AcceptTagList
                타입 : string array
                설명 : 점프가 가능한 발판 리스트
        * 메소드
            1. OnTriggerEnter2D
                설명 : 
                    1. 현재 밟고 있는 바닥을 인식하고,
                    2. AcceptTagList의 점프가 가능한 발판 리스트를 가져와 비교한다
                    3. AcceptTagList의 리스트와 일치하면 IsJump를 초기화해 의존적인 JumpCount횟수를 증가시킨다.
    ***************************************************/
    string[] AcceptTagList =new string[]{"Ground" , "PassingPlatform"};
    public GameObject Character;
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        string curColTag = collision.gameObject.tag;
        foreach (var E in AcceptTagList){
            if (curColTag == E)
            {
                Debug.Log("�ϴ�");
                Character.GetComponent<CharMove>().IsJump = false;
                Character.GetComponent<CharMove>().JumpCount = 1;
            }
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
