using UnityEngine;

public class Thrower : MonoBehaviour
{
    [SerializeField, Range(-10, 10)] private float _minSpreadX;
    [SerializeField, Range(-10, 10)] private float _maxSpreadX;

    [SerializeField, Range(0, 10)] private float _minSpreadY;
    [SerializeField, Range(0, 10)] private float _maxSpreadY;

    [SerializeField, Range(-10, 10)] private float _minSpreadZ;
    [SerializeField, Range(-10, 10)] private float _maxSpreadZ;

    [SerializeField] private float _throwForce;

    public void ThrowTo(Ore ore, Vector3 objectPosition)
    {
        ore.Rigidbody.isKinematic = false;

        Vector3 direction = (transform.position - objectPosition).normalized + new Vector3(
            Random.Range(_minSpreadX, _maxSpreadX),
            Random.Range(_minSpreadY, _maxSpreadY),
            Random.Range(_minSpreadZ, _maxSpreadZ)
            );

        ore.Rigidbody.AddForce(direction * _throwForce, ForceMode.Impulse);
    }
}