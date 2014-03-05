using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    public GameObject target;
    public float attackTimer;
    public float coolDown;



    // Use this for initialization
    void Start()
    {

        attackTimer = 0;
        coolDown = 2.0f;

    }

    // Update is called once per frame
    void Update()
    {

        //every frame the attack time is >0 it gets reduced by the time it to render the frame. 
        if (attackTimer > 0)
            attackTimer -= Time.deltaTime;


        if (attackTimer < 0)
            attackTimer = 0;

            if (attackTimer == 0)
            {
                Attack();
                attackTimer = coolDown;
            }
        }


    private void Attack()
    {

        float distance = Vector3.Distance(target.transform.position, transform.position);

        //set direction and move one unit forward
        Vector3 dir = (target.transform.position - transform.position).normalized;
        float direction = Vector3.Dot(dir, transform.forward);

        //call new instance of Enemny health
        PlayerHealth eh = (PlayerHealth)target.GetComponent("PlayerHealth");

        //Debug.Log(distance);

        //should return between 1 and -1, 1 is in front, -1 is behind

        //Debug.Log(direction);


        if (distance <= 2.5f)
        {
            if (direction > 0)
            {
                eh.AdjustCurrentHealth(-10);
            }
        }

    }
}
