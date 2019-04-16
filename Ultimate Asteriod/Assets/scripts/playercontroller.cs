using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float speed = 5f;
    public float min_Y, max_Y;

    [SerializeField]
private GameObject player_bullet;

    [SerializeField]
private Transform attack_point;

    public float attack_timer = 0.35f;
    private float current_Attack_Timer;
    private bool canAttack;
    // Start is called before the first frame update
    void Start()
    {
        current_Attack_Timer = attack_timer;
    }
    // Update is called once per frame
    void Update()
    {
        Moveplayer();
        Attack();
    }

    void Moveplayer()
    {
        if(Input.GetAxisRaw("Vertical") > 0f)
        {
            Vector3 temp = transform.position;
            temp.y += speed * Time.deltaTime;

            if (temp.y > max_Y)
                temp.y = max_Y;
            transform.position = temp;
        
        } else if (Input.GetAxisRaw("Vertical") < 0f)
        {
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;
            if (temp.y > min_Y)
                temp.y = min_Y;

            transform.position = temp;
        }

    }
    void Attack()
    {
        attack_timer += Time.deltaTime;
        if(attack_timer > current_Attack_Timer)
        {
            canAttack = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canAttack)
            {
                canAttack = false;
                attack_timer = 0f;
        Instantiate(player_bullet, attack_point.position, Quaternion.identity);
            
            // play the sound fx
            }

        

        }
    }

}// Class
