using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDamage : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        EnemyHealth enemy = other.GetComponent<EnemyHealth>();

        if (enemy != null) 
        { 
            enemy.Kill();
        }
    }
}
