using PosFixPayment;
using PosFixPayment.Entity;
using PosFixPayment.Request;
using PosFixPayment.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PosFixPaymentDemo
{
    public partial class NonThreeDPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cardOwnerName.Value = "Fatih Coşkun";
                cardNumber.Value = "5456165456165454";
                cardExpireMonth.Value = "12";
                cardExpireYear.Value = "24";
                cardCvc.Value = "000";
                amount.Value = "10000";
            }
        }

        protected void BtnApiPayment_Click(object sender, EventArgs e)
        {
            Settings settings = new();
            Non3DPaymentRequest request = new();
            request.OrderId = Guid.NewGuid().ToString();
            request.Echo = "Echo";
            request.Mode = settings.Mode;
            request.Amount = amount.Value;
            request.CardOwnerName = cardOwnerName.Value;
            request.CardNumber = cardNumber.Value;
            request.CardExpireMonth = cardExpireMonth.Value;
            request.CardExpireYear = cardExpireYear.Value;
            request.Installment = installment.Value;
            request.Cvc = cardCvc.Value;
            request.ThreeD = "false";
            request.CardId = "";
            request.UserId = "";

            request.Purchaser = new Purchaser();
            request.Purchaser.Name = "Ahmet";
            request.Purchaser.SurName = "Veli";
            request.Purchaser.BirthDate = "1986-07-11";
            request.Purchaser.Email = "ahmet@veli.com";
            request.Purchaser.GsmPhone = "5881231212";
            request.Purchaser.IdentityNumber = "12345678901";
            request.Purchaser.ClientIp = "127.0.0.1";

            request.Purchaser.InvoiceAddress = new PurchaserAddress();
            request.Purchaser.InvoiceAddress.Name = "Ahmet";
            request.Purchaser.InvoiceAddress.SurName = "Veli";
            request.Purchaser.InvoiceAddress.Address = "Mevlüt Pehlivan Mah. PosFix Plaza Şişli";
            request.Purchaser.InvoiceAddress.ZipCode = "34782";
            request.Purchaser.InvoiceAddress.CityCode = "34";
            request.Purchaser.InvoiceAddress.IdentityNumber = "1234567890";
            request.Purchaser.InvoiceAddress.CountryCode = "TR";
            request.Purchaser.InvoiceAddress.TaxNumber = "123456";
            request.Purchaser.InvoiceAddress.TaxOffice = "Kozyatağı";
            request.Purchaser.InvoiceAddress.CompanyName = "PosFix";
            request.Purchaser.InvoiceAddress.PhoneNumber = "2122222222";

            request.Purchaser.ShippingAddress = new PurchaserAddress();
            request.Purchaser.ShippingAddress.Name = "Ahmet";
            request.Purchaser.ShippingAddress.SurName = "Veli";
            request.Purchaser.ShippingAddress.Address = "Mevlüt Pehlivan Mah. PosFix Plaza Şişli";
            request.Purchaser.ShippingAddress.ZipCode = "34782";
            request.Purchaser.ShippingAddress.CityCode = "34";
            request.Purchaser.ShippingAddress.IdentityNumber = "1234567890";
            request.Purchaser.ShippingAddress.CountryCode = "TR";
            request.Purchaser.ShippingAddress.PhoneNumber = "2122222222";

            request.Products = new List<Product>();
            Product p = new();
            p.Title = "Telefon";
            p.Code = "TLF0001";
            p.Price = "5000"; //50.00 TL
            p.Quantity = 1;
            request.Products.Add(p);

            p = new Product();
            p.Title = "Bilgisayar";
            p.Code = "BLG0001";
            p.Price = "5000"; //50.00 TL
            p.Quantity = 1;
            request.Products.Add(p);

            Non3DPaymentResponse response = Non3DPaymentRequest.Execute(request, settings);
            string jsonResponse = JsonConvert.SerializeObject(response, Formatting.Indented);
            result.InnerHtml = "<pre>" + jsonResponse + "</pre>";
        }
    }
}
