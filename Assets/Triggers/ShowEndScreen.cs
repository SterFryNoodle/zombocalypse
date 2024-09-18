using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class ShowEndScreen : MonoBehaviour
{
    [SerializeField] Canvas endOfGameScreen;

    private void Start()
    {
        endOfGameScreen.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        endOfGameScreen.enabled = true;
        Time.timeScale = 0; //Stops time in game.

        FindObjectOfType<WeaponSwitch>().enabled = false; //Disables the WeaponSwitch script after game is paused.
        FindObjectOfType<FirstPersonController>().enabled = false; //Disables player from looking around.
        FindObjectOfType<PlayerZoom>().enabled = false; //Disables player from zooming in.

        Cursor.lockState = CursorLockMode.None; //Unlocks cursor from center of screen.
        Cursor.visible = true; //Makes cursor visible to player.
    }
}
