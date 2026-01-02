using UnityEngine;

public class PositionAnimationComponent : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveProcess();
    }

    private void moveProcess()
    {
        transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
    }

}