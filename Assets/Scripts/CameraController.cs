using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;

    void Update()
    {
        transform.position = Vector3.Lerp(
            transform.position,
            new Vector3(player.position.x, player.position.y, transform.position.z),
            Time.deltaTime * 6f
        );
    }
}
