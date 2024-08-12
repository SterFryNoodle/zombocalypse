using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverScreen;

    void Start()
    {
        gameOverScreen.enabled = false;
    }

    public void HandleDeath()
    {
        gameOverScreen.enabled = true;
        Time.timeScale = 0; //Stops time in game.
        FindObjectOfType<WeaponSwitch>().enabled = false; //Disables the WeaponSwitch script after game is paused.

        Cursor.lockState = CursorLockMode.None; //Unlocks cursor from center of screen.
        Cursor.visible = true; //Makes cursor visible to player.
    }
}
