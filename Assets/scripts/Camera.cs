using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private Transform player;
    [SerializeField] private Transform coin;
    [SerializeField] private float minSize = 4f;
    [SerializeField] private float maxSize = 8f;
    [SerializeField] private float minDistance = 1f;
    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private float zoomLerpSpeed = 5f; 

    void Update()
    {
        
        float distance = Vector2.Distance(player.position, coin.position);
        float t = Mathf.InverseLerp(minDistance, maxDistance, distance);       
        float targetSize = Mathf.Lerp(minSize, maxSize, t);
        camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, targetSize, zoomLerpSpeed * Time.deltaTime);
    }
}

