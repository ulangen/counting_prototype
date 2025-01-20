using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _movingSpeed = 5.0f;


    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _target.transform.position + _offset, _movingSpeed * Time.deltaTime);
    }
}
