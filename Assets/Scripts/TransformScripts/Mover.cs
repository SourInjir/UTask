using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    private void Update()
    {
        MoveProcess();
    }

    private void MoveProcess()
    {
        transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
    }

}