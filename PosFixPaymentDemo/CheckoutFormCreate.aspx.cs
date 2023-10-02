using System;
using System.Collections.Generic;
using PosFix.DeveloperPortal.Core.Request;
using PosFix.DeveloperPortal.Core.Response;
using PosFixPayment;
using PosFixPayment.Entity;
using Newtonsoft.Json;

namespace PosFixPaymentDemo
{
    public partial class CheckoutFormCreate : System.Web.UI.Page
    {

        protected void BtnCreateCheckoutForm_Click(object sender, EventArgs e)
        {
            Settings settings = new();
            CheckoutFormCreateRequest request = new();
            request.OrderId = Guid.NewGuid().ToString();
            request.Version = settings.Version;
            request.Amount = 10000;
            request.CallbackUrl = "https://apitest.posfix.com.tr/rest/payment/threed/test/result";
            request.VendorId = "10100";
            request.Threed = "false";
            request.AllowedInstallments = new HashSet<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };

            request.Echo = "";
            request.Mode = settings.Mode;
            request.Language = "tr-TR";

            request.Purchaser = new();
            request.Purchaser.Name = "Ahmet";
            request.Purchaser.SurName = "Veli";
            request.Purchaser.BirthDate = "1986-07-11";
            request.Purchaser.Email = "ahmet@veli.com";
            request.Purchaser.GsmPhone = "5881231212";
            request.Purchaser.IdentityNumber = "12345678901";
            request.Purchaser.ClientIp = "127.0.0.1";

            request.Purchaser.InvoiceAddress = new();
            request.Purchaser.InvoiceAddress.Name = "Ahmet";
            request.Purchaser.InvoiceAddress.SurName = "Veli";
            request.Purchaser.InvoiceAddress.Address = "Mevlüt Pehlivan Mah. PosFix Plaza Şişli";
            request.Purchaser.InvoiceAddress.ZipCode = "34782";
            request.Purchaser.InvoiceAddress.CityCode = "34";
            request.Purchaser.InvoiceAddress.IdentityNumber = "12345678901";
            request.Purchaser.InvoiceAddress.CountryCode = "TR";
            request.Purchaser.InvoiceAddress.TaxNumber = "123456";
            request.Purchaser.InvoiceAddress.TaxOffice = "Kozyatağı";
            request.Purchaser.InvoiceAddress.CompanyName = "PosFix";
            request.Purchaser.InvoiceAddress.PhoneNumber = "2122222222";

            request.Purchaser.ShippingAddress = new();
            request.Purchaser.ShippingAddress.Name = "Ahmet";
            request.Purchaser.ShippingAddress.SurName = "Veli";
            request.Purchaser.ShippingAddress.Address = "Mevlüt Pehlivan Mah. PosFix Plaza Şişli";
            request.Purchaser.ShippingAddress.ZipCode = "34782";
            request.Purchaser.ShippingAddress.CityCode = "34";
            request.Purchaser.ShippingAddress.IdentityNumber = "12345678901";
            request.Purchaser.ShippingAddress.CountryCode = "TR";
            request.Purchaser.ShippingAddress.PhoneNumber = "2122222222";

            request.Products = new List<Product>();
            Product p = new();
            p.Title = "Telefon";
            p.Code = "TLF0001";
            p.Price = "5000";
            p.Quantity = 1;
            request.Products.Add(p);

            p = new();
            p.Title = "Bilgisayar";
            p.Code = "BLG0001";
            p.Price = "5000";
            p.Quantity = 1;
            request.Products.Add(p);

            CheckoutFormCreateResponse response = CheckoutFormCreateRequest.Execute(request, settings);
            string jsonResponse = JsonConvert.SerializeObject(response, Formatting.Indented);
            string encodedJsonResponse = System.Web.HttpUtility.HtmlEncode(jsonResponse);
            result.InnerHtml = "<pre>" + encodedJsonResponse + "</pre>";
        }
    }
}
