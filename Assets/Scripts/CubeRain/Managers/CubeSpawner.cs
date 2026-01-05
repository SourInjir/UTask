using UnityEngine;
// CubeSpawner.cs
public class CubeSpawner
{
    private readonly CubePool _cubePool;
    private readonly CubeEventChannel _eventChannel;

    public CubeSpawner(CubePool pool, CubeEventChannel eventChannel)
    {
        _cubePool = pool;
        _eventChannel = eventChannel;
        SubscribeToEvents();
    }

    private void SubscribeToEvents()
    {
        _eventChannel.OnCubeClicked += HandleCubeSpawn;
    }

    private void HandleCubeSpawn(CubeData data)
    {
        int count = Random.Range(2, 7);

        for (int i = 0; i < count; i++)
        {
            SpawnCube(data);
        }
    }

    private void SpawnCube(CubeData parentData)
    {
        var cube = _cubePool.Get();
        var cubeController = cube.GetComponent<CubeController>();

        CubeData newData = new CubeData
        {
            Position = CalculatePosition(parentData.Position),
            Scale = parentData.Scale * 0.5f,
            Color = Random.ColorHSV(),
            Generation = parentData.Generation + 1
        };

        cubeController.Initialize(newData);

        // Автоматический возврат в пул через время
        _cubePool.ReturnWithDelay(cube, 5f);
    }

    private Vector3 CalculatePosition(Vector3 parentPos)
    {
        return parentPos + Random.insideUnitSphere * 1.5f;
    }

    public void Dispose()
    {
        _eventChannel.OnCubeClicked -= HandleCubeSpawn;
    }
}