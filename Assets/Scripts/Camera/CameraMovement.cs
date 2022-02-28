using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform _playerCar;

    [SerializeField]
    private float _offsetY;

    [SerializeField]
    private float _offsetZ;

    [SerializeField]
    private float _switchTime;

    private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    void Update()
    {
        FollowPlayerCar();
    }

    private void FollowPlayerCar()
    {
        _transform.position = new Vector3(_playerCar.position.x, _playerCar.position.y + _offsetY, _playerCar.position.z + _offsetZ);
    }

    public IEnumerator SwitchTo2D()
    {
        float timer = _switchTime; 

        float startOffsetY = _offsetY;
        float deltaOffsetY = 5f;
        float targetOffsetY = startOffsetY + deltaOffsetY;

        float startOffsetZ = _offsetZ;
        float targetOffsetZ = -_offsetZ;

        float startAngle = _transform.eulerAngles.x;
        float targetAngle = 90f;

        while (timer > 0)
        {  
            _transform.rotation = Quaternion.Euler(Mathf.LerpAngle(startAngle, targetAngle, (_switchTime - timer) / _switchTime), 0, 0);
                       
            _offsetY = Mathf.Lerp(startOffsetY, targetOffsetY, (_switchTime - timer)/_switchTime);
            _offsetZ = Mathf.Lerp(startOffsetZ, targetOffsetZ, (_switchTime - timer)/_switchTime);

            timer -= Time.deltaTime;

            yield return null;
        }
    }
}
