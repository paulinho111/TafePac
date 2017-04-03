using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEnemies : MonoBehaviour
{

    public List<GameObject> ls_enemies;
    public bool SetEnemiesActive = false;
    public GameObject enemiesHolder;
    // Use this for initialization
    void Start()
    {
        enemiesHolder.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (SetEnemiesActive == true)
        {
            enemiesHolder.gameObject.SetActive(true);
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            SetEnemiesActive = true;
        }
    }
}
