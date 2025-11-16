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

    //Adding code for the random coin spawn 
    private float horizontalScreenSize;
    private float verticalScreenSize;

    //Starting Score
    private int score = 0;

    private void Start()
    {
        //Toast Code
        gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
        //End Toast Code

        horizontalScreenSize = gameManager.horizontalScreenSize;
        verticalScreenSize = gameManager.verticalScreenSize;
        //New Code changes 
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
        float randomX = Random.Range(-horizontalScreenSize, horizontalScreenSize);
        float randomY = Random.Range(-verticalScreenSize, verticalScreenSize);
        Vector3 randomPos = new Vector3(randomX, randomY, 0f);
        Instantiate(CoinPrefab, randomPos, Quaternion.identity);
    }
   
}
