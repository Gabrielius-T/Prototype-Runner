using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] BoxCollider2D col;

    void OnTriggerEnter2D(Collider2D _other)
    {
        col.enabled = false;
    }

    void OnTriggerExit2D(Collider2D _other)
    {
        col.enabled = true;
    }
}
