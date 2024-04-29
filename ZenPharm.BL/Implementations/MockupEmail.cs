using Microsoft.AspNetCore.Identity;
using System.Text;
using ZenPharm.BL.Interfaces;
using ZenPharm.DAL.Models;

namespace ZenPharm.BL.Implementations;

public class MockupEmail
{
    private readonly IEmailService _emailService;
    private readonly UserManager<ZenPharmUser> _userManager;

    private const string _orderTemplate = "<!doctypehtml><html lang=en><meta charset=UTF-8><meta content=\"width=device-width,initial-scale=1\"name=viewport><link crossorigin=anonymous href=https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css integrity=sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC rel=stylesheet><div class=table-responsive><table border=0 cellpadding=0 cellspacing=0 style=background:#f3f3f3;width:100%;height:100%><tr><td style=padding:50px><table border=0 cellpadding=0 cellspacing=0 style=\"width:550px;margin:0 auto\"><tr><td style=padding-top:20px;align-items:center><img alt=Logo src=https://res.cloudinary.com/dwzqcfjad/image/upload/v1714379508/uigyhc5joqez4zphqqqb.png style=float:left;width:170px><tr><td style=\"border-radius:10px;background:#fff;padding:30px 60px 20px 60px;margin-top:20px;display:block\"><p style=font-family:Roboto;font-size:18px;font-weight:500;font-style:normal;font-stretch:normal;line-height:1.11;letter-spacing:normal;color:#2b80ff>Thanks for Purchase!<p style=font-family:Roboto;font-size:14px;font-weight:400;font-style:normal;font-stretch:normal;line-height:1.71;letter-spacing:normal;color:#001737>{Placed}<p style=font-family:Roboto;font-size:14px;font-weight:700;font-style:normal;font-stretch:normal;line-height:1.71;letter-spacing:normal;color:#001737;margin-top:35px>Your Order #{OrderId}<table border=0 cellpadding=0 cellspacing=0 style=width:100%><tbody>{Produse}<tr><td style=font-family:Roboto;font-size:14px;font-weight:700;font-style:normal;font-stretch:normal;line-height:1.71;letter-spacing:normal;color:#001737;padding-top:15px colspan=2>Total<td style=text-align:right;font-family:Roboto;font-size:14px;font-weight:700;font-style:normal;font-stretch:normal;line-height:1.71;letter-spacing:normal;text-align:right;color:#001737;padding-top:15px>{Total}</table></table></table></div>";
    private const string _orderItemTemplate = "<tr style=\"border-bottom:solid 1px #ddd\"><td style=padding-top:10px;padding-bottom:10px;font-family:Roboto;font-size:14px;font-weight:400;font-style:normal;font-stretch:normal;line-height:1.71;letter-spacing:normal;color:#001737>{ProdName}<td style=text-align:right;font-family:Roboto;font-size:14px;font-weight:500;font-style:normal;font-stretch:normal;line-height:1.71;letter-spacing:normal;text-align:right;color:#001737>X{ProdQ}<td style=text-align:right;font-family:Roboto;font-size:14px;font-weight:500;font-style:normal;font-stretch:normal;line-height:1.71;letter-spacing:normal;text-align:right;color:#001737>{ProdP}";
    private const string _notificationTemplate = "<!doctypehtml><html lang=en><meta charset=UTF-8><meta content=\"width=device-width,initial-scale=1\"name=viewport><link crossorigin=anonymous href=https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css integrity=sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC rel=stylesheet><div class=table-responsive><table border=0 cellpadding=0 cellspacing=0 style=background:#f3f3f3;width:100%;height:100%><tr><td style=padding:50px><table border=0 cellpadding=0 cellspacing=0 style=\"width:550px;margin:0 auto\"><tr><td style=padding-top:20px;align-items:center><img alt=Logo src=https://res.cloudinary.com/dwzqcfjad/image/upload/v1714379508/uigyhc5joqez4zphqqqb.png style=float:left;width:170px><tr><td style=\"border-radius:10px;background:#fff;padding:30px 60px 20px 60px;margin-top:20px;display:block\"><p style=font-family:Roboto;font-size:14px;font-weight:400;font-style:normal;font-stretch:normal;line-height:1.71;letter-spacing:normal;color:#001737>Placed: {Placed}<p style=font-family:Roboto;font-size:14px;font-weight:700;font-style:normal;font-stretch:normal;line-height:1.71;letter-spacing:normal;color:#001737;margin-top:35px>Order #{OrderId}<table border=0 cellpadding=0 cellspacing=0 style=width:100%><tbody>{Prods}<tr><td style=font-family:Roboto;font-size:14px;font-weight:700;font-style:normal;font-stretch:normal;line-height:1.71;letter-spacing:normal;color:#001737;padding-top:15px colspan=2>Total<td style=text-align:right;font-family:Roboto;font-size:14px;font-weight:700;font-style:normal;font-stretch:normal;line-height:1.71;letter-spacing:normal;text-align:right;color:#001737;padding-top:15px>{Total}<tr><td style=font-family:Roboto;font-size:14px;font-style:normal;font-stretch:normal;line-height:1.71;letter-spacing:normal;color:#001737;padding-top:15px colspan=3>Check the ZenPharm Dasboard / Orders page</table></table></table></div>";

    public MockupEmail(IEmailService emailService, UserManager<ZenPharmUser> userManager)
    {
        _emailService = emailService;
        _userManager = userManager;
    }

    public async Task SendClientEmail(Order order)
    {
        var user = await _userManager.FindByIdAsync(order.UserID.ToString());
        var message = GenerateOrderMessage(order);
        var emailRequest = _emailService.FormEmailRequest(null, user.Email, "ZenPharm: Order Checkout", message);
        await _emailService.SendEmail(emailRequest);
    }

    public async Task SendModeratorEmail(Order order)
    {
        var moderators = await _userManager.GetUsersInRoleAsync("Moderator");
        if (moderators is not null)
        {
            var emails = moderators.Select(m => m.Email).ToList();
            var moderatorMessage = GenerateNotificationMessage(order);
            foreach (var email in emails)
            {
                var emailRequest = _emailService.FormEmailRequest(null, email, "ZenPharm: new order was placed", moderatorMessage);
                await _emailService.SendEmail(emailRequest);
            }
        }
    }

    private string GenerateOrderMessage(Order order)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(_orderTemplate);
        sb.Replace("{Placed}", $"{order.Placed}");
        sb.Replace("{OrderId}", $"{order.ID.ToString().Substring(0, 5)}");
        StringBuilder prods = new StringBuilder();
        foreach (var item in order.OrderItems)
        {
            prods.Append(_orderItemTemplate);
            prods.Replace("{ProdName}", $"{item.OrderItemProduct.Name}");
            prods.Replace("{ProdQ}", $"{item.Quantity}");
            prods.Replace("{ProdP}", $"{item.OrderItemProduct.Price}");
        }
        sb.Replace("{Produse}", prods.ToString());
        sb.Replace("{Total}", $"{CalculateTotal(order)}");
        return sb.ToString();
    }

    private string GenerateNotificationMessage(Order order)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(_notificationTemplate);
        sb.Replace("{Placed}", $"{order.Placed}");
        sb.Replace("{OrderId}", $"{order.ID.ToString().Substring(0, 5)}");
        StringBuilder prods = new StringBuilder();
        foreach (var item in order.OrderItems)
        {
            prods.Append(_orderItemTemplate);
            prods.Replace("{ProdName}", $"{item.OrderItemProduct.Name}");
            prods.Replace("{ProdQ}", $"{item.Quantity}");
            prods.Replace("{ProdP}", $"{item.OrderItemProduct.Price}");
        }
        sb.Replace("{Prods}", prods.ToString());
        sb.Replace("{Total}", $"{CalculateTotal(order)}");
        return sb.ToString();
    }

    private decimal CalculateTotal(Order order)
    {
        decimal total = 0;
        foreach (var item in order.OrderItems)
        {
            total += item.Quantity * item.OrderItemProduct.Price;
        }
        return total;
    }
}
