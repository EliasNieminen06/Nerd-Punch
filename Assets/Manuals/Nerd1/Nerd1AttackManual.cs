using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Nerd1AttackManual : MonoBehaviour
{
    private bool enemyOnRange = false;
    private float knockbackForce = 5;
    private float jumpForce = 2;
    private GameObject enemy;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && enemyOnRange)
        {
            enemy.GetComponent<Nerd2MovementManual>().Attacked();
            Debug.Log("Enemy is in range and S is pressed");
            Vector2 direction = (enemy.transform.position - this.gameObject.transform.position).normalized;
            enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(direction.x * knockbackForce, 0), ForceMode2D.Impulse);
            enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected: Unknown " + collision.gameObject.name);
        if (collision.gameObject.tag == "Nerd")
        {
            Debug.Log("Collision detected: Nerd");
            enemyOnRange = true;
            enemy = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Nerd")
        {
            enemyOnRange = false;
        }
    }
}
