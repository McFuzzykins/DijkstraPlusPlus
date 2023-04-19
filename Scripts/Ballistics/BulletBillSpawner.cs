using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBillSpawner : MonoBehaviour
{
    public GameObject bulletBill;
    private List<GameObject> spawnedObjs = new List<GameObject>();

    public float shootFreq;
    private float lastSpawn = 0f;
    public float launchForce = 0f;

    public GameObject player;

    void Update()
    {
        if (Time.time > lastSpawn + shootFreq)
        {
            if (spawnedObjs.Count <= 3)
            {
                GameObject newBill = Instantiate(bulletBill, this.transform.position, Quaternion.identity);
                spawnedObjs.Add(newBill);
                lastSpawn = Time.time;
                

                FiringSolution fs = new FiringSolution();
                Nullable<Vector3> aimVector = fs.Calculate(transform.position, player.GetComponent<Transform>().position, launchForce, Physics.gravity);
                
                if (aimVector.HasValue)
                {
                    newBill.GetComponent<Rigidbody>().AddForce(aimVector.Value.normalized * launchForce, ForceMode.VelocityChange);
                }
                Debug.Log(spawnedObjs.Count);
            }
            else
            {
                for (int i = 0; i > spawnedObjs.Count; i++)
                {
                    Destroy(spawnedObjs[i]);
                    Debug.Log("Destroyed");
                }
            }
        }
    }
}
