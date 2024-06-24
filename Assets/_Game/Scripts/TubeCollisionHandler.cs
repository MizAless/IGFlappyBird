using System;
using UnityEngine;

public class TubeCollisionHandler : MonoBehaviour
{
    public event Action Collected;

    public event Action TubeTouched;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<TubeCollectTrigger>(out _))
        {
            Collected?.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.parent.TryGetComponent<Tube>(out _))
        {
            TubeTouched?.Invoke();
        }
    }
}
