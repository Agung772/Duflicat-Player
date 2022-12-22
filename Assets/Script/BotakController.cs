using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotakController : MonoBehaviour
{
    public float moveSpeed;
    public GameObject playerPrefab;
    public Animator animator;
    public bool attBase, spawnReady;
    NavMeshAgent navMeshAgent;
    Transform baseEnemy;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (GameObject.FindGameObjectWithTag("BaseEnemy") != null)
        {
            baseEnemy = GameObject.FindGameObjectWithTag("BaseEnemy").transform;
        }
        
    }
    private void Start()
    {
        spawnReady = false;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (baseEnemy != null)
        {
            if (attBase)
            {
                navMeshAgent.SetDestination(baseEnemy.transform.position);
            }

            else
            {
                navMeshAgent.SetDestination(new Vector3(transform.position.x, transform.position.y, 50));
            }
        }

        else if (baseEnemy == null)
        {
            navMeshAgent.SetDestination(new Vector3(transform.position.x, transform.position.y, 50));
        }

        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SpawnReady"))
        {
            spawnReady = true;
        }

        if (spawnReady)
        {
            if (other.CompareTag("Duplicat2x"))
            {
                Instantiate(playerPrefab, transform.position + new Vector3(1, 0, 0), transform.rotation);
                Instantiate(playerPrefab, transform.position + new Vector3(-1, 0, 0), transform.rotation);

                Destroy(gameObject);
            }

            if (other.CompareTag("Duplicat3x"))
            {
                Instantiate(playerPrefab, transform.position + new Vector3(1.5f, 0, 0), transform.rotation);
                Instantiate(playerPrefab, transform.position + new Vector3(-1.5f, 0, 0), transform.rotation);
                Instantiate(playerPrefab, transform.position + new Vector3(0, 0, 0), transform.rotation);

                Destroy(gameObject);
            }

            if (other.CompareTag("Duplicat7x"))
            {

                for (int i = 0; i < 7; i++)
                {
                    Instantiate(playerPrefab, transform.position + new Vector3(-3f + (i * 1.5f), 0, 0), transform.rotation);
                }

                Destroy(gameObject);
            }

            if (other.CompareTag("Destroy"))
            {
                Destroy(gameObject);
            }

            if (other.CompareTag("AttBase"))
            {
                attBase = true;
            }


        }

    }
}
