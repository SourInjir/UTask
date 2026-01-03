using UnityEngine;
using System;

public class InputReader : MonoBehaviour
{
    public event Action OnMouseClicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseClicked?.Invoke();
        }
    }
}
