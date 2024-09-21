using Assets.Scripts.GameLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    //every game object we are creating will have its own script

    public class Player : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 4.5f;
        [SerializeField]
        private  GameObject _laserPrefab;

        private float laserSpawnCooldown = 0.5f;
        private float lastLaserSpawnTime;

        [SerializeField]
        private int _lives = 3;

        private SpawnManager _spawnManager;
        // Start is called before the first frame update
        void Start()
        {
            //take the current position = new pos (0,0,0)
            transform.position =  new Vector3 (0, 0, 0);
            _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
            if (_spawnManager == null )
            {
                Debug.Log("spawn manager is NULL\n");
            }
        }

        // Update is called once per frame
        void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 directions = new Vector3(horizontalInput, verticalInput, 0);
            transform.Translate(directions * _speed * Time.deltaTime);


            Vector3 laserSpawningPos = new Vector3(transform.position.x,transform.position.y+0.8f, transform.position.z);
            
            //creating the laser instance (shooting lasers)
            if(Input.GetKey(KeyCode.Space) && Time.time>laserSpawnCooldown + lastLaserSpawnTime)
            {
                Instantiate(_laserPrefab,laserSpawningPos,Quaternion.identity);
                lastLaserSpawnTime = Time.time;
            }


            /**
             *Unity’s Transform component is a reference type, 
             *meaning that when you pass it as a parameter (even to a static class), 
             *you are passing a reference to the original Transform object, not a copy.
             */
            //checking player bounds
            GameBound.DefinePlayerBound(transform);

        }
        public void Damage()
        {
            _lives--;

            if (_lives == 0)
            {
                //Communicate with the spawn manager when the player dies
                _spawnManager.OnPlayerDeath();
                Destroy(this.gameObject);
            }
        }
    }
    

}
