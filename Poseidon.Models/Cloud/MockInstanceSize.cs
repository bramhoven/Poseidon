namespace Poseidon.Models.Cloud
{
    public class MockInstanceSize : InstanceSizeBase
    {
        #region Methods

        public override string GetSizeDefinition()
        {
            return Name;
        }

        #endregion
    }
}