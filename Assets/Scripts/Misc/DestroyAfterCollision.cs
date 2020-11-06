using UnityEngine;

public class DestroyAfterCollision : MonoBehaviour {
    public Collider2D obstacleCollider;
    public GameObject[] vehicles;

    public float timeToDestroy = 2f;

    private bool touched = false;
	
	// Update is called once per frame
	void FixedUpdate () {
        foreach(GameObject veh in vehicles) {
            if (veh.gameObject.activeSelf && Physics2D.IsTouching(obstacleCollider, veh.gameObject.GetComponent<PolygonCollider2D>())) {
                touched = true;
            }
        }
        if (touched) {
            timeToDestroy -= Time.fixedDeltaTime;
            if (timeToDestroy < 0) {
                Destroy(gameObject);
            }
        }
    }
}
