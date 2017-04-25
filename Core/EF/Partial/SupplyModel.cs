using System.ComponentModel.DataAnnotations;

namespace Core.EF
{
    [MetadataType(typeof(SupplyModelMetadata))]
    public partial class SupplyModel
    {
        public string GetFullName()
        {
            return PartNumber + " " + Name;
        }
    }
}
