using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] private float laserTime;
    [HideInInspector] public float laserLenght;
    [HideInInspector] public Transform firePoint;
    [HideInInspector] public Vector2 mousePos;
    private void Awake() 
    {
        lineRenderer = GetComponent<LineRenderer>();    
    }

    private void Start() 
    {
        StartCoroutine(LiveCycle());
    }

    private IEnumerator LiveCycle()
    {
        DrawLine();
        yield return new WaitForSeconds(laserTime);
        Destroy(this.gameObject);

    }
    public void DrawLine()
    {
        //lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, CalculateGPos());
    }

    private Vector2 CalculateGPos()
    {
        float distance = Vector2.Distance(firePoint.position, mousePos);
        Vector2 temp = Vector2.zero;
        temp.x = (laserLenght/distance)*(mousePos.x - firePoint.position.x) + firePoint.position.x;
        temp.y = (laserLenght/distance)*(mousePos.y - firePoint.position.y) + firePoint.position.y;

        return temp;
    }
}
