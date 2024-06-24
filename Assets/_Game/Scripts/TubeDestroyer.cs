using System;
using UnityEngine;

public class TubeDestroyer : MonoBehaviour
{
    public event Action<Tube> DestroyPrepeared;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent.TryGetComponent(out Tube tube))
            DestroyPrepeared?.Invoke(tube);
    }
}
