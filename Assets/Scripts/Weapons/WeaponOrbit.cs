using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponOrbit : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    private Transform currentWeaponTransform;
    private WeaponBase currentWeapon;

    private void Start()
    {
        if (transform.childCount > 0)
        {
            Transform child = transform.GetChild(0);

            child.localPosition = new Vector3(0.7f, 0, 0);

            // Reset rotation so it doesn't look wonky
            child.localRotation = Quaternion.identity;
        }
    }

    void Update()
    {
        transform.localPosition = new Vector3(0, 0.4f, 0);

        // 2. Aim logic
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector3 worldMousePos = mainCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, mainCamera.nearClipPlane));

        Vector3 direction = worldMousePos - transform.position;
        direction.z = 0;

        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, targetAngle);

        // 3. Flip the weapon child so it's never upside down
        HandleWeaponVisualFlip(targetAngle);
    }

    private void HandleWeaponVisualFlip(float angle)
    {
        // Get the first child (the current weapon)
        if (transform.childCount > 0)
        {
            currentWeaponTransform = transform.GetChild(0);

            if (angle > 90 || angle < -90)
            {
                // Flip on Y axis if on the left side
                currentWeaponTransform.localScale = new Vector3(1, -1, 1);
            }
            else
            {
                // Normal scale if on the right side
                currentWeaponTransform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}