namespace SpaceDodger
{
    public interface ICollectable
    {
        public void PlayEffects();
        public void SendPickedUpText();
        public void DestroyCollectible();
    }   
}