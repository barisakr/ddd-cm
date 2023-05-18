 
using ChargeManagement.Application.Common.Commands.CreateBrand;
using ChargeManagement.Application.Common.Queries.GetBrandModels;
using ChargeManagement.Application.Common.Queries.GetBrands;
using ChargeManagement.Contracts.Common.CreateBrand;
using ChargeManagement.Contracts.Common.GetBrandModels;
using ChargeManagement.Contracts.Common.GetBrands;
using ChargeManagement.Domain.Brand;
using ChargeManagement.Domain.Brand.ValueObjects;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChargeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class CommonController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediatr;

        public CommonController(IMapper mapper, IMediator mediatr)
        {
            _mapper = mapper;
            _mediatr = mediatr;
        }

        [HttpPost]
        [Route("CreateBrand")]
        public async Task<IActionResult> CreateBrand([FromBody] CreateBrandRequest request)
        {
            {
                var command = _mapper.Map<CreateBrandCommand>((request));
                var createBrandResult = await _mediatr.Send(command);

                return createBrandResult.Match(
                    brand => Ok(_mapper.Map<CreateBrandResponse>(brand)),
                    errors => Problem(errors));

            }
        }

        [HttpGet]
        [Route("GetBrands")]
        public async Task<IActionResult> GetBrands()
        {
            var brandsResponseDto = new List<GetBrandsResponseDto>();

            var brandResult = await _mediatr.Send(new GetBrandsQuery());

            if (!brandResult.IsError)
            {
                foreach (var itemModel in brandResult.Value.data)
                {
                    var brand = new GetBrandsResponseDto(itemModel.Id.Value, itemModel.Name, itemModel.Description);
                    brandsResponseDto.Add(brand);
                }
            }
            return brandResult.Match(
            brand => Ok(brandsResponseDto),
            errors => Problem(errors));

        }


        [HttpGet]
        [Route("GetBrandModels")]
        public async Task<IActionResult> GetBrandModels([FromBody] GetBrandModelsRequest request)
        {
            try
            {

                var brandModelsResponseDto = new List<GetBrandModelsResponseDto>();
                var brandmodelResult = await _mediatr.Send(new GetBrandModelsQuery(BrandId.Create(request.BrandId)));


                if (!brandmodelResult.IsError)
                {
                    foreach (var itemModel in brandmodelResult.Value.data)
                    {
                        var brandModel = new GetBrandModelsResponseDto(
                            itemModel.Id.Value, itemModel.BrandId.Value, itemModel.Name, itemModel.Description);

                        brandModelsResponseDto.Add(brandModel);
                    }
                }

                return brandmodelResult.Match(
                    brand => Ok(brandModelsResponseDto),
                    errors => Problem(errors));

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}