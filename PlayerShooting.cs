using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    private Vector2 target;
    public float speed;
    public GameObject effect;

	// Use this for initialization
	void Start () {
       
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);


    }

    // Update is called once per frame
   
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position , target)<0f)
        {
            DestroyProjectile();
            Instantiate(effect, transform.position, Quaternion.identity);
        }
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            DestroyProjectile();
            Instantiate(effect, transform.position, Quaternion.identity);
        }
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
    
}
