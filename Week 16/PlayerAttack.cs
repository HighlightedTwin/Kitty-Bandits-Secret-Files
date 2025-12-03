using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  public class PlayerAttack : MonoBehaviour
    {
        public float attackRange = 3f;
        public ParticleSystem EnemyDamage; // particles should be here
        bool attackUsed = false;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
            }
        }

        void Attack()
        {
            if (!attackUsed) return;
            attackUsed = true;

            EnemyDamage.Play();
        }
    }