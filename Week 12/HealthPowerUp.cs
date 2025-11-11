using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    private PlayerController playerController;
    void Start()
    {
        playerController = GameObject.Find("PlayerController").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            PlayerController playercontroller = other.GetComponent<PlayerController>();
            {
                playercontroller.AddALife(); // Call a method on the player to add health
                Destroy(this.gameObject); // Destroy the power-up after collection
            }
        }
    }
}