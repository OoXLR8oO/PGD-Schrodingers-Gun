using UnityEngine;

namespace TopDown.Movement
{
    public class Rotator : MonoBehaviour
    {
        protected void LookAt(Vector3 target)
        {
            float lookAngle = AngleBetweenTwoPoints(transform.position, target) + 90;
            transform.eulerAngles = new Vector3(0f, 0f, lookAngle);
        }

        private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
        {
            return Mathf.Atan2(b.y - a.y, b.x - a.x) * Mathf.Rad2Deg;
        }
    }

}