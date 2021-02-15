using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFactory : MonoBehaviour, IFactory
{
    [SerializeField]
    public GameObject[] powerUpPrefab;
    public Transform[] spawnPoints;

    public GameObject FactoryMethod(int tag)
    {
        GameObject powerUp = Instantiate(powerUpPrefab[tag],spawnPoints[0].position,spawnPoints[0].rotation);
        return powerUp;
    }
}
