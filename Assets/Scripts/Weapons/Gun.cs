using UnityEngine;

public class Gun : Weapon
{
    public Transform shotPoint;
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;

    protected override void Start()
    {
        base.Start();
        Debug.Log($"Gun started - inputHandler={inputHandler}, shotPoint={shotPoint}, prefab={projectilePrefab}");
    }

    protected override void Update()
    {
        base.Update();
    }

    protected void SpawnBullet()
    {
        if (projectilePrefab == null) { Debug.LogWarning("Missing projectile prefab on Gun!"); return; }
        if (shotPoint == null) { Debug.LogWarning("Missing shot point on Gun!"); return; }

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(inputHandler.MousePosition);
        mousePos.z = 0f;
        Vector2 direction = (mousePos - shotPoint.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        shotPoint.rotation = Quaternion.Euler(0, 0, angle);

        GameObject bullet = Instantiate(projectilePrefab, shotPoint.position, shotPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.linearVelocity = direction * projectileSpeed;
        else
            Debug.LogWarning("Bullet prefab is missing a Rigidbody2D!");
    }

    protected override void Attack()
    {
        SpawnBullet();
    }
}