﻿using Ordering.Application.Models.DTOs._Public;

namespace Ordering.Application.Models.DTOs.GetOrdersByName;

public record GetOrdersByNameResult(IEnumerable<OrderDto> Orders);