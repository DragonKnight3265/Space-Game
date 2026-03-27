using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Transition : MonoBehaviour
{
    //Temporary
        public Image fadeImage;
        public float fadeSpeed = 2f;

        public IEnumerator FadeOut()
        {
            float t = 0;

            while (t < 1)
            {
                t += Time.deltaTime * fadeSpeed;
                fadeImage.color = new Color(0, 0, 0,0);
                yield return null;
            }
            Debug.Log("Fade out");
        }

        public IEnumerator FadeIn()
        {
            float t = 1;

            while (t > 0)
            {
                t -= Time.deltaTime * fadeSpeed;
                fadeImage.color = new Color(0, 0, 0, 100);
                yield return null;
            }
            Debug.Log("Fade in");
        }

}
