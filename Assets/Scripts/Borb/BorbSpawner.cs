using UnityEngine;

namespace Borbs
{
    public class BorbSpawner : MonoBehaviour
    {
        [SerializeField] private Borb borbPrefab = null!;


        private void Awake()
        {
            //borbPrefab.EnsureNotNull();
        }


        public Borb NextBorb()
        {
            return Instantiate(borbPrefab, transform.position, Quaternion.identity)!;
        }
    }
}
      