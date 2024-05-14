using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Slingshot
{
    public class ShootPoint : MonoBehaviour
    {
        [SerializeField]
        private Vector3 start;
        [SerializeField]
        private float maxDistance = 5;
        public UnityEvent<Vector3> release = new UnityEvent<Vector3>();
        private new Camera camera;
        
        private void Awake()
        {
            camera = Camera.main;
            start = transform.position;
        }

        private void OnMouseDrag()
        {
            if (!enabled)
            {
                return;
            }

            Vector3 target = camera!.ScreenToWorldPoint(Input.mousePosition);
            target.z = 0;
            if (Vector3.Distance(start, target) < maxDistance)
            {
                transform.position = target;
            }
            else
            {
                Vector3 direction = (target - start).normalized * maxDistance;
                transform.position = start + direction;
            }
        }

        private void OnMouseUp()
        {
            var releasePosition = transform.position;
            transform.position = start;
            var delta = releasePosition - start;
            release?.Invoke(delta.normalized * (delta.magnitude/maxDistance));
        }
    }
}
