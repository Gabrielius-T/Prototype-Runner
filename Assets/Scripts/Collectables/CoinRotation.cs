using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    [SerializeField]
    private GameObject coin1;

    [SerializeField]
    private GameObject coin2;

    [SerializeField]
    private GameObject coin3;

    [SerializeField]
    private GameObject coin4;

    [SerializeField]
    private GameObject coin5;

    [SerializeField]
    private GameObject coin6;

    [SerializeField]
    private float rotationPace = 0.1f;

    private float time;

    // Update is called once per frame
    private void Update()
    {
        time += Time.deltaTime;
        if (time >= rotationPace)
        {
            if (coin1.activeSelf)
            {
                coin1.SetActive(false);
                coin3.SetActive(false);
                coin4.SetActive(false);
                coin5.SetActive(false);
                coin6.SetActive(false);
                coin2.SetActive(true);
            }
            else if (coin2.activeSelf)
            {
                coin1.SetActive(false);
                coin2.SetActive(false);
                coin4.SetActive(false);
                coin5.SetActive(false);
                coin6.SetActive(false);
                coin3.SetActive(true);
            }
            else if (coin3.activeSelf)
            {
                coin1.SetActive(false);
                coin2.SetActive(false);
                coin3.SetActive(false);
                coin5.SetActive(false);
                coin6.SetActive(false);
                coin4.SetActive(true);
            }
            else if (coin4.activeSelf)
            {
                coin1.SetActive(false);
                coin2.SetActive(false);
                coin3.SetActive(false);
                coin4.SetActive(false);
                coin6.SetActive(false);
                coin5.SetActive(true);
            }
            else if (coin5.activeSelf)
            {
                coin1.SetActive(false);
                coin2.SetActive(false);
                coin3.SetActive(false);
                coin4.SetActive(false);
                coin5.SetActive(false);
                coin6.SetActive(true);
            }
            else if (coin6.activeSelf)
            {
                coin2.SetActive(false);
                coin3.SetActive(false);
                coin4.SetActive(false);
                coin5.SetActive(false);
                coin6.SetActive(false);
                coin1.SetActive(true);
            }
            time = 0f;
        }
    }
}
