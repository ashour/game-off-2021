using UnityEngine;

namespace Vfx
{
    public class EffectCleanUp : MonoBehaviour
    {
        private void Start() => Invoke(nameof(CleanUp), 2f);    

        private void CleanUp() => Destroy(gameObject);
    }
}