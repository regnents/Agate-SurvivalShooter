using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float spawnTime = 20f;

    [SerializeField]
    MonoBehaviour factory;
    IFactory Factory { get { return factory as IFactory; } }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {
        int total = GameObject.FindGameObjectsWithTag("Power Up").Length;
        //Jika player telah mati atau sudah terdapat power up di game, power up tidak dibuat
        if ((playerHealth.currentHealth <= 0f) || (total >= 1))
        {
            return;
        }

        int spawnPowerUpTag = Random.Range(0, 2);
        //Membuat Power Up
        Factory.FactoryMethod(spawnPowerUpTag);
    }

}
