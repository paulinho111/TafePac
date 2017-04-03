using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimationBools : MonoBehaviour {
    public Animator Door;

    void OnTriggerEnter(Collider col)
    {
        Door.SetBool("IsDoorOpen", true); 
    }

    void OnTriggerExit(Collider col)
    {
        Door.SetBool("IsDoorOpen", false);
    }
}
