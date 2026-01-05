// CubePool.cs
using System.Collections.Generic;
using UnityEngine;

public class CubePool : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private int _initialPoolSize = 20;

    private Queue<GameObject> _pool = new Queue<GameObject>();
    private Transform _poolParent;

    private void Awake()
    {
        _poolParent = new GameObject("CubePool").transform;
        _poolParent.SetParent(transform);

        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < _initialPoolSize; i++)
        {
            CreateNewCube();
        }
    }

    private GameObject CreateNewCube()
    {
        var cube = Instantiate(_cubePrefab, _poolParent);
        cube.SetActive(false);
        _pool.Enqueue(cube);
        return cube;
    }

    public GameObject Get()
    {
        if (_pool.Count == 0)
            CreateNewCube();

        var cube = _pool.Dequeue();
        cube.SetActive(true);
        return cube;
    }

    public void Return(GameObject cube)
    {
        cube.SetActive(false);
        cube.transform.SetParent(_poolParent);
        _pool.Enqueue(cube);
    }

    public void ReturnWithDelay(GameObject cube, float delay)
    {
        StartCoroutine(ReturnCoroutine(cube, delay));
    }

    private System.Collections.IEnumerator ReturnCoroutine(GameObject cube, float delay)
    {
        yield return new WaitForSeconds(delay);
        Return(cube);
    }
}