﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardUnit : Unit
{
    [Header("Awoken Unit Upgrades")]
    public AwokenUnit firstChoice;
    public AwokenUnit secondChoice;
    public int levelToAwaken;
    internal bool isAwoken;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    public void Awaken(StandardUnit unitToAwaken)
    {

    }
}