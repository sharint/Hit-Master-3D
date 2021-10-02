using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject gun;

    private InputController inputController;

    private void Start()
    {
        inputController = gameObject.AddComponent<InputController>();
    }

    private void Update()
    {
        if (inputController.isUserTapOnScreen())
        {
            Shot();
        }
    }

    private void Shot()
    {
        RaycastHit hit = CalculatePointOnScreen();
        Bullet bullet = CreateBullet();
        DirectBullet(bullet,hit);
    }

    private RaycastHit CalculatePointOnScreen()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);

        return hit;
    }

    private Bullet CreateBullet()
    {
        GameObject bulletGameObject = Instantiate(bulletPrefab, gun.transform.position, Quaternion.identity);
        Bullet bullet = bulletGameObject.GetComponent<Bullet>();
        return bullet;
    }

    private void DirectBullet(Bullet bullet, RaycastHit hit)
    {
        Vector3 direction = hit.point;
        bullet.SetDirection(direction);
        gun.transform.LookAt(direction);
    }
}
