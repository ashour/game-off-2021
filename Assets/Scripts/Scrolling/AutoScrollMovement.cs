using UnityEngine;

namespace Scrolling
{
    public class AutoScrollMovement : MonoBehaviour
    {
        [SerializeField] private GameConfig _config;

        private void Update()
        {
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y + _config.AutoScrollSpeed * Time.deltaTime,
                transform.position.z
            );
        }
    }
}
