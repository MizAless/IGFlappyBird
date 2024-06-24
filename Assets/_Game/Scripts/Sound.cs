using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] private AudioSource _collectSound;
    [SerializeField] private AudioSource _flySound;
    [SerializeField] private Player _player;
    [SerializeField] private TubeCollisionHandler _tubeCollisionHandler;

    private void OnEnable()
    {
        _player.Jumped += PlayFlySound;
        _tubeCollisionHandler.Collected += PlayCollectSound;
    }

    private void OnDisable()
    {
        _player.Jumped -= PlayFlySound;
        _tubeCollisionHandler.Collected -= PlayCollectSound;
    }

    public void PlayCollectSound()
    {
        _collectSound.Play();
    }
    public void PlayFlySound()
    {
        _flySound.Play();
    }
}
