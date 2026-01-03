using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TMP_Text _counterText;

    private void Start()
    {
        var counter = FindObjectOfType<Counter>();

        if (counter != null)
        {
            counter.OnCounterChanged += UpdateCounterView;
        }
        else
        {
            Debug.LogError("Counter не найден на сцене!");
        }

        UpdateCounterView(0);
    }

    private void OnDestroy()
    {

        var counter = FindObjectOfType<Counter>();
        if (counter != null)
        {
            counter.OnCounterChanged -= UpdateCounterView;
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