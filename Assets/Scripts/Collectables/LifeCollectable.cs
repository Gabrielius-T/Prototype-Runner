using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class LifeCollectable : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D _collision)
    {
        PlayerStatsController.instance.AddLife();
        SoundsController.instance.PlayOneShot("Collect");
        Destroy(gameObject);
    }
}
