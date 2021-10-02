using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;

    private float speed = 4f;

    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
    }

    private void Start()
    {
        gameObject.transform.LookAt(direction);
    }

    void Update()
    {
        TranslateBullet();
    }

    private void TranslateBullet()
    {
        Vector3 currentPosition = gameObject.transform.position;
        Vector3 targetPosition = direction;
        float totalSpeed = speed * Time.deltaTime;

        gameObject.transform.position = Vector3.MoveTowards(currentPosition, targetPosition, totalSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
