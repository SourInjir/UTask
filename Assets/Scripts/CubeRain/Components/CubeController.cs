// CubeController.cs
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class CubeController : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private CubeEventChannel _eventChannel;

    private CubeData _cubeData;
    

    public void Initialize(CubeData data)
    {
        _cubeData = data;
        ApplyData();
    }

    public void SetEventChannel(CubeEventChannel channel)
    {
        _eventChannel = channel;
    }

    private void ApplyData()
    {
        transform.position = _cubeData.Position;
        transform.localScale = _cubeData.Scale;
        _renderer.material.color = _cubeData.Color;

        // Добавляем физику для эффекта распада
        _rigidbody.AddExplosionForce(100f, _cubeData.Position, 5f);
    }

    private void OnMouseDown()
    {
        if (_cubeData.Generation >= 3) return; // Ограничение рекурсии

        _eventChannel.RaiseEvent(_cubeData);
        gameObject.SetActive(false); // Возврат в пул через вызов
    }
}