using SupplySync.DTOs.Contract;
using SupplySync.DTOs.Vendor;
using SupplySync.Models;

namespace SupplySync.Mappers
{
	public partial class MapperProfile
	{
		public void ConfigureContractMappings()
		{
			CreateMap<CreateContractRequestDto, Contract>().ReverseMap();
			CreateMap<ContractResponseDto, Contract>().ReverseMap();
			CreateMap<UpdateContractRequestDto, Contract>().ReverseMap();

			CreateMap<CreateContractTermRequestDto, ContractTerm>().ReverseMap();
			CreateMap<ContractTermResponseDto, ContractTerm>().ReverseMap();

			CreateMap<ContractWithTermsResponseDto, Contract>()
				.ForMember(dest => dest.ContractTerms, opt => opt.MapFrom(src => src.Terms))
				.ReverseMap();

		}
	}
}
