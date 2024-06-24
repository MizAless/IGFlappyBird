using System;
using UnityEngine;
using AppsFlyerSDK;
using System.Collections.Generic;

[RequireComponent(typeof(TubeCollisionHandler))]
[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(PlayerAnimator))]
public class Player : MonoBehaviour
{
    [SerializeField] private Score _score;

    private TubeCollisionHandler _tubeCollector;
    private Jumper _jumper;
    private PlayerAnimator _playerAnimator;

    public event Action Jumped;

    private void OnEnable()
    {
        _tubeCollector.Collected += _score.Add;
    }

    private void OnDisable()
    {
        _tubeCollector.Collected -= _score.Add;
    }

    private void Awake()
    {
        _tubeCollector = GetComponent<TubeCollisionHandler>();
        _jumper = GetComponent<Jumper>();
        _playerAnimator = GetComponent<PlayerAnimator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        Jumped?.Invoke();
    }
}
