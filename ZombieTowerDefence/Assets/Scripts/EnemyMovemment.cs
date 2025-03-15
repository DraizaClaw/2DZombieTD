using UnityEngine;

public class EnemyMovemment : MonoBehaviour
{

    private Rigidbody2D rb;


    [Header("Attributes")]
    [SerializeField] private float speed;

    private Transform target;
    private int PathIndex;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        target = LevelManager.main.path[PathIndex];
    }
    private void Update()
    {
        if (Vector2.Distance(target.position,transform.position) <= 0.1f)
        {
            PathIndex++;


            if (PathIndex==LevelManager.main.path.Length)
            {
                EnemySpawner.onEnemyDestroy.Invoke();
                Destroy(gameObject);
                return;
            }
            else
            {
                target = LevelManager.main.path[PathIndex];
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        rb.linearVelocity = direction * speed;
    }
}
