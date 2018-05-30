using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    private Vector2 target;
    public float speed;
    public GameObject effect;

	// Use this for initialization
	void Start () {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 direction = new Vector3(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;
        target = new Vector2(mousePosition.x, mousePosition.y);

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
