using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionsHandler : MonoBehaviour
{
    [SerializeField] float blinkInterval = 0.1f;
    
    const float timeToWaitAfterSafe = 0.2f;
    SpriteRenderer sr;
    Collider2D col;
    List<Collider2D> activeTriggers = new List<Collider2D>();
    bool obstaclesOff;
    bool safeToEnableColliders;
    float passedTimeSinceBlink;
    float passedTimeSinceSafe;
    int totalContacts;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<PolygonCollider2D>();
    }

    void Update()
    {
        if (activeTriggers.Count == 0)
        {
            passedTimeSinceSafe += Time.deltaTime;
            if (passedTimeSinceSafe >= timeToWaitAfterSafe)
            {
                safeToEnableColliders = true;
            }
        }
        else
        {
            passedTimeSinceSafe = 0f;
            safeToEnableColliders = false;
        }
        if (obstaclesOff)
        {
            passedTimeSinceBlink += Time.deltaTime;
            if (passedTimeSinceBlink >= blinkInterval)
            {
                passedTimeSinceBlink = 0f;
                ChangeBlinkState();
            }
        }
        else
        {
            sr.color = Color.white;
        }
    }

    void ChangeBlinkState()
    {
        sr.color = sr.color == Color.white ? new Color(1f, 1f, 1f, 0.5f) : Color.white;
    }
    
    void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.gameObject.layer == 12 && safeToEnableColliders)
        {
            PlayerStatsController.instance.RemoveLife();
            StartCoroutine(DisableObstaclesFor(2f));
        }
        else if (_other.gameObject.layer == 11 && !activeTriggers.Contains(_other))
        {
            activeTriggers.Add(_other);
        }
    }

    void OnTriggerExit2D(Collider2D _other)
    {
        if (_other.gameObject.layer == 11)
        {
            activeTriggers.Remove(_other);
        }
    }

    IEnumerator DisableObstaclesFor(float _duration)
    {
        obstaclesOff = true;
        ObstaclesController.instance.DisableAllObstacles();
        yield return new WaitForSeconds(_duration);
        while (!safeToEnableColliders)
        {
            yield return new WaitForEndOfFrame();
        }
        obstaclesOff = false;
        ObstaclesController.instance.EnableAllObstacles();
    }
}
