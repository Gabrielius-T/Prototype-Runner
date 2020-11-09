using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CoinRotation : MonoBehaviour
{
    [SerializeField] List<Sprite> coins;
    [SerializeField] float spriteChangeFrequency = 0.1f;

    SpriteRenderer sr;
    float timeSinceSpriteChange;
    int currentIndex;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        ChangeSprite();
    }
    
    void Update()
    {
        timeSinceSpriteChange += Time.deltaTime;
        if (timeSinceSpriteChange >= spriteChangeFrequency)
        {
            ChangeSprite();
        }
    }

    void ChangeSprite()
    {
        currentIndex = currentIndex == coins.Count - 1 ? 0 : currentIndex + 1;
        sr.sprite = coins[currentIndex];
        timeSinceSpriteChange = 0f;
    }
}
