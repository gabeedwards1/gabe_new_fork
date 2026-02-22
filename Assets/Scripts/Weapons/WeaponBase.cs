using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public float orbitRadius = 1.0f;
    [HideInInspector] public bool isAttacking = false;
    public abstract void tryAttack();
}