using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class Monster : MonoBehaviour {

    [Header("Attribute")]

    public float range = 2f;
    public float speed = 10f;
    public int hp = 100;

    [Header("Target")]

    private Transform target;
    private int cylinderIndex;
    public string enemyTag = "Enemy";
    public Transform rotationPart;


    public float fireRate = 2f;
    private float fireCountdown = 0f;
    private float actionCountdown = 0f;

    private Animator anim;
    public GameObject bulletPrefab;
    public Transform firePoint;

    [Header("Mode")]
    public bool attack = false;
    public bool move = false;
    private bool inRange = false;
    public NavMeshAgent _temp;
    private bool onGround = false;
    public float time = 5;

    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
        _temp = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }

        if (inRange)
        {
            if (time != 0) { transform.Translate(new Vector3(-1f, 0, 1f) * speed * Time.deltaTime, Space.World); }

            time-=Time.deltaTime;
            return;
        }
        if (!onGround)
        {
            return;
        }
        if (gameObject.tag == "Enemy")
        {
            transform.Translate(Vector3.right * 10 * Time.deltaTime, Space.World);
            return;
        }

        if (GameObject.FindGameObjectsWithTag(enemyTag).Length <= 0)
        {
            move = false;
            attack = false;
            anim.SetBool("Attack", attack);
            anim.SetBool("Move", move);
            return;
        }
        if (target == null)
        {
            UpdateNearestEnemy();
            return;
        }

        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance <= range)
        {
            if (fireCountdown > 0)
            {
                fireCountdown -= Time.deltaTime;
                return;
            }
            fireCountdown = 1f;
            attack = true;
            move = false;
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            anim.SetBool("Attack", attack);
            anim.SetBool("Move", move);
            target.GetComponent<EnemyMonsters>().healthpoint -= 10;
            Debug.Log(target.GetComponent<EnemyMonsters>().healthpoint);
            return;

        } else
        {
            
            Move();
          
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ally")
        {
            inRange = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (attack)
        {
            return;
        }
        if (collision.gameObject.tag == "Ally")
        {
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (attack)
        {
            return;
        }
        if (collision.gameObject.name == "Plane")
        {
            onGround = true;
        }
        if (collision.gameObject.tag == "Ally")
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

            inRange = true;
        } else
        {
            inRange = false;
        }
    }

    void rotate()
    {

        Vector3 dir = target.position - rotationPart.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Debug.Log(lookRotation.y);
        rotationPart.rotation = lookRotation;
        
    }

    void Move ()
    {
        move = true;
        attack = false;
        anim.SetBool("Attack", attack);
        anim.SetBool("Move", move);
        float verticalMove = speed * Time.deltaTime;
        anim.SetFloat("AnimPar", Mathf.Abs(verticalMove));
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        transform.Translate(Vector3.right * 1 * Time.deltaTime, Space.World);
        Vector3 direc = target.position - transform.position;
        transform.Translate(direc.normalized * speed * Time.deltaTime, Space.World);
    }

    void UpdateNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestEnemy = enemy;
            }
        }
        target = nearestEnemy.transform;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void setHp(int i)
    {
        hp -= i;
    }
}
