using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    
    void Update() {
        TrackPlayer();
    }

    private void TrackPlayer() {
        Vector3 position = transform.position;
        position.x = playerTransform.position.x;
        position.y = playerTransform.position.y;
        transform.position = position;
    }
}
