// CubeEventChannel.cs
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Cube Event Channel")]
public class CubeEventChannel : ScriptableObject
{
    public UnityAction<CubeData> OnCubeClicked;

    public void RaiseEvent(CubeData data)
    {
        OnCubeClicked?.Invoke(data);
    }
}

[System.Serializable]
public struct CubeData
{
    public Vector3 Position;
    public Vector3 Scale;
    public Color Color;
    public int Generation;
}