using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent nav;
    Transform Player;
    [SerializeField] float TimeRepeating,TimeToShoot, DistanceToStop,DistanceToShoot,VelShoot;
    float Distance;
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform Spawn1, Spawn2;
    [SerializeField] GameObject[] PowerUps;
    [SerializeField] int ChangeToSpawnPowerUp;
void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("Destination", 0, TimeRepeating);
        InvokeRepeating("Atack", 0, TimeToShoot);

    }

    void Update()
    {
        Distance = Vector3.Distance(transform.position, Player.position);
        transform.LookAt(Player);
    }
    void Destination()
    {
        if (Distance > DistanceToStop) nav.SetDestination(Player.position);
        else nav.SetDestination(transform.position);
    }
    void Atack()
    {
        if (Distance < DistanceToShoot)
        {
            GameObject Bl1 = Instantiate(Bullet, Spawn1);
            GameObject Bl2 = Instantiate(Bullet, Spawn2);
            Bl1.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * Time.deltaTime * VelShoot);
            Bl2.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * Time.deltaTime * VelShoot);
            Destroy(Bl1, 10);
            Destroy(Bl2, 10);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            int ChanceToPowerUp = Random.Range(0, ChangeToSpawnPowerUp);
            if(ChanceToPowerUp== 1)
            {
                int RandoPower= Random.Range(0,PowerUps.Length);
                Vector3 i = transform.position + new Vector3(0,1,0);
                Instantiate(PowerUps[RandoPower], i,Quaternion.identity);
            }
            Destroy(other);
            Destroy(gameObject);
        }
    }
}
