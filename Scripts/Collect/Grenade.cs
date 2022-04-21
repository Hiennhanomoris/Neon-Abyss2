using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Collect
{
    public class Grenade : MonoBehaviour
    {
        private Rigidbody2D grenadeRb;
        private Transform thisTransform;
        [SerializeField] private float radius;
        

        private void Awake()
        {
            grenadeRb = GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(!collision.CompareTag("Player"))
            {
                Collider[] hitcollider = Physics.OverlapSphere(thisTransform.position, radius);
                Destroy(this.gameObject);
            }
        }
    }
}