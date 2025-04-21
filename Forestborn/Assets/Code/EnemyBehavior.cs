using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public Transform player;
    public Transform patrolRoute;
    public List<Transform> locations;
    public int locationIndex = 0;
    public bool visionSight= false;
    private NavMeshAgent agent;
    private bool continueChase = false;
    [SerializeField] AudioClip[] hitSounds;

    private int _lives = 3;
    public int EnemyLives
    {

        get
        {
            return _lives;
        }

        private set
        {
            _lives = value;

            if (_lives == 0)
            {
                StartCoroutine(EnemyKilled());
            }
            else
            {
                int index = UnityEngine.Random.Range(0, hitSounds.Length);
                AudioClip hitNoise = hitSounds[index];
                GetComponent<AudioSource>().PlayOneShot(hitNoise);
            }
        }
    }

    IEnumerator EnemyKilled()
    {
        GetComponent<NavMeshAgent>().speed = 0;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);
        Debug.Log("Enemy down.");
        Destroy(this.gameObject);
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        InitializePatrolRoute();
        MoveToNextPatrolLocation();
    }
    void Update()
    {
        if (agent.remainingDistance < 0.2f && !agent.pathPending && !continueChase)
        {
            MoveToNextPatrolLocation();
        }
        if (continueChase && !agent.pathPending)
        {
            agent.destination = player.position;
        }
    }

    void InitializePatrolRoute()
    {
        foreach (Transform child in patrolRoute)
        {
            locations.Add(child);
        }
    }
    void MoveToNextPatrolLocation()
    {
        if (locations.Count == 0)
            return;
        agent.destination = locations[locationIndex].position;
        locationIndex = (locationIndex + 1) % locations.Count;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.name== "Player")
        {
            agent.destination = player.position;
            continueChase = true;
            Debug.Log("Player Detected - attack");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            agent.destination = player.position;
            EnemyLives -= 1;
            Debug.Log("Critical hit!");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.name== "Player")
        {
            continueChase = false;
            Debug.Log("Player out of range, resume patrol");
        }
    }
}
