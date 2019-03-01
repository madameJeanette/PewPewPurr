using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : MonoBehaviour {
    public delegate void OnHitSpikeAction();
    public delegate void OnHitGoombaAction();
    public delegate void OnHitOrbAction();

    public OnHitGoombaAction OnHitGoomba;
    public OnHitSpikeAction OnHitSpike;
    public OnHitOrbAction OnHitOrb;

    float speed = 100;
    float jumpSpeed = 10000;

    public GameObject bulletPrefab;

    Vector3 leftBound;
    Vector3 rightBound;
    bool canJump;
    bool lookingRight = true;

    void Update() {

        processInput();


    }

    void processInput()
    {

    }
}
