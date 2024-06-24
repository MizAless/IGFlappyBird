using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Player))]
public class PlayerAnimator : MonoBehaviour
{
    private const string FlyTrigger = "Fly";

    private Animator _animator;
    private Player _player;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _player.Jumped += Fly;
    }

    private void OnDisable()
    {
        _player.Jumped -= Fly;
    }

    private void Fly()
    {
        _animator.SetTrigger(FlyTrigger);
    }
}
