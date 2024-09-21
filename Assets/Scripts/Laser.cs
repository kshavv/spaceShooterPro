using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    //speed variable
    private float _laserSpeed = 8.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //translate laser up
        Vector3 laserDirection = new Vector3(0, 1, 0);
        transform.Translate(laserDirection * _laserSpeed * Time.deltaTime);

        //destroy the laser once its off screen
        if (transform.position.y >= 7.1f)
        {
            Destroy(this.gameObject); //we can also destroy an object after a certain time
        }
    }
}
