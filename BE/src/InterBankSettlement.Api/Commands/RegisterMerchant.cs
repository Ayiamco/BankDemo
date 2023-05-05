using AutoMapper;
using BankDemo.Data.Entities;
using BankDemo.Data.Repositories.Interfaces;
using BankDemo.Infrastructure.Base;
using Dapper.BaseRepository.Config;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace InterBankSettlement.Api.Commands
{
    public class RegisterMerchant
    {
        public class Command : IRequest<BaseApiResponse<Response>>
        {
            [Required]
            public string Name { get; set; }

            [Required]
            public string BaseUrl { get; set; }
        }

        public class Response
        {
            public string UniqueCode { get; set; } = null!;
        }

        public class Handler : IRequestHandler<Command, BaseApiResponse<Response>>
        {
            private readonly IMerchantRepo merchantRepo;
            private readonly IMapper mapper;

            public Handler(IMerchantRepo merchantRepo, ILogger<RegisterMerchant> logger, IMapper mapper)
            {
                this.merchantRepo = merchantRepo;
                this.mapper = mapper;
            }
            public async Task<BaseApiResponse<Response>> Handle(Command request, CancellationToken cancellationToken)
            {
                var merchant = mapper.Map<Merchant>(request);
                merchant.Id = Guid.NewGuid();
                merchant.UniqueCode = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 12);
                var resp = await merchantRepo.RegisterMerchant(merchant);
                if (resp == CommandResp.Success)
                {
                    return new BaseApiResponse<Response>
                    {
                        Message = "Merchant created successfully",
                        Result = new Response { UniqueCode = merchant.UniqueCode },
                        StatusCode = HttpStatusCode.OK
                    };
                }

                return new BaseApiResponse<Response> { Message = "Failed to create merchant." };
            }
        }

        public class RegisterMerchantMapper : Profile
        {
            public RegisterMerchantMapper()
            {
                CreateMap<Command, Merchant>().
                    ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name));
            }
        }
    }
}
