using UnityEngine;

[RequireComponent(typeof(TubeMover))]
public class Tube : MonoBehaviour
{
    [SerializeField] private float _middleAreaHeight = 2f;

    [SerializeField] private Transform _upperTube;
    [SerializeField] private Transform _middleArea;
    [SerializeField] private Transform _lowerTube;

    [SerializeField] private float baseTubeHeight = 10f;

    private TubeMover _mover;

    private void OnValidate()
    {
        Vector3 tubeScale = _upperTube.localScale;
        Vector3 middleAreaScale = _middleArea.localScale;
        tubeScale.y = baseTubeHeight;
        middleAreaScale.y = _middleAreaHeight;
        _middleArea.localScale = middleAreaScale;
        _upperTube.localScale = tubeScale;
        _lowerTube.localScale = tubeScale;

        float tubesLocalPositionY = (baseTubeHeight + _middleArea.localScale.y) / 2;

        _middleArea.localPosition = Vector3.zero;
        _upperTube.localPosition = new Vector3(0, tubesLocalPositionY, 0);
        _lowerTube.localPosition = new Vector3(0, -tubesLocalPositionY, 0);
    }

    public void Init(Vector3 position)
    {
        transform.position = position;
    }

    private void Awake()
    {
        _mover = GetComponent<TubeMover>();
    }

    private void FixedUpdate()
    {
        _mover.Move();
    }
}
