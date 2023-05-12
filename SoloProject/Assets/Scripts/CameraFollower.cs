
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] Transform player;
    Vector3 offset;

    
    void Start()
    {
        offset = transform.position - player.position;
        // to keep the camera the same distance from the camera at all times
    }

    
    void Update()
    {
        Vector3 targetPos = player.position + offset;
        targetPos.x = 0;
        transform.position = targetPos;
        
    }
}
