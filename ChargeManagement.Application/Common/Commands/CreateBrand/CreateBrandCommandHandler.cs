﻿using ChargeManagement.Application.Common.Interfaces.Persistence;
using ChargeManagement.Domain.Brand;
using ErrorOr;
using MediatR;

namespace ChargeManagement.Application.Common.Commands.CreateBrand
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, ErrorOr<Brand>>
    {
        private readonly IBrandRepository _brandRepository;

        public CreateBrandCommandHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<ErrorOr<Brand>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var brand = Brand.Create( 
                name: request.Name,
                description: request.Description
                );

            _brandRepository.Add(brand);

            return brand;
        }
    }
}