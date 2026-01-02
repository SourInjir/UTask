using UnityEngine;

public class ScaleAnimationComponent : MonoBehaviour
{

    [SerializeField] private Vector3 _initialScale = Vector3.one;
    [SerializeField] private float _scaleSpeed = 1f;

    private bool _scaleToggler = true;
    private int _maxScale = 2;
    private int _minScale = 1;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        scaleProcess();
    }

    private void scaleProcess()
    {
        Vector3 currentScale = transform.localScale;
        float divX = currentScale.x / _initialScale.x;

        if ((_scaleToggler && divX >= _maxScale) || (!_scaleToggler && divX <= _minScale))
            _scaleToggler = !_scaleToggler;

        if (_scaleToggler)
            currentScale += Vector3.one * _scaleSpeed * Time.deltaTime;
        else
            currentScale -= Vector3.one * _scaleSpeed * Time.deltaTime;

        transform.localScale = currentScale;
    }
}
