﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunShell : LinearProjectile
{
    [Header("Properties")]
    public int burstCount = 10;

    [Range(0f, 2f)]
    public float scatterOffset = 0.5f;
    public float minSpeedOffset = 0.95f;     // Modifier used to slightly vary the projectile speed
    public float maxSpeedOffset = 1.15f;

    public GameObject muzzleFlash;

    private readonly float flashTime = 1.5f;

    protected override void Start()
    {
        base.Start();

        if (muzzleFlash != null)
        {
            GameObject flashEffect = Instantiate(muzzleFlash, transform.position, transform.rotation);
            Destroy(flashEffect, flashTime);
        }

        for (int i = 0; i < burstCount; i++)
        {
            ShotgunShell newProjectile = Instantiate(this, transform.position, Quaternion.identity);
            newProjectile.Damage = Damage;
            newProjectile.Target = Target;
            newProjectile.speed = speed * Random.Range(minSpeedOffset, maxSpeedOffset);
            newProjectile.muzzleFlash = null;
            newProjectile.burstCount = 0;
        }
    }

    protected override void FaceTarget()
    {
        Enemy targetEnemy = Target.GetComponent<Enemy>();
        Vector3 targetPos = targetEnemy.transform.position;

        Vector3 scatterPos = new Vector3(targetPos.x + Random.Range(-scatterOffset, scatterOffset),
            targetPos.y + Random.Range(-scatterOffset, scatterOffset), targetPos.z);

        if (targetEnemy != null && !targetEnemy.isUnderForces)
        {
            scatterPos = CalculateFuturePosition(targetEnemy, scatterPos);
        }

        transform.right = scatterPos - transform.position;
    }

}
