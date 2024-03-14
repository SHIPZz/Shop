﻿using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Shop.Commands;
using Shop.Data;
using Shop.Models;
using Shop.Services;
using Shop.Validators;

namespace Shop.Handlers;

public class AddDeviceModelHandler : IRequestHandler<AddOrderedDeviceModelCommand, OrderedDeviceModel>
{
    private readonly UnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<AddOrderedDeviceModelCommand> _validator;
    private readonly OrderedDeviceDatabaseService _orderedDeviceDatabaseService;

    public AddDeviceModelHandler(UnitOfWork unitOfWork, IMapper mapper, IValidator<AddOrderedDeviceModelCommand> validator, OrderedDeviceDatabaseService orderedDeviceDatabaseService)
    {
        _orderedDeviceDatabaseService = orderedDeviceDatabaseService;
        _mapper = mapper;
        _validator = validator;
        _unitOfWork = unitOfWork;
    }

    public async Task<OrderedDeviceModel> Handle(AddOrderedDeviceModelCommand request, CancellationToken cancellationToken)
    {
        ValidationResult? validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        BaseRepository<OrderedDeviceModel> repo = _unitOfWork.Resolve<BaseRepository<OrderedDeviceModel>, OrderedDeviceModel>();

        var orderedDeviceModel = _mapper.Map<OrderedDeviceModel>(request);
        _orderedDeviceDatabaseService.OrderedDevice = orderedDeviceModel;
        await repo.Add(orderedDeviceModel);
        await _unitOfWork.SaveChangesAsync();
        return orderedDeviceModel;
    }
}