// GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private CubeEventChannel _cubeEventChannel;
    [SerializeField] private CubePool _cubePool;
    [SerializeField] private CubeController _initialCube;

    private CubeSpawner _cubeSpawner;

    private void Awake()
    {
        // Инициализация зависимостей
        _cubeSpawner = new CubeSpawner(_cubePool, _cubeEventChannel);

        // Настройка начального куба
        CubeData initialData = new CubeData
        {
            Position = Vector3.zero,
            Scale = Vector3.one,
            Color = Color.white,
            Generation = 0
        };

        _initialCube.Initialize(initialData);
        _initialCube.SetEventChannel(_cubeEventChannel);
    }

    private void OnDestroy()
    {
        _cubeSpawner?.Dispose();
    }
}