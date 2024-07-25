using Discount.Grpc.Data;
using Discount.Grpc.Models;
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

    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        var coupon = request.Coupon.Adapt<Coupon>();
        if (coupon is null)
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid Request"));

        await _context.Coupons.AddAsync(coupon);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Discount is successfully created for product : {productName}", request.Coupon.ProductName);

        var couponModel = coupon.Adapt<CouponModel>();
        return couponModel;
    }

    public override Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        return base.DeleteDiscount(request, context);
    }

    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        var coupon = request.Coupon.Adapt<Coupon>();
        if (coupon is null)
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid Request"));

        _context.Coupons.Update(coupon);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Discount is successfully updated for product : {productName}", request.Coupon.ProductName);

        var couponModel = coupon.Adapt<CouponModel>();
        return couponModel;
    }

    #endregion
}