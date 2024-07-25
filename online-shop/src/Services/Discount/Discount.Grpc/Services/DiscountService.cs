using Discount.Grpc.Data;
using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Services;

public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
{
    private readonly DiscountContext _context;
    private readonly ILogger<DiscountService> _logger;

    public DiscountService(DiscountContext context, ILogger<DiscountService> logger)
    {
        _context = context;
        _logger = logger;
    }

    #region Queries

    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        var coupon = await _context.Coupons.FirstOrDefaultAsync(x => x.ProductName == request.ProductName);
        if (coupon is null)
            return new CouponModel() { Id = 0, ProductName = "No Discount", Amount = 0, Description = "No Discount" };

        _logger.LogInformation("Discount is retrieved for product : {productName}", request.ProductName);

        var couponModel = coupon.Adapt<CouponModel>();
        return couponModel;
    }

    #endregion

    #region Commands

    public override Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        return base.CreateDiscount(request, context);
    }

    public override Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        return base.DeleteDiscount(request, context);
    }

    public override Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        return base.UpdateDiscount(request, context);
    }

    #endregion
}