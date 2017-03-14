using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEnemies : MonoBehaviour
{

    public List<GameObject> ls_enemies;
    public bool SetEnemiesActive = false;
    // Use this for initialization
    void Start()
    {
        GetEnemies();
    }
    void GetEnemies()
    {
        ls_enemies = new List<GameObject>();
        GameObject clone = GameObject.FindGameObjectWithTag("ls_enemies");
        Transform[] enemies = clone.GetComponentsInChildren<Transform>();
        foreach (Transform E in enemies)
        {
            if (E != null && E.gameObject != null)
            {
                ls_enemies.Add(E.gameObject);
                E.gameObject.SetActive(false);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (SetEnemiesActive == true)
        {
            for (int i = 0; i < ls_enemies.Count; i++)
            {
                ls_enemies[i].SetActive(true);
            }
        }
        if (SetEnemiesActive == false)
        {
            for (int i = 0; i < ls_enemies.Count; i++)
            {
                ls_enemies[i].SetActive(false);
            }
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
