using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform Player;

    void Start()
    {


    }

    void Update()
    {
        enemy.SetDestination(Player.position);

    }

}