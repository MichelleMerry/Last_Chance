using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TriggerPatrol : MonoBehaviour
{
    [SerializeField]
    private int _lives = 3;
    EnemyPatrol _enemypatrol;
    SphereCollider myCollider;
    public float agroRad;


    private void Start()
    {
        _enemypatrol = GetComponentInParent<EnemyPatrol>();
        myCollider = GetComponent<SphereCollider>();
        myCollider.radius = agroRad;
        myCollider.isTrigger = true; 

    }



    void OnTriggerEnter(Collider coll)  {
        if (coll.gameObject.tag == "Player")   {
            print("Danger danger");
            Damage();
            _enemypatrol.target = coll.gameObject;
         
        }
    }


    void OnTriggerExit(Collider coll) {
        if (coll.gameObject.tag == "Player") {
            print("freedom");
            _enemypatrol.target = null;
        }
    }

        public void Damage()
        {
        _lives -= 1;

        if (_lives < 1)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("GameOver");
        }

        }
    }


     


