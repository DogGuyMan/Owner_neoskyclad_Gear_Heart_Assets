using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderInverse : MonoBehaviour
{   
    PlatformEffector2D EffectorComponent;
    public float inverseTime;
    float timeCount = 0f;
    // Start is called before the first frame update
    bool inverseTrigger = false;
    public GameObject GroundSenSor;
    void Start()
    {
        EffectorComponent = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inverseTrigger == true){
            timeCount -= Time.deltaTime;
            if(timeCount < 0){
                inverseTrigger = false;
                EffectorComponent.rotationalOffset = 0f;
            }
        }
        else{
            if(Input.GetKeyDown(KeyCode.S)){
                EffectorComponent.rotationalOffset= 180f;
                inverseTrigger = true;
                timeCount = inverseTime;
            }
        }
    }
}
