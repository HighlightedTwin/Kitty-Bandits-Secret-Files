using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public ParticleSystem EnemyDamage;
    public  void Kill()
    {
        if (EnemyDamage != null)
        {
            Instantiate(EnemyDamage, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
        
    }
}
