using System.Collections;
using UnityEngine;

public class CameraTransformSwitcher : MonoBehaviour
{
    [SerializeField]
    private readonly float _switchTime = 0.4f;
    public Vector3 Offset { get; private set; }
    public float Angle { get; private set; }

    private Vector3 _offsetIn2D;
    private Vector3 _offsetIn3D;

    private float _angleIn2D;
    private float _angleIn3D;

    public void Initialize(Vector3 offsetIn3D, Vector3 offsetIn2D, float angleIn3D, float angleIn2D)
    {
        _offsetIn3D = offsetIn3D;
        _offsetIn2D = offsetIn2D;

        _angleIn3D = angleIn3D;
        _angleIn2D = angleIn2D;

        Offset = _offsetIn3D;
        Angle = _angleIn3D;
    }

    public void SwitchCamera(bool is2D)
    {
        Vector3 startOffset = _offsetIn3D;
        Vector3 targetOffset = _offsetIn2D;

        float startAngle = _angleIn3D;
        float targetAngle = _angleIn2D;

        if (is2D)
        {
            (startOffset, targetOffset) = (targetOffset, startOffset);
            (startAngle, targetAngle) = (targetAngle, startAngle);
        }

        StartCoroutine(Switch(startOffset, targetOffset, startAngle, targetAngle));
    }

    public IEnumerator Switch(Vector3 startOffset, Vector3 targetOffset, float startAngle, float targetAngle)
    {
        float timer = _switchTime;
        while (timer > 0)
        {
            var interpolant = (_switchTime - timer) / _switchTime;
            Angle = Mathf.Lerp(startAngle, targetAngle, interpolant);
            Offset = Vector3.Lerp(startOffset, targetOffset, interpolant);

            timer -= Time.deltaTime;

            yield return null;
        }
    }
}
