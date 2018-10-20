using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    
    public float range = 10f;
    public float speed = 10f;
    private Transform target;
    private int cylinderIndex;
    public string enemyTag = "Enemy";
    public Transform rotationPart;

    
    public float fireRate = 2f;
    private float fireCountdown = 1f;
    private float actionCountdown = 0f;

    public GameObject bulletPrefab;
    public Transform firePoint;

	// Use this for initialization
	void Start () {

	}

    // Update is called once per frame
    void Update() {
        if (gameObject.tag == "Enemy")
        {
            Debug.Log("Call Me1!");
            transform.Translate(Vector3.right * 10 * Time.deltaTime, Space.World);
            return;
        }

        if (GameObject.FindGameObjectsWithTag(enemyTag).Length <= 0)
        {
            Debug.Log("Call Me2!");
            return;
        }
        if (target == null)
        {
            Debug.Log("Call Me3!");
            UpdateNearestEnemy();
            Debug.Log("1");
            return;
        }
        Debug.Log("Call Me4!");
        Vector3 dir = target.position - rotationPart.position ; 
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(rotationPart.rotation,lookRotation,10*Time.deltaTime).eulerAngles;
        
        rotationPart.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        float distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance <= range)
        {
            if (fireCountdown <= 0f)
            {
                Shoot();

                fireCountdown = 1f / fireRate;
                actionCountdown = 0.5f;
            }

        }
        else if (actionCountdown <= 0f)
        {
            Debug.Log(distance);
            Vector3 direc = target.position - transform.position;
            transform.Translate(direc.normalized * speed * Time.deltaTime, Space.World);
        }

        fireCountdown -= Time.deltaTime;
        actionCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject laserGO = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        laser _laser = laserGO.GetComponent<laser>();

        if(_laser != null)
        {
            _laser.Seek(target);
        }

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
                Debug.Log("1");
            }
            Debug.Log("No Enemy!");
        }
        Debug.Log("No Enemy!");
        target = nearestEnemy.transform;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;   
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
