using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMeterial_Checker : MonoBehaviour
{
    private string stepOnTag;
    void OnTriggerStay2D(Collider2D other)
    {
        stepOnTag = other.gameObject.tag;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        stepOnTag ="none";
    }
    void Start()
    {
        stepOnTag = "";
    }
    // Update is called once per frame
    string GetCurrentStepMeterial(){
        return stepOnTag;
    }
}