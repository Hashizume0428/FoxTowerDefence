using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Header("Bullet Settings")]
    [SerializeField] private float speed;
    private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyController>().OnDamage(player.GetComponent<PlayerController>().attackPower);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
