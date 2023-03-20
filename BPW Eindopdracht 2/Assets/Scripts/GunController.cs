using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public float laserDuration = 2f;
    public int maxReflections = 2;
    public GameObject hitboxPrefab;
    public GameObject laserStartPoint;
    private Transform playerTransform;
    private LineRenderer lineRenderer;
    private RaycastHit2D hit;

    private GameObject[] hitboxes;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = transform.parent;
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = true;

        hitboxes = new GameObject[maxReflections+1];
        for(int i = 0; i < hitboxes.Length; i++){
            hitboxes[i] = Instantiate(hitboxPrefab);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Aim gun
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;

        Vector3 direction = mousePos - playerTransform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        //Shoot lazer stuff
        Vector2 laserStart = laserStartPoint.transform.position;
        RaycastHit2D hit = Physics2D.Raycast(laserStart, transform.right);
        int reflections = 0;
        List<Vector3> laserPositions = new List<Vector3>();
        laserPositions.Add(laserStartPoint.transform.position);

        GameObject currentHitbox;
        while (reflections < maxReflections)
        {
            Debug.DrawLine(laserStart, hit.point, Color.black);
            Debug.Log("Reflect made: " + reflections);

            currentHitbox = hitboxes[reflections];
            currentHitbox.transform.position = hit.point;

            laserPositions.Add(hit.point);
            Vector2 reflectionDirection = Vector2.Reflect(hit.point - laserStart, hit.normal);
            laserStart = hit.point;
            hit = Physics2D.Raycast(hit.point + hit.normal * new Vector2(0.1f, 0.1f), reflectionDirection);

            reflections++;
        }

        currentHitbox = hitboxes[reflections];
        currentHitbox.transform.position = hit.point;

        Debug.DrawLine(laserStart, hit.point, Color.black);
        Debug.Log("Reflect made: " + reflections);
        laserPositions.Add(hit.point);
        lineRenderer.positionCount = laserPositions.Count;
        lineRenderer.SetPositions(laserPositions.ToArray());;
    }
}
