using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCheck : MonoBehaviour
{
    string[] AcceptTagList =new string[]{"Ground"};
    public GameObject Character;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string curColTag = collision.gameObject.tag;
        foreach (var E in AcceptTagList){
            if (curColTag == E)
            {
                Debug.Log("���");
                Character.GetComponent<CharMove>().IsJump = false;
                break;
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
