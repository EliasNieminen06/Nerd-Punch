using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NerdMovementManual : MonoBehaviour
{
    private GameObject nerd;
    private Rigidbody2D rb;

    private void Start()
    {
        nerd = GameObject.FindGameObjectWithTag("Nerd");
        rb = this.GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        var movem
    }
}

