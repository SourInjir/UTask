using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text counterText;

    private Coroutine countingCoroutine;
    private bool _isRun = false;
    private int _count = 0;
    private float _interval = 0.5f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ToggleCounting();
        }
    }

    private IEnumerator CountCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_interval);
            _count++;
            UpdateCounterText();
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

    private void UpdateCounterText()
    {
        if (counterText != null)
        {
            counterText.text = _count.ToString();
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
}
