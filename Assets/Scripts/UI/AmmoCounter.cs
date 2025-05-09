using UnityEngine;
using TMPro;
using TopDown.Shooting;
using UniRx;
using DG.Tweening;

namespace TopDown.UI
{
    public class AmmoCounter : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TextMeshProUGUI ammoCounterText;
        [SerializeField] private GunController gunController;

        private int ammoInClip;
        private int totalAmmo;

        private CompositeDisposable subscriptions = new CompositeDisposable();

        [Header("Pop-Up Effect")]
        [SerializeField] private Vector2 popupIntensity;
        [SerializeField] private float popupDuration;

        private void OnEnable()
        {
            gunController.CurrentAmmoInClip.ObserveEveryValueChanged(property => property.Value)
                .Subscribe(value =>
                {
                    ammoInClip = value;
                    UpdateAmmoCounter(ammoInClip, totalAmmo);
                }).AddTo(subscriptions);

            gunController.TotalAmmo.ObserveEveryValueChanged(property => property.Value)
                .Subscribe(value =>
                {
                    totalAmmo = value;
                    UpdateAmmoCounter(ammoInClip, totalAmmo);
                }).AddTo(subscriptions);
        }

        private void OnDisable()
        {
            subscriptions.Clear();
        }

        private void UpdateAmmoCounter(int currentAmmo, int totalAmmo)
        {
            ammoCounterText.text = $"{currentAmmo}/{totalAmmo}";
            transform.DOPunchScale(popupIntensity, popupDuration).OnComplete(() => transform.DORewind());
        }
    }
}