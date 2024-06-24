using UnityEngine;

public class TubeMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _direction = Vector3.left;

    public void Move()
    {
        transform.position += _direction * _speed * Time.fixedDeltaTime;
    }
}
