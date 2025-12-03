using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class Chase : MonoBehaviour
{
    public Transform player;
    bool m_IsPlayerInRange;

    public NavMeshAgent agent;
    public AudioSource alert;
    private float coolDown = 2;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }

    void Update()
    {
        if (coolDown < 2)
        {
            coolDown += 1;
            Debug.Log(coolDown);
        }
        if (m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    agent.acceleration = 3f;
                    agent.speed = 6f;
                    if(coolDown == 2)
                    {
                        alert.Play();
                    }
                    
                    coolDown = 0;
                }
            }
        } else
        {
            agent.speed = 1.5f;
        }
    }

}