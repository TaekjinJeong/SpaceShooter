using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerAnim
{
    public AnimationClip idle;
    public AnimationClip runF;
    public AnimationClip runB;
    public AnimationClip runR;
    public AnimationClip runL;
}
public class PlayerCtrl : MonoBehaviour {
    private float h = 0.0f, v = 0.0f, r = 0.0f;
    private Vector3 moveDir;
    private Transform tr;

    public PlayerAnim playerAnim;
    public Animation anim;

    public float moveSpeed = 10.0f;
    public float rotSpeed = 80.0f;

	// Use this for initialization
	void Start () {
        tr = GetComponent<Transform>();
        anim = GetComponent<Animation>();
        anim.clip = playerAnim.idle;
        anim.Play();
	}
	
	// Update is called once per frame
	void Update () {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxis("Mouse X");

        moveDir = (Vector3.forward * v) + (Vector3.right * h);
        tr.Translate(moveDir * moveSpeed * Time.deltaTime, Space.Self);
        tr.Rotate(Vector3.up * rotSpeed * r * Time.deltaTime);

        if (v >= 0.1f)
        {
            anim.CrossFade(playerAnim.runF.name, 0.3f);
        }
        else if (v <= -0.1f)
        {
            anim.CrossFade(playerAnim.runB.name, 0.3f);
        }
        else if (h >= 0.1f)
        {
            anim.CrossFade(playerAnim.runR.name, 0.3f);
        }
        else if (h <= -0.1f)
        {
            anim.CrossFade(playerAnim.runL.name, 0.3f);
        }
        else
            anim.CrossFade(playerAnim.idle.name, 0.3f);
	}
}
