using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] private float hp;
    [SerializeField] private float attackPower;
    [SerializeField] private float defensePower;
    [SerializeField] private float speed;
    [SerializeField] private float healthRecoveryRate;
    [SerializeField] private float dropCost;

    [Header("Movement Settings")]
    [SerializeField] private GameObject attackTarget;  // 本来の攻撃目標
    [SerializeField] private GameObject player;        // プレイヤー
    [SerializeField] private float detectionRange = 10f; // プレイヤーを検知する距離
    private NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        attackTarget = GameObject.FindGameObjectWithTag("Tower");
    }
    void Update()
    {
        if(hp < 0f)
        {
            Destroy(gameObject);
        }
        Move();
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Detected with: " + other.gameObject.tag);
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.OnDamage(attackPower);
            }
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.OnDamage(attackPower * Time.deltaTime);
            }
        }
        if (other.CompareTag("Tower"))
        {
            Debug.Log("Attacking Tower");
            TowerController towerController = other.GetComponent<TowerController>();
            if (towerController != null)
            {
                towerController.OnDamage(attackPower * Time.deltaTime);
            }
        }
    }
    void Attack(GameObject obj)
    {
        Debug.Log("Attack called, attackPower: " + attackPower);
        PlayerController playerController = obj.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.OnDamage(attackPower);
        }
    }
    public void OnDamage(float damage)
    {
        hp -= damage;
        SoundsManager.I.PlaySE(SEType.EnemyHit);
        if(hp <= 0)
        {
            //dropCost数だけコストのオブジェクトを生成
            Destroy(gameObject);
        }
    }
    void Move()
    {
         // プレイヤーとの距離を計算
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer < detectionRange)
        {
            // 【追跡状態】プレイヤーを追いかける
            agent.SetDestination(player.transform.position);
        }
        else
        {
            // 【通常状態】本来の目標地点へ向かう
            agent.SetDestination(attackTarget.transform.position);
        }      
    }
}
