using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManual : MonoBehaviour
{
    [SerializeField] private GameObject Nerd1;
    [SerializeField] private GameObject Nerd2;
    private Vector3 middlePos;

    private void Update()
    {
        middlePos = new Vector3((Nerd1.transform.position.x + Nerd2.transform.position.x) / 2, (Nerd1.transform.position.y + Nerd2.transform.position.y) / 2, -10);

        this.gameObject.transform.position = middlePos;
    }
}
