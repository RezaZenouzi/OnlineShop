using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineShop.Web.Models.Basket;
using OnlineShop.Web.Services;

namespace OnlineShop.Web.Pages
{
    public class CheckoutModel
        : PageModel
    {
        private readonly IBasketService _basketService;
        private readonly ILogger<CheckoutModel> _logger;

        public CheckoutModel(IBasketService basketService, ILogger<CheckoutModel> logger)
        {
            _basketService = basketService;
            _logger = logger;
        }

        [BindProperty]
        public BasketCheckoutModel Order { get; set; } = default!;
        public ShoppingCartModel Cart { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            Cart = await _basketService.LoadUserBasket();

            return Page();
        }

        public async Task<IActionResult> OnPostCheckOutAsync()
        {
            _logger.LogInformation("Checkout button clicked");

            Cart = await _basketService.LoadUserBasket();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // assumption customerId is passed in from the UI authenticated user swn        
            Order.CustomerId = new Guid("58c49479-ec65-4de2-86e7-033c546291aa");
            Order.UserName = Cart.UserName;
            Order.TotalPrice = Cart.TotalPrice;

            await _basketService.CheckoutBasket(new CheckoutBasketRequest(Order));

            return RedirectToPage("Confirmation", "OrderSubmitted");
        }
    }
}
