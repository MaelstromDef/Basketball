using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    protected int points = 1;
    [SerializeField] protected float power = 1f;
    protected Rigidbody rb;

    private void Start()
    {
        Init();
        ShootBall();
    }

    public virtual void ShootBall() {
        rb.AddForce(Vector3.up * power, ForceMode.Impulse);
    }

    protected virtual void Init() {
        rb = GetComponent<Rigidbody>();
    }
}
