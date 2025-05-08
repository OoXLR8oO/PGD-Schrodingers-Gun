using UnityEngine;

namespace TopDown.Shooting
{
    public class GunController : MonoBehaviour
    {
        [Header("Cooldown")]
        [SerializeField] private float cooldown = 0.25f;
        private float cooldownTimer;

        [Header("References")]
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform bulletFirePoint;
        [SerializeField] private Animator muzzleFlashAnimator;

        //Shoot point
        //[Header("Shoot Point")]

        //Bullet prefab
        private void Update()
        {
            cooldownTimer += Time.deltaTime;
        }

        private void Shoot()
        {
            if (cooldownTimer < cooldown) return;

            GameObject bullet = Instantiate(bulletPrefab, bulletFirePoint.position, bulletFirePoint.rotation, null);
            bullet.GetComponent<Projectile>().ShootBullet(bulletFirePoint);

            muzzleFlashAnimator.SetTrigger("shoot");
            cooldownTimer = 0;
        }

        #region Input
        private void OnShoot()
        {
            Shoot();
        }
        #endregion
    }
}
