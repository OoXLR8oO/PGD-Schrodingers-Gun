using UnityEngine;
using UniRx;
using System.Collections;

namespace TopDown.Shooting
{
    public class GunController : MonoBehaviour
    {
        [Header("Cooldown")]
        [SerializeField] private float cooldown = 0.25f;
        private float cooldownTimer;
        private bool isReloading = false;

        [Header("References")]
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform bulletFirePoint;
        [SerializeField] private Animator muzzleFlashAnimator;

        [Header("Ammo")]
        [SerializeField] private int initialAmmo;
        [SerializeField] private int clipSize;

        public IntReactiveProperty TotalAmmo { get; private set; } = new IntReactiveProperty(0);
        public IntReactiveProperty CurrentAmmoInClip { get; private set; } = new IntReactiveProperty(0);

        private void Awake()
        {
            TotalAmmo.Value = initialAmmo;

            if (initialAmmo <= clipSize)
            {
                CurrentAmmoInClip.Value = initialAmmo;
            }
            else
            {
                CurrentAmmoInClip.Value = clipSize;
            }
        }

        private void Update()
        {
            cooldownTimer += Time.deltaTime;
        }

        private void Shoot()
        {
            if (cooldownTimer < cooldown) return;
            if (CurrentAmmoInClip.Value <= 0) return;

            GameObject bullet = Instantiate(bulletPrefab, bulletFirePoint.position, bulletFirePoint.rotation, null);
            bullet.GetComponent<Projectile>().ShootBullet(bulletFirePoint);

            muzzleFlashAnimator.SetTrigger("shoot");
            cooldownTimer = 0;
            CurrentAmmoInClip.Value--;
        }

        private void Reload()
        {
            if (!isReloading && TotalAmmo.Value > 0 && CurrentAmmoInClip.Value < clipSize)
            {
                StartCoroutine(ReloadCoroutine());
            }
        }

        private IEnumerator ReloadCoroutine()
        {
            isReloading = true;

            // Optionally trigger reload animation/sound here
            Debug.Log("Reloading...");

            yield return new WaitForSeconds(1.5f); // Wait for 2 seconds

            int missingAmmo = clipSize - CurrentAmmoInClip.Value;
            int reloadAmmo = Mathf.Min(missingAmmo, TotalAmmo.Value);

            CurrentAmmoInClip.Value += reloadAmmo;
            TotalAmmo.Value -= reloadAmmo;

            isReloading = false;

            Debug.Log("Reload complete.");
        }

        #region Input
        private void OnShoot()
        {
            Shoot();
        }

        private void OnReload()
        {
            Reload();
        }
        #endregion
    }
}
