namespace VRTK.Examples.Archery
{
    using UnityEngine;

    public class BowAnimation : MonoBehaviour
    {
        public Animation animationTimeline;
        public Animation animationNocking;

        public void SetFrame(float frame)
        {
            animationTimeline["Bow_Bend"].speed = 0;
            animationTimeline["Bow_Bend"].time = frame;
            animationTimeline.Play("Bow_Bend");

        }
    }
}