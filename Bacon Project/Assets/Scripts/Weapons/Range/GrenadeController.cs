using UnityEngine;
using System.Collections;

public class GrenadeController : MonoBehaviour {

    private float radius = 2; // explosion radius
    private float damage = 10; // explosion damage
    private float explosionDelay = 3;

    Rigidbody rb;
    public LayerMask layersToDamage; 
    
    // Use this for initialization
    void Start ()
    {
        StartCoroutine(GrenadeExplode(explosionDelay));
    }

    IEnumerator GrenadeExplode(float delay)
    {
        yield return new WaitForSeconds(delay);

        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, radius, layersToDamage);

        int i = 0;
        while(i<hitColliders.Length)
        {
            Debug.Log("Hit " + hitColliders[i].name);
            i++;
        }
        Destroy(this.gameObject);
    }

    private void OnDrawGizmos() // Displays grenade radius
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
