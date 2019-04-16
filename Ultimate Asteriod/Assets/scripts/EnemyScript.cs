using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 5f;
    public float rotate_speed = 50f;

    public bool canShoot;
    public bool canRotate;
    private bool canMove = true;

    public float bound_X = -11f;

    public Transform attack_Point;
    public GameObject bulletPrefab;

    private Animator anim;
    private AudioSource explosionSound;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        explosionSound = GetComponent<AudioSource>();

    }
    void Start()
    {
        if (canRotate)
        {
            if (Random.Range(0, 2) > 0)
            {
                rotate_speed *= -1f;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        RotateEnemy();
    }
    void Move()
    {
        if (canMove)
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp;

            if (temp.x < bound_X)
                gameObject.SetActive(false);
        }
    }
    void RotateEnemy()
    {
        if (canRotate)
        {
            transform.Rotate(new Vector3(0f, 0f, rotate_speed * Time.deltaTime), Space.World);
        }
        void StartShooting()
        {
            GameObject bullet = Instantiate(bulletPrefab, attack_Point.position, Quaternion.identity);
            bullet.GetComponent<bulletScript>().is_EnemyBullet = true;

            if (canShoot)
                Invoke("StartShootIng", Random.Range(1f, 3f));
        }


        void TurnOffGameObject()
        {
            gameObject.SetActive(false);
        }
        void OnTriggerEnter2D(Collider target)
        {

            if (target.tag == "Bullet")
            {
                canMove = false;
                if (canShoot)
                {
                    canShoot = false;
                    CancelInvoke("StartShooting");
                }
                Invoke("TurnOffGameObject", 3f);

                //play expolsion
                anim.Play("Destroy");
            }
        }

    }
}

