using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackComp : MonoBehaviour
{
    public int damage = 10;
    private Animator animator;
    private InputAction attackAction;
    public GameObject enemy;
    private bool isAttacking;
    private Transform fist;
    private Vector3 attackStartPos;
    private Vector3 attackEndPos;
    private float attackTime;
    private float attackTimeCounter;
    [SerializeField] private float armLength;
    void Start()
    {
        animator = GetComponent<Animator>();
        attackAction = InputSystem.actions.FindAction("Attack");
        fist = transform.Find("Fist");
        attackTime = 0.6f;
        armLength = 0.9f;
        attackStartPos = fist.localPosition;
        attackEndPos = new Vector3(armLength + fist.localPosition.x, fist.localPosition.y, fist.localPosition.z);
    }

    void Update()
    {
        isAttacking = attackAction.ReadValue<float>() == 1 ? true : false;
        if (attackTimeCounter > 0)
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
        if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
            fist.localPosition = new Vector3(Mathf.Lerp(attackStartPos.x,
                                        attackEndPos.x,
                                       1 - attackTimeCounter / attackTime),
                            fist.localPosition.y, fist.localPosition.z);

        }
        else
        {
            attackTimeCounter = 0;
            fist.localPosition = attackStartPos;
        }
    }

    public void OnAttack()
    {
        // If the player is in the process of attacking already, do nothing
        if (attackTimeCounter > 0 || isAttacking) return;
        // Start logging attack time
        attackTimeCounter = attackTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (attackTimeCounter > 0)
            {

                // Move the fist over a span of time of 1.2 seconds
                other.gameObject.GetComponent<EnemyHealthComp>().TakeDamage(damage);
                Debug.Log("Player attacking enemy, health: " + other.gameObject.GetComponent<EnemyHealthComp>().GetCurrentHealth());
            }

        }
    }
}