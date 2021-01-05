using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
   [SerializeField] GameObject enemyObject;
   [SerializeField] GameObject powerUpObject;

    [SerializeField] int startNumberOfEnemies = 1;
    float maxPos = 9f;
    // Use this for initialization
    void Start()
    {
        SpawnEnemies(startNumberOfEnemies);
        SpawnPowerUp();

    }

    // Update is called once per frame
    void Update()
    {
        var countEnemies = FindObjectsOfType<EnemyController>().Length;
        if (countEnemies <= 0)
        {
            startNumberOfEnemies++;
            SpawnEnemies(startNumberOfEnemies);
            SpawnPowerUp();
        }
    }
    void SpawnEnemies(int noEnemies)
    {
        for (int i = 0; i < noEnemies; i++)
        {
            Vector3 pos = GenerateSpawnPos();
            Instantiate(enemyObject, pos, enemyObject.transform.rotation);
        }
    }

    void SpawnPowerUp()
    {
        Vector3 pos = GenerateSpawnPos();
        Instantiate(powerUpObject, pos, powerUpObject.transform.rotation);
    }

    private Vector3 GenerateSpawnPos()
    {
        float xPos = Random.Range(-maxPos, maxPos);
        float zPos = Random.Range(-maxPos, maxPos);
        return new Vector3(xPos, 0, zPos);
    }
}
