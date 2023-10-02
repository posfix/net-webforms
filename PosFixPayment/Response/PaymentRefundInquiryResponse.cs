using System;
namespace PosFixPayment.Response
{
    public class PaymentRefundInquiryResponse: BaseResponse
    {
        public string refundHash { get; set; }

        public string amount { get; set; }
    }
}
