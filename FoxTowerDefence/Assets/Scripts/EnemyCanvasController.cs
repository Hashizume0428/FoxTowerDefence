using UnityEngine;

public class EnemyCanvasController : MonoBehaviour
{
    private Transform camera;
    private EnemyController enemyController;
    private Slider enemyHpBar;

    private void Start()
    {
        camera = Camera.main.transform;
        enemyController = GetComponentInParent<EnemyController>();
    }

    private void Update()
    {
        transform.LookAt(camera.position);
        enemyHpBar.value = enemyController.hp / enemyController.maxHp;
    }
}
