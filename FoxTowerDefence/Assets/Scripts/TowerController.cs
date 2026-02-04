using UnityEngine;
using UnityEngine.UI;

public class TowerController : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;
    [Header("Tower Settings")]
    [SerializeField] private float hp;
    [SerializeField] private float maxHp;
    [SerializeField] private Slider healthBar;

    void Start()
    {
        
    }

    void Update()
    {
        healthBar.value = hp / maxHp;
    }
    public void OnDamage(float damage)
    {
        SoundsManager.I.PlaySE(SEType.TowerHit);
        hp -= damage;
        if(hp <= 0)
        {
            gameManager.GetComponent<GameManager>().GameOver();
            Destroy(gameObject);
        }
    }

}
