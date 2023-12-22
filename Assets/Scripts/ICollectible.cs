namespace SpaceDodger
{
    public interface ICollectable
    {
        public void PlayEffects();
        public void PickedUp();
        public void DestroyCollectible();
    }   
}