using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    SpriteRenderer sr;
    BoxCollider2D col;
    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
    }
    
    public void Disable()
    {
        col.isTrigger = true;
        sr.color = new Color(1f, 1f, 1f, 0.5f);
    }
    
    public void Enable()
    {
        col.isTrigger = false;
        sr.color = Color.white;
    }
}
