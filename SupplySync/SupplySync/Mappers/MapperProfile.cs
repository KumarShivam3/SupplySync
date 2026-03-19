using AutoMapper;

namespace SupplySync.Mappers
{
    public partial class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // Initialize mappings for each domain/model
            ConfigureAuditMappings();
            ConfigureComplianceRecordMappings();
            ConfigureReportMappings();
<<<<<<< Updated upstream

            ConfigureInvoiceMappings();
            ConfigurePaymentMappings();


            ConfigureVendorMappings();
            ConfigureContractMappings();


            ConfigurePurchaseOrderAndDeliveryMappings();
=======
            ConfigurePurchaseOrderMappings();
            ConfigureDeliveryMappings();


>>>>>>> Stashed changes

        }
    }
}