namespace Poseidon.Models.Cloud
{
    public class MockInstanceImage : InstanceImageBase
    {
        #region Methods

        public override string GetImageDefinition()
        {
            return Name;
        }

        #endregion
    }
}