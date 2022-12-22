using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedPlayer;
    bool spawnReady, attBase;
    public GameObject playerPrefab;
    public Transform baseEnemy;

    private void Awake()
    {
        if (GameObject.FindGameObjectWithTag("BaseEnemy") != null)
        {
            baseEnemy = GameObject.FindGameObjectWithTag("BaseEnemy").transform;
        }

        
    }
    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.2f);
        spawnReady = true;
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
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(baseEnemy.position.x, transform.position.y, baseEnemy.position.z), speedPlayer * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.forward * speedPlayer * Time.deltaTime);
            }
        }
        if (baseEnemy == null)
        {
            transform.Translate(Vector3.forward * speedPlayer * Time.deltaTime);
        }

        

        
    }

    private void OnTriggerExit(Collider other)
    {
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
