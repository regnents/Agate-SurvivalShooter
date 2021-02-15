using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;
    Vector3 offset;
    
    // Start is called before the first frame update
    private void Start()
    {
        /* Mendapatkan offset antara camera dengan target */
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        /* Mendapatkan posisi kamera seharusnya */
        Vector3 targetCamPos = target.position + offset;
        /*Memindahkan posisi kamera ke posisi seharusnya secara perlahan */
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
