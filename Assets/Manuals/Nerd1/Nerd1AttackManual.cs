using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nerd1AttackManual : MonoBehaviour
{
    private GameObject enemy;
    private bool enemyInRange;

    private void Update()
    {
        if (Input.GetKey(KeyCode.T) && enemyInRange)
        {
            enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(20, 5);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Nerd")
        {
            enemy = collision.gameObject;
            enemyInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Nerd")
        {
            enemyInRange = false;
        }
    }
}
