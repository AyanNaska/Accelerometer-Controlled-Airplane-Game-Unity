using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] AsteroidPrefabs;
    float time;
    float timeDelay;

    void Start()
    {
        time = 0f;
        timeDelay = 30f;
        SpawnAsteroids(40);
    }
    void Update()
    {
        time = time + 1f * Time.deltaTime;

        if (time >= timeDelay)
        {
            time = 0f;
            SpawnAsteroids(40);
        }
        
    }
    private void SpawnAsteroids(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            var pos = new Vector3(this.transform.position.x +Random.Range(-3050, 3050), this.transform.position.y+Random.Range(-3050, 3050), this.transform.position.z+Random.Range(-3050, 3050));
            var chosenAsteroid = AsteroidPrefabs[Random.Range(0, AsteroidPrefabs.Length)];
            var asteroid = Instantiate(chosenAsteroid, pos, Quaternion.identity);
        }
    }
}


