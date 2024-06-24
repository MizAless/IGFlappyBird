using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private AnimationCurve _yAnimation;
    [SerializeField] private float _hight = 5f;
    [SerializeField] private float _jumpDuration = 0.6f;

    private Rigidbody2D _rigidbody2D;
    private Player _player;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _player.Jumped += Jump;
    }

    private void OnDisable()
    {
        _player.Jumped -= Jump;
    }

    public void Jump()
    {
        _rigidbody2D.velocity = Vector3.zero;
        StartCoroutine(JumpCoroutine());
    }

    private IEnumerator JumpCoroutine()
    {
        float expiredSeconds = 0;
        float progress = 0;
        float prevProgress = 0;

        float nextPosY = 0;

        var delay = new WaitForFixedUpdate();

        while (progress < 1)
        {
            expiredSeconds += Time.deltaTime;
            prevProgress = progress;
            progress = expiredSeconds / _jumpDuration;

            nextPosY = _yAnimation.Evaluate(progress) - _yAnimation.Evaluate(prevProgress);

            transform.position += new Vector3(0, nextPosY, 0) * _hight;

            yield return delay;
        }
    }
}
