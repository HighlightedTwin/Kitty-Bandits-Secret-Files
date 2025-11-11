using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CoinCollect : MonoBehaviour
{
    public GameObject CoinPrefab;
     // Toast's code
 private GameManager gameManager;
 // End of Toast's code

    //random places for coin to spawn
    public float minX = -3f;
    public float maxX = 6f;
    public float minY = -3f;
    public float maxY = 5f;

    //Starting Score
    private int score = 0;

    private void Start()
    {
        //Toast Code
        gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
        //End Toast Code
        SpawnNewCoin(); //Need a coin at the start of the game
    }
   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Coin"))
        {
            score++;
            Debug.Log("Score: "+ score); 

            // Toast's code
            gameManager.AddScore(1);
            // End of Toast's code

            //When player touches it
            Destroy(other.gameObject);

            //Spawn random coin 
            SpawnNewCoin();
        }

    }
    public void SpawnNewCoin()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector3 randomPos = new Vector3(randomX, randomY, 0f);
        Instantiate(CoinPrefab, randomPos, Quaternion.identity);
    }
   
}



