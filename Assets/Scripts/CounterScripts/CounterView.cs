using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TMP_Text _counterText;
    [SerializeField] private Counter _counter;

    private void Start()
    {
        if (_counter != null)
        {
            _counter.CounterChanged += UpdateCounterView;
        }
        else
        {
            Debug.LogError("Counter не найден на сцене!");
        }

        UpdateCounterView(0);
    }

    private void OnDestroy()
    {

        if (_counter != null)
        {
            _counter.CounterChanged -= UpdateCounterView;
        }
    }

    private void UpdateCounterView(int count)
    {
        if (_counterText != null)
        {
            _counterText.text = count.ToString();
        }
    }

}