using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimationBools : MonoBehaviour {

    public string animationBoolName;

    public Animator Door;



    void OnTriggerEnter()
    {
        Door.SetBool(animationBoolName, true); 
    }

    void OnTriggerExit()
    {
        Door.SetBool(animationBoolName, false);
    }
}
