using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {

    public GameObject m_bullet;
    public List<GameObject> Amo;
    public float Amount = 5f;
    public int MaxTimer = 10;
    private float UpdateTimer;

    void Start()
    {
        // instantiate bullets and add it to the amo list and also set it to false
        for (int i = 0; i < Amount; i++)
        {
            GameObject clone = Instantiate(m_bullet) as GameObject;
            clone.SetActive(false);
            Amo.Add(clone);
        }
    }
    public void GroundAttack(Transform Muzzel, Transform target)
    {
            RaycastHit hit;

            if (Physics.Raycast(Muzzel.position, -target.position, out hit))
            {

                GameObject r_player = hit.collider.gameObject;
                if (r_player.tag == "Player")
                {
                    for (int i = 0; i < Amo.Count; i++)
                    {
                        GameObject bullet = Amo[i];
                        if (!bullet.activeInHierarchy)
                        {
                            bullet.transform.position = Muzzel.position;
                            bullet.transform.rotation = Muzzel.rotation;
                            bullet.SetActive(true);
                            break;
                        }
                    }
                }
            }
        }
}

