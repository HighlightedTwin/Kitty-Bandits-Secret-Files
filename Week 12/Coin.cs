using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour

{
    public float lifeTime = 5f; //The amount of seconds the coin has
    public CoinCollect playerCoinCollect;

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(DestroyCoin), lifeTime);
    }
    void DestroyCoin()
    {
        if (playerCoinCollect != null)
        {
            playerCoinCollect.SpawnNewCoin();
        }
        // Destroys the Coin
        Destroy(gameObject);
    }

}
