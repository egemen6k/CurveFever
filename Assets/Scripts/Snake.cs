using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private float _rotationSpeed = 250f;
    private float _horizontal = 0f;

    public string inputAxis = "Horizontal";

    void Update()
    {
        _horizontal = Input.GetAxisRaw(inputAxis);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * _speed * Time.fixedDeltaTime, Space.Self);
        transform.Rotate(Vector3.forward * -_horizontal * _rotationSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("killsPlayer"))
        {
            _speed = 0f;
            _rotationSpeed = 0f;

            FindObjectOfType<GameManager>().EndGame(); // Singleton olmalı
        }
    }
}
