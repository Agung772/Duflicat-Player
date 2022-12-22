using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseEnemy : MonoBehaviour
{

    public int health;
    public float regen;
    public Text healthText;

    public int Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
            healthText.text = "" + health;

            if (Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Start()
    {
        Health = health;

        StartCoroutine(RegenHealth());
        IEnumerator RegenHealth()
        {
            yield return new WaitForSeconds(regen);
            Health++;
            StartCoroutine(RegenHealth());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Health--;
            Destroy(other.gameObject);
        }
    }
}
