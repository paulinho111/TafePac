using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulet : MonoBehaviour {
    public float m_speed = 30f;
    // Update is called once per frame
    void Update()
    {
        // makes the bullet move foward in a set of time 
        gameObject.transform.Translate(Vector3.forward * m_speed * Time.deltaTime);
    }
    /*void OnCollisionEnter(Collision col)
    {
        // if it hits something with the tag enviroment 
        // set the object to inactive
        GameObject Collision = col.gameObject;
        if (Collision.tag == "Enviroment")
        {
            gameObject.SetActive(false);
        }
    }*/
    void OnEnable()
    {
        Invoke("Destroy", 2f);
    }
    void OnDisable()
    {
        CancelInvoke();
    }
    void Destroy()
    {
        gameObject.SetActive(false);
    }
}
