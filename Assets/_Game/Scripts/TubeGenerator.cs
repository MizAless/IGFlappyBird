using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class TubesGenerator : MonoBehaviour
{
    [SerializeField] private TubeDestroyer _tubeDestroyer;

    [SerializeField] private Tube _tubePrefab;
    [SerializeField] private float _spawnCooldown = 2f;
    [SerializeField] private float _tubeYRangeOffset = 3;

    [SerializeField] private int _poolCapacity = 5;
    [SerializeField] private int _poolMaxSize = 5;

    private ObjectPool<Tube> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Tube>(
            createFunc: () => Instantiate(_tubePrefab),
            actionOnGet: (obj) => ActionOnGet(obj),
            actionOnRelease: (obj) => ActionOnRelease(obj),
            actionOnDestroy: (obj) => ActionOnDestroy(obj),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize
        );

        _tubeDestroyer.DestroyPrepeared += ReleaseTube;
    }

    private void Start()
    {
        StartCoroutine(Generating());
    }

    private void ActionOnGet(Tube tube)
    {
        tube.Init(GetRandomStartPosition());
        tube.gameObject.SetActive(true);
    }

    private void ActionOnRelease(Tube tube)
    {
        tube.gameObject.SetActive(false);
    }

    private void ActionOnDestroy(Tube tube)
    {
        Destroy(tube.gameObject);
    }

    private IEnumerator Generating()
    {
        var spawnDelay = new WaitForSeconds(_spawnCooldown);

        while (enabled)
        {
            Generate();
            yield return spawnDelay;
        }
    }

    private void Generate()
    {
        _pool.Get();
    }

    private Vector3 GetRandomStartPosition()
    {
        Vector3 randomPosition = transform.position;
        randomPosition.y = Random.Range(-_tubeYRangeOffset, _tubeYRangeOffset);

        return randomPosition;
    }

    private void ReleaseTube(Tube tube)
    {
        _pool.Release(tube);
    }
}
