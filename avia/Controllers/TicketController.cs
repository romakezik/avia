using System.Linq;
using System.Security.Claims;
using avia.Models;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class TicketController : Controller
{
    private readonly EFDBContext _context;
    private readonly TicketSearchResultsViewModel model; // объявляем переменную model как поле класса

    public TicketController(EFDBContext context)
    {
        _context = context;
        model = new TicketSearchResultsViewModel(); // инициализируем переменную model в конструкторе
    }

    public IActionResult Cart()
    {
        if (HttpContext.Session.GetString("UsersId") != null)
        {
            int userId = Int32.Parse(HttpContext.Session.GetString("UsersId"));

            var orderedTickets = _context.OrderedTickets
                .Include(ot => ot.Ticket)
                .Where(ot => ot.Order.UserID == userId)
                .ToList();

            var order = _context.Orders
                .Where(o => o.UserID == userId)
                .FirstOrDefault();

            var cartViewModel = new CartViewModel()
            {
                OrderedTickets = orderedTickets,
                Order = order
            };

            return View(cartViewModel);
        }
        else
        {
            return RedirectToAction("Privacy", "Home");
        }
    }

    [HttpPost]
    public IActionResult ConfirmOrder(string passportNumber, string fullName)
    {
        int userId = Int32.Parse(HttpContext.Session.GetString("UsersId"));
        var order = _context.Orders
        .Where(o => o.UserID == userId)
        .FirstOrDefault();
        // Check passport number
        if (string.IsNullOrEmpty(passportNumber))
        {
            TempData["ErrorMessage"] = "Invalid passport number.";
            return View();
        }

      

        // Set success message
        string message = $"Заказ номер {order.OrdersID} оформлен, за потверждением паспортных данных, а также оплатой явиться по адресу одного из пунктов компании.";
        ViewBag.SuccessMessage = message;

        return View();
    }

    [HttpGet]
    public IActionResult Search()
    {
        if (HttpContext.Session.GetString("UsersId") != null)
        {
          var searchModel = new TicketSearchViewModel()
        {
            Airlines = _context.Airlines.ToList(),
            Cities = _context.Destinations.ToList()
        };

        return View(searchModel); 
        }
        else
        {
            return RedirectToAction("Privacy", "Home");
        }
        
    }

    [HttpPost]
    public IActionResult Search(TicketSearchViewModel search)
    {
        if (HttpContext.Session.GetString("UsersId") != null)
        {
            try
            {
                var query = _context.Tickets
                    .Include(t => t.Flight)
                        .ThenInclude(f => f.Airline)
                    .Include(t => t.Flight)
                        .ThenInclude(f => f.DepartureCity)
                    .Include(t => t.Flight)
                        .ThenInclude(f => f.ArrivalCity)
                    .AsQueryable();

                if (search.AirlineID.HasValue)
                {
                    query = query.Where( t => t.Flight.AirlineID == search.AirlineID.Value);
                }

                if (search.DepartureCityID.HasValue)
                {
                    query = query.Where(t => t.Flight.DepartureCityID == search.DepartureCityID.Value);
                }

                if (search.ArrivalCityID.HasValue)
                {
                    query = query.Where(t => t.Flight.ArrivalCityID == search.ArrivalCityID.Value);
                }

                if (search.StartDate.HasValue)
                {
                    query = query.Where(t => t.Flight.DepartureDate >= search.StartDate.Value);
                }

                if (search.EndDate.HasValue)
                {
                    query = query.Where(t => t.Flight.DepartureDate <= search.EndDate.Value);
                }

                var userId = User.Identity.IsAuthenticated ? User.FindFirst(ClaimTypes.NameIdentifier).Value : null;
                model.UserId = userId;


                model.Tickets = query
                    .Select(t => new TicketViewModel()
                    {
                        TicketID = t.TicketsID,
                        AirlineName = t.Flight.Airline.Name,
                        FlightNumber = t.Flight.FlightNumber,
                        DepartureDate = t.Flight.DepartureDate,
                        DepartureCity = _context.Destinations.FirstOrDefault(c => c.DestinationsID == t.Flight.DepartureCityID).CityName,
                        ArrivalCity = _context.Destinations.FirstOrDefault(c => c.DestinationsID ==
                        t.Flight.ArrivalCityID).CityName,
                        Price = t.Price,
                        Status = t.Status
                    })
                    .ToList();

                if (search.SortByPrice)
                {
                    model.Tickets = model.Tickets.OrderBy(t => t.Price).ToList();
                }
                else
                {
                    model.Tickets = model.Tickets.OrderBy(t => t.DepartureDate).ToList();
                }

                return View("SearchResults", model);
            }
            catch (Exception ex)
            {
                return Content($"Произошла ошибка: {ex.Message}");
            }
        }
        else
        {
            return RedirectToAction("Privacy", "Home");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Book(int ticketId)
    {
        // Найти билет в базе данных по его ID
        var ticket = await _context.Tickets.FindAsync(ticketId);

        // Если билет не найден, вернуть ошибку
        if (ticket == null)
        {
            TempData["ErrorMessage"] = "Билет не найден";
            return RedirectToAction("Index", "Home");
        }

        // Если билет уже забронирован, вернуть ошибку
        if (ticket.Status != "Available")
        {
            TempData["ErrorMessage"] = "Билет уже забронирован";
            return RedirectToAction("Index", "Home");
        }

        // Изменить статус билета на "Недоступен"
        ticket.Status = "Недоступен";

        // Создать новый объект типа OrderedTicket

        if (HttpContext.Session.GetString("UsersId") != null)
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(100);
            var orderedTicket = new OrderedTickets()
            {
                OrderedTicketsID = ticketId,
                OrderID = rnd.Next(1,10000000), // Заменить на ID заказа
                TicketID = ticket.TicketsID,
                Quantity = 1 // Можно изменить на другое значение, если нужно
            };
            var order = new Orders()
            {
                OrderDate = DateTime.Now,
                OrdersID = orderedTicket.OrderID,
                UserID = Int32.Parse(HttpContext.Session.GetString("UsersId"))
            };
            _context.OrderedTickets.Add(orderedTicket);
            _context.Orders.Add(order);

        }
        else
        {
            return RedirectToAction("Login", "Account");
        }


        // Добавить объект OrderedTicket в контекст базы данных


        // Сохранить изменения в базе данных
        await _context.SaveChangesAsync();

        TempData["SuccessMessage"] = "Билет успешно забронирован";
        return RedirectToAction("Index", "Home");
    }

}


