using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 10f; //총알 스피드
    float lifeTime = 3; //날아가는동안 N초가 지나면 삭제
    Vector2 target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject); //총알 삭제
        }

        if (collision.gameObject.name == "Character")
        {
            GameObject.Find("GameManager").SendMessage("GetHit");
            Destroy(gameObject); //총알 삭제
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
        //비동기적 life타임 지나면 삭제
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        //진행 방향으로 나아가기
    }
}
