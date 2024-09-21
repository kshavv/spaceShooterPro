 using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Assets.Scripts;
public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;

    private bool spawningState = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        SpawnRoutine();

    }
    //spawn a game object every 5 second 
    IEnumerator SpawnRoutine()
    {
        while(spawningState)
        {
            
            float randomXPos = UnityEngine.Random.Range(-10.0f, 10.0f);
            Vector3 enemySpawningPos = new Vector3(randomXPos, 7.0f, 0.0f);
            GameObject newEnemy = Instantiate(_enemyPrefab,enemySpawningPos,Quaternion.identity);

            newEnemy.transform.parent = _enemyContainer.transform;

            yield return new WaitForSeconds(5.0f); //waits 1 second (i.e the code after this will run after one second)
        }
    }
    

    public void OnPlayerDeath()
    {
        spawningState = false;
    }
}
