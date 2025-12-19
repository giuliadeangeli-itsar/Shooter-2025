using UnityEngine;

public class PlayerShooter : Shooter
{
    private PlayerInputActions inputActions;
    bool isShooting;

    protected override void Awake()
    {
        base.Awake();
        inputActions = new PlayerInputActions();

        inputActions.Enable();
        inputActions.Player.Reload.performed += ctx => Reload();
        inputActions.Player.Fire.performed += ctx => StartFiring();
        inputActions.Player.Fire.canceled += ctx => StopFiring();
    }

    void StartFiring()
    {
        isShooting = true;
    }
    void StopFiring()
    {
        isShooting = false;
    }

    private void Update()
    {
        if (isShooting && bulletsLeft > 0)
        {
            TryShoot();
        }
    }

    protected override void Shoot()
    {
        RaycastHit bulletHit;
        bool hitSomething = Physics.Raycast(muzzle.transform.position, muzzle.forward, out bulletHit, range);
        if (!hitSomething || bulletHit.collider == null) return;
        if (bulletHit.collider.gameObject.TryGetComponent(out Health healthHit) && healthHit.Team != Team.Player)
        {
            healthHit.TakeDamage(bulletDamage);
            return;
        }

    }

    private void OnDisable()
    {
        inputActions.Disable();
        inputActions.Player.Reload.performed -= ctx => Reload();
        inputActions.Player.Fire.performed -= ctx => StartFiring();
        inputActions.Player.Fire.performed -= ctx => StopFiring();
    }

    private void OnDestroy()
    {
        inputActions.Dispose();
    }
}