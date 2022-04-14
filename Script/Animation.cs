using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    float lifeTime = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
        //파괴 애니메이션으로 추측
        //1.5f == 1.5 second
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
