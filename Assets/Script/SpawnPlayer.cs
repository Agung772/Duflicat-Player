using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public float speedMove, force;
    bool cooldownSpawn = true;
    float x;
    public GameObject playerPrefab;

    void Update()
    {
        
        Move();
        Spawn();
    }

    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        x += horizontal * speedMove * Time.deltaTime;
        x = Mathf.Clamp(x, -12, 12);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    void Spawn()
    {
        if (Input.GetKeyDown(KeyCode.Space) && cooldownSpawn)
        {
            GameObject playerGO = Instantiate(playerPrefab, transform.position, transform.rotation);
            playerGO.GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);
            cooldownSpawn = false;

            StartCoroutine(SpawnCooldown());
            IEnumerator SpawnCooldown()
            {
                yield return new WaitForSeconds(0.1f);
                cooldownSpawn = true;

            }

        }
    }


}
