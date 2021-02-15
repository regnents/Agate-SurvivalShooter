using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLength = 100f;

    private void Awake()
    {
        // Inisiasi atribut milik PlayerMovement

        /* nilai mask dari layer floor */
        floorMask = LayerMask.GetMask("Floor");
        /* komponen animator object Player */
        anim = GetComponent<Animator>();
        /* komponen Rigidbody object Player */
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        /* mendapatkan nilai input horizontal */
        /* GetAxisRaw memberikan nilai -1,0, atau 1 */
        float h = Input.GetAxisRaw("Horizontal");
        /* mendapatkan nilai input vertical */
        float v = Input.GetAxisRaw("Vertical");

        /* Panggil method Move untuk menggerakkan object Player */
        Move(h, v);
        /* Panggil method Turning untuk menngatur arah object Player menghadap */
        Turning();
        Animating(h, v);
    }

    public void Move(float h, float v)
    {
        // MENGATUR GERAK DARI OBJECT PLAYER

        /* Set nilai dari Vector3 movement */
        /* nilai Y dibuat 0 karena tidak bergerak atas bawah */
        movement.Set(h, 0f, v);

        /* movement di-normalize */
        movement = movement.normalized * speed * Time.deltaTime;

        /* Memindahkan object player ke posisi baru*/
        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        // MEROTASI SISI DEPAN OBJECT PLAYER KE POSISI MOUSE BERADA
        
        /* Mendapatkan Ray dari Main Camera ke posisi kursor mouse */
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            /* Mendapatkan vector arah dari player ke titik floorHit */
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            /* Mendapatkan nilai quaternion vector arah player ke playerToMouse */
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            /* Merotasi player */
            playerRigidbody.MoveRotation(newRotation);
        }
    }

    public void Animating(float h, float v)
    {
        // MENGUBAH NILAI BOOLEAN IsWalking BERDASARKAN NILAI h DAN v
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }
}
