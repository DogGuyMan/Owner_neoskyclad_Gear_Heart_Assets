using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour
{ 
	public bool IsJump = false; //���߿� �ִ���?
		bool IsDash;
	public bool DashCool = true; //대쉬 Is on 쿨타임

	public float maxSpeed = 5;		//ĳ���� �ִ뽺�ǵ�
	public float maxJump = 2f;		//���� �ִ� ����
	public float JumpCount = 1; //���� ���� Ƚ��
	public float JumpSpeed = 2f;

	public float MoveSpeed = 0.5f;

	public float DashSpeed;		//인스펙터에서 입력
	public float DashTimer;		//인스펙터에서 입력
	public float DashCoolTime;	//인스펙터에서 입력

	float CurrentDashTimer;
	float DashDirection = 1;
	float CurrentDashCoolTime;
	bool DEBUG = false;
	Rigidbody2D rigid;
	GameObject Character;		//스크립트 적용 대상은 Character
	float CharY;            //�����ϱ� �� ����
	
	/*************************************************************
	* 캐릭터의 음직임은 다음과 같다
	* 1. 방향키 
		A : 좌측 
		D : 우측
		(space) : 점프
	* 2. 마우스 
		우클릭 : 
	*************************************************************/
    void Awake()
	{
		Character = gameObject;
		rigid = GetComponent<Rigidbody2D>();
	}

    void Update()   //�ܹ����� ������ Update
	{
		if(DEBUG) {Debug.Log(CharY);}
		if (Input.GetKeyUp(KeyCode.A)){rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.25f, rigid.velocity.y);}
		if (Input.GetKeyUp(KeyCode.D)){rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.25f, rigid.velocity.y);}
		
		if (Input.GetKeyDown(KeyCode.Space)){
			CharY = transform.position.y + maxJump;
			if (JumpCount == 0){IsJump = false;}
			else
			{
				rigid.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
				IsJump = true;
				JumpCount--;
			}	
		}

		if (Input.GetMouseButtonDown(1) && DashCool == true)
		{
			DashCool = false;
			GameObject.Find("GameManager").SendMessage("DashCoolOff");
			//디버깅 UI 텍스트 ON/OFF 목적
			IsDash = true;
			CurrentDashTimer = DashTimer;
			CurrentDashCoolTime = DashCoolTime;

			rigid.velocity = Vector2.zero;

		}

		if (IsDash)
		{
			rigid.velocity = transform.right * DashDirection * DashSpeed;

			CurrentDashTimer -= Time.deltaTime;

			if (CurrentDashTimer <= 0)
			{
				IsDash = false;
			}

		}

		if (!DashCool)
		{
			CurrentDashCoolTime -= Time.deltaTime;
			if (CurrentDashCoolTime <= 0)
			{
				DashCool = true;
				GameObject.Find("GameManager").SendMessage("DashCoolOn");
			}
		}

	}
	
	void FixedUpdate()	//���������� ������ ������ FixedUpdate (1�ʿ� 50��)
	{
		if (Input.GetKey(KeyCode.A)){rigid.AddForce(Vector2.left * MoveSpeed, ForceMode2D.Impulse); DashDirection = -1;}
		if (Input.GetKey(KeyCode.D)){rigid.AddForce(Vector2.right * MoveSpeed, ForceMode2D.Impulse);DashDirection = 1; }

		if (Input.GetKey(KeyCode.Space)) {
			if (IsJump) {
				rigid.AddForce(Vector2.up * JumpSpeed, ForceMode2D.Impulse);
				if (transform.position.y >= CharY){IsJump = false;}
			}
		}

		if (!IsDash)
		{
			if (rigid.velocity.x > maxSpeed) {rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y)};
			else if (rigid.velocity.x < maxSpeed * (-1)){rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y)};
		}
	}
}
