using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;


    private void Awake ()
    {
        /* Mencari object dengan tag Player */
        player = GameObject.FindGameObjectWithTag ("Player").transform;

        /* Mendapatkan health dari player dan health object sendiri */
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        /* Mendapatkan komponen NavMeshAgent */
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
    }


    void Update ()
    {
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            /*Set tujuan ke posisi object player */
            nav.SetDestination (player.position);
        }
        else
        {
            /* NavMeshAgent di-nonaktifkan ketika Enemy mati atau Player mati */
            nav.enabled = false;
        }
    }
}
