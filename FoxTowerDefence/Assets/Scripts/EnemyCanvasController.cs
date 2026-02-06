using UnityEngine;

public class EnemyCanvasController : MonoBehaviour
{
    private Transform camera;

    private void Start()
    {
        camera = Camera.main.transform;
    }

    private void Update()
    {
        transform.LookAt(camera.position);
    }
}
