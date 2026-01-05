using System;
using System.Collections;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Counter : MonoBehaviour
{
    [SerializeField] InputReader _inputReader;

    private bool _isRun = false;
    private int _count = 0;
    private float _interval = 0.5f;

    private Coroutine countingCoroutine;
    private WaitForSeconds _waitInterval;

    public event Action<int> CounterChanged;
    public int GetCount() => _count;
    public void SetCount(int value) => _count = value;

    private void Start()
    {
        _waitInterval = new WaitForSeconds(_interval);

        if (_inputReader != null)
        {
            _inputReader.MouseClicked += ToggleCounting;
        }
        else
        {
            Debug.LogError("InputReader не найден на сцене!");
        }

        CounterChanged?.Invoke(_count);
    }
    private void OnDisable()
    {
        if (countingCoroutine != null)
        {
            StopCoroutine(countingCoroutine);
            countingCoroutine = null;
            _isRun = false;
        }
    }

    private void OnDestroy()
    {
        if (_inputReader != null)
            _inputReader.MouseClicked -= ToggleCounting;
    }

    private IEnumerator CountCoroutine()
    {
        while (true)
        {
            yield return _waitInterval;
            _count++;
            CounterChanged?.Invoke(_count);
        }
    }

    private void ToggleCounting()
    {
        _isRun = !_isRun;

        if (_isRun && countingCoroutine == null)
        {
            countingCoroutine = StartCoroutine(CountCoroutine());
        }
        else if(countingCoroutine != null)
        {
            StopCoroutine(countingCoroutine);
            countingCoroutine = null;
        }
    }
}
