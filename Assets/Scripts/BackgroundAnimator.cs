using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundAnimation : MonoBehaviour
{
    /*
     -- NOTE --
     This is a pretty brute-force way of implementing the fading and movement between backgrounds.
     The only reason why this approach was selected due to lower implementation time, which was prioritized in a period of heavy time constraint.
     TODO if possible, switch to a more efficient approach (perhaps using built-in Unity transitions and animations?)
    */

    // Refs to the background images are stored in an array
    public Image[] backgroundImages;
    // The index of the current image is tracked using a variable
    private int currentIndex;
    // A float is used to track the time when the fade should occur
    private float fadeTimer;
    // Another float is used to specify the fade duration
    private readonly float fadeDuration = 5f;
    // A boolean flag is used to track the state of the fade effect
    private bool isFading = false;
    // A vector to adjust background movement speed and direction
    private Vector2 movementVector = new Vector2(0f, 0f);

    void Start()
    {
        // Initialize parameters
        currentIndex = 0;
        fadeTimer = 0f;
    }

    void Update()
    {
        // Start the timer (initialization here works due to the Update method updating the timer every frame)
        fadeTimer += Time.deltaTime;

        // If it is time to fade to the next background picture
        if (fadeTimer > fadeDuration)
        {
            // Reset the timer and update parameters to indicate a background switch
            fadeTimer = 0f;
            currentIndex = (currentIndex + 1) % backgroundImages.Length;
            isFading = true;

            // If all the backgrounds were iterated through
            if (currentIndex == backgroundImages.Length)
            {
                // We start iterating again from the first one
                currentIndex = 0;
            }
        }

        // If the background is not fading
        if (!isFading)
        {
            // Move the background as per the vector defined in the parameters
            backgroundImages[currentIndex].rectTransform.anchoredPosition += movementVector * Time.deltaTime;
        }

        // TODO a coroutine can likely be used to do this, but knowledge and time constraints prevented me from going that far
        if (isFading)
        {
            // Fade out the current image
            backgroundImages[currentIndex].color = Color.Lerp(backgroundImages[currentIndex].color, Color.clear, fadeTimer);

            // If fading out is complete
            if (backgroundImages[currentIndex].color.a <= 0.01f)
            {
                // Reset fading flag and set the next image to transparent before fading it in
                isFading = false;
                backgroundImages[currentIndex].color = new Color(1f, 1f, 1f, 0f);

                // Fade in next image
                backgroundImages[currentIndex].CrossFadeColor(Color.white, 1f, true, true);
            }
        }
    }
}
