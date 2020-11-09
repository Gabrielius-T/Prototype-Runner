using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public IEnumerator Shake (float _duration, float _magnitude)
    {
        Vector3 _originalPos = transform.localPosition;

        float _elapsed = 0.0f;

        while (_elapsed < _duration)
        {
            float _x = Random.Range(-1f, 1f) * _magnitude;
            float _y = Random.Range(-1f, 1f) * _magnitude;

            transform.localPosition = new Vector3(_x, _y, _originalPos.z);

            _elapsed += Time.deltaTime;

            yield return null;
        }
        transform.localPosition = _originalPos;
    }
}
