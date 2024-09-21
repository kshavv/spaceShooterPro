using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.GameLogic;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _enemySpeed = 3.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move the enemy down 4 metre/s
        Vector3 enemyDirection = new Vector3(0, -1.0f, 0);
        transform.Translate(enemyDirection * _enemySpeed * Time.deltaTime);

        //respawn the enemy at a random x pos if it goes below the screen
        if (transform.position.y <= -7.1f)
        {
            this.SpawnEnemy();
        }

    }

    private void SpawnEnemy()
    {
        //selecting a random x position in the range of -13 to 13
        float randomXPos = UnityEngine.Random.Range(-13.0f, 13.0f);
        transform.position = new Vector3(randomXPos, 7.2f, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if other is player 
        //damage the player
        //destroy us
        if (other.tag == "Player")
        {
            // the enemy is colliding with the player 
            //destroy the player
            Player player= other.transform.GetComponent<Player>();
            if(player != null)
            {
                player.Damage();
            }


        }

        //if other is laser 
        //destroy us
        //laser
        if (other.transform.tag == "Laser")
        {

            Destroy(other);
            Destroy(this.gameObject);
        }

        Debug.Log("hit: " + other.transform.name);
    }
}
