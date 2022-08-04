using UnityEngine;

namespace GameUtils
{
    public class DestroyAfterDelay : MonoBehaviour
    {
        [SerializeField] private float delay;

        private void Awake()
        {
            Destroy(gameObject, delay);
        }
    }
}