using UnityEngine;

public enum ProyectileType
{
    None,
    Spin,
    Throw,
    Falling
}

public class WeaponBase : MonoBehaviour
{
    public int Duration;
    public ProyectileType Type;
    public float speed;
    public Transform Target;
    public float OrbitRadius = 1f;
    private float currentAngle = 0f;

    public Vector2 dir;

    void Start()
    {
        Destroy(gameObject,Duration);
        dir = randomDirection();
        if (Type == ProyectileType.Spin && Target != null)
        {
            Vector3 dist = transform.position - Target.position;
            currentAngle = Mathf.Atan2(dist.y, dist.x);
            transform.position = Target.position + new Vector3(Mathf.Cos(currentAngle), Mathf.Sin(currentAngle), 0f) * OrbitRadius;
        }
    }
    void Update()
    {
        switch (Type)
        {
            case ProyectileType.None:
                break;
            case ProyectileType.Spin:
                {
                    if (Target != null)
                    {
                        currentAngle += speed * Time.deltaTime;
                        float rad = currentAngle;
                        transform.position = Target.position + new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0f) * OrbitRadius;
                        transform.Rotate(Vector3.forward, speed * Time.deltaTime);
                    }
                    else
                    {
                        transform.position += transform.up * speed * Time.deltaTime;
                        transform.eulerAngles += Vector3.forward * speed * Time.deltaTime;
                    }
                }
                break;
            case ProyectileType.Throw:
                {
                    transform.position += (Vector3)dir * speed * Time.deltaTime;
                    transform.eulerAngles += Vector3.forward * speed * Time.deltaTime;
                }
                break;
            case ProyectileType.Falling:
                {
                    transform.position += (Vector3)dir * speed * Time.deltaTime;
                    transform.eulerAngles += Vector3.forward * speed * Time.deltaTime;
                }
                break;
            default:
                break;
        }
    }
    public Vector2 randomDirection()
    {
        Vector2 randomDir = new Vector2(Random.Range( -1f,1f), Random.Range( -1f,1f) );
        return randomDir.normalized;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {

        }
    }
}
