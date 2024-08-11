using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineShop.Web.Models.Ordering;
using OnlineShop.Web.Services;

namespace OnlineShop.Web.Pages
{
    public class OrderListModel
        : PageModel
    {
        private readonly IOrderingService _orderingService;
        private readonly ILogger<OrderListModel> _logger;

        public OrderListModel(IOrderingService orderingService, ILogger<OrderListModel> logger)
        {
            _orderingService = orderingService;
            _logger = logger;
        }
        public IEnumerable<OrderModel> Orders { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            // assumption customerId is passed in from the UI authenticated user Reza
            var customerId = new Guid("58c49479-ec65-4de2-86e7-033c546291aa");

            var response = await _orderingService.GetOrdersByCustomer(customerId);
            Orders = response.Orders;

            return Page();
        }
    }
}
