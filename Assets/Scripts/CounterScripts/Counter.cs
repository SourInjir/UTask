using UnityEngine;
using System.Collections;
using System;

public class Counter : MonoBehaviour
{
    private Coroutine countingCoroutine;
    private bool _isRun = false;
    private int _count = 0;
    private float _interval = 0.5f;
    private WaitForSeconds _waitInterval;

    public event Action<int> OnCounterChanged;


    private void Start()
    {
        _waitInterval = new WaitForSeconds(_interval);

        var inputReader = FindObjectOfType<InputReader>();
        if (inputReader != null)
        {
            inputReader.OnMouseClicked += ToggleCounting;
        }
        else
        {
            Debug.LogError("InputReader не найден на сцене!");
        }

        OnCounterChanged?.Invoke(_count);
    }


    private IEnumerator CountCoroutine()
    {
        while (true)
        {
            yield return _waitInterval;
            _count++;
            OnCounterChanged?.Invoke(_count);
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

    private void OnDisable()
    {
        if (countingCoroutine != null)
        {
            StopCoroutine(countingCoroutine);
            countingCoroutine = null;
            _isRun = false;
        }
    }

    public void SetCount(int value)
    {
        _count = value;
        OnCounterChanged?.Invoke(_count);
    }

    public int GetCount() => _count;
}
