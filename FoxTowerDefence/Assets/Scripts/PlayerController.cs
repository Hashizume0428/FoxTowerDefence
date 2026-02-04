using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    Animator animator;
    [SerializeField] private GameObject bulletGenerater;
    [SerializeField] private Slider playerHpBar;
    [SerializeField] private GameManager gameManager;
    Vector3 moveDirection = Vector3.zero;
    [Header("Player Settings")]
    [SerializeField] private float hp;
    [SerializeField] private float maxHp;
    [SerializeField] public float attackPower;
    [SerializeField] private float defensePower;
    [SerializeField] private float speed;
    [SerializeField] private float healthTimer;
    [SerializeField] private float healthTimerMax;
    [SerializeField] private float healAmount;
    [SerializeField] private float cost;
    [Header("Other Settings")]
    [SerializeField] private float gravity;
    [SerializeField] private float rotationSpeed = 100f; // 旋回速度
     // Start is called before the first frame update
    void Start()
    {
        //必要なコンポーネントを自動取得
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        Move();
        if (Input.GetKey(KeyCode.Space))
        {
            OnShoot();
        }
        AutoHeal();
        playerHpBar.value = hp / maxHp;
        
    }
    void Move()
    {
        if(controller.isGrounded) //キャラクタが接地しているかどうかの判定
        {
            //キーボード入力を取得
            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");

            //左右キーで旋回
            transform.Rotate(0, horizontal * rotationSpeed * Time.deltaTime, 0);

            //前後キーで前進・後退（キャラクターの前方向基準）
            moveDirection = transform.forward * vertical * speed;

            // if(Input.GetButton("Jump"))//InputのJumpに割り当てられている入力があったら
            // {
            //     moveDirection.y = speedJump; //上方向にspeedJumpを適用する
            //     animator.SetTrigger("jump"); //Animatorに対してjumpトリガーを渡し、アニメーションの切り替えを行う
            // }
        }
        //重力分の力を毎フレーム追加
        moveDirection.y -= gravity * Time.deltaTime; //フレームごとに重力分の速度を下方に加える。
        
        //移動実行（キャラクターのローカル方向基準で移動）
        controller.Move(moveDirection * Time.deltaTime);
        //移動後接地していたらｙ方向の速度はリセットする
        if (controller.isGrounded) moveDirection.y = 0;
        //速度が０以上なら走っているフラグをtrueにする。
        animator.SetBool("run", moveDirection.magnitude > 0.0f);
    }
    public void OnShoot()
    {
        SoundsManager.I.PlaySE(SEType.Shooting);
        bulletGenerater.GetComponent<BulletGenerater>().GenerateBullet();
    }
    void AutoHeal()
    {   
        if(healthTimer >= healthTimerMax)
        {
            if(hp >= maxHp)
            {
                return;
            }
            else
            {
                Heal(healAmount);
                healthTimer = 0f;
            }
        }
        else
        {
            healthTimer += Time.deltaTime;
        }
    }
    void Heal(float healAmount)
    {
        hp += healAmount;
        if(hp > maxHp)
        {
            hp = maxHp;
        }
    }
    public void OnDamage(float damage)
    {
        SoundsManager.I.PlaySE(SEType.PlayerHit);
        hp -= damage;
        if(hp <= 0)
        {
            //ゲームオーバー処理
            gameManager.GameOver(); //ここどうしたらいいか今度聞く
            Destroy(gameObject);
        }
    }

}

