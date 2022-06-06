using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject CarEnemy;

    [SerializeField] float xMax, xMin, zMax, zMin, Y, Repeating, Init;

    void Start()
    {
        InvokeRepeating("Spawn", Init, Repeating);
        InvokeRepeating("Spawn", Init, Repeating);
    }

    private void Spawn()
    {
        float randomX = Random.Range(xMin, xMax);
        float randomz = Random.Range(zMin, zMax);
        Instantiate(CarEnemy, new Vector3(randomX, Y, randomz), Quaternion.identity);
    }
}