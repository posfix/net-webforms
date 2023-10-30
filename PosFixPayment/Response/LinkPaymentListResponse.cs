﻿using PosFixPayment.Entity;
using PosFixPayment.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosFixPayment.Response
{
    /// <summary>
    /// Linkle Ödeme -> Link Sorgulama/Listeleme Servisi çıktı parametre alanları temsil eder.
    /// </summary>
    public class LinkPaymentListResponse : BaseResponse
    {
     public List<PaymentLink> linkPaymentRecordList { get; set; }

     public string pageIndex { get; set; }
     public string pageSize { get; set; }
     public string pageCount { get; set; }

    }
}
