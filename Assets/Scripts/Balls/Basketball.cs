using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basketball : Ball
{
    [SerializeField] float ShootForce = 1f;

    private void Start()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();
        points = 2;
        power = ShootForce;
    }
}
