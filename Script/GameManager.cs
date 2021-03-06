using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text lifeText;
    public Text dashText;
    public int life = 3;    //��༺ ������ ���� private���� �ٲ� ���� ��

    public void RestartGame()   //���� ����� �޼ҵ�
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    /******************************************************
    * 게임 매니저의 역할은 다음과 같다
    * 1. : 게임의 시작과 종료
    * 2. : 디버깅 UI 텍스트 조절
    * 3. : 캐릭터의 Life Data를 저장한다.
    ******************************************************/
    public void GetHit()
    {
        life--;
        lifeText.text = "Life: " + life;
    }

    public void DashCoolOn()
    {
        dashText.text = "�뽬 ��Ÿ��: On";
    }

    public void DashCoolOff()
    {
        dashText.text = "�뽬 ��Ÿ��: Off";
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        if (life == 0)	//���� ����� 0�̸�
        {
            RestartGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }
}
