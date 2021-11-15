using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounceSound : MonoBehaviour
{
    [SerializeField] AudioClip beepEffect;
    [SerializeField] AudioClip boopEffect;
    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Brick") || other.gameObject.CompareTag("StrongBrick")) {
            GetComponent<AudioSource>().PlayOneShot(beepEffect);
        } else if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Player" || other.gameObject.tag == "LargerPlayer") {
            GetComponent<AudioSource>().PlayOneShot(boopEffect);
        }
    }
}
