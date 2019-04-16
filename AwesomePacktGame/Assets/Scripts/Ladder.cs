using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ladder : Interactable
{
    public Vector3 finalPosition;
    public float fallSpeed = 5;
    public AudioSource source;
    public AudioClip slideClip;
    public GameObject projector;

    public override void Interact(Player player)
    {
        SceneManager.LoadScene("GameOver");
        UIManager.Instance().DisplayMessage("Game Over!!!");
    }

    private void Start()
    {
        source.PlayOneShot(slideClip);
        projector.SetActive(true);
    }

    private void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, finalPosition, Time.deltaTime * fallSpeed);
    }
}
