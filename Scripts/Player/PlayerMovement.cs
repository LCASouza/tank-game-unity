using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rbPlayer;

    public new Camera camera;
    public GameObject baseTank;

    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotateSpeed;

    void FixedUpdate()
    {
        Vector3 targetV = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        movementTarget(targetV);

    }

    private void movementTarget(Vector3 targetV)
    {
        float velocidade = movementSpeed * Time.deltaTime;

        targetV = Quaternion.Euler(0, camera.gameObject.transform.eulerAngles.y, 0) * targetV;
        Vector3 targetP = transform.position + targetV * velocidade;
        transform.position = targetP;

        if (targetV.magnitude == 0)
        {
            return;
        }
        Quaternion rotation = Quaternion.LookRotation(targetV);
        baseTank.gameObject.transform.rotation = Quaternion.RotateTowards(baseTank.gameObject.transform.rotation, rotation, rotateSpeed);
    }
}
