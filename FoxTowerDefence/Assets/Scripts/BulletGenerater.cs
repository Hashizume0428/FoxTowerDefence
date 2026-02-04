using UnityEngine;

public class BulletGenerater : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireRate = 0.2f;
    private float timer = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }
    public void GenerateBullet()
    {
        if (timer > fireRate)
        {
            Instantiate (bulletPrefab, transform.position + new Vector3(0.0f, 0.5f, 0.75f), transform.rotation);
            timer = 0.0f;
        }
    }
}
