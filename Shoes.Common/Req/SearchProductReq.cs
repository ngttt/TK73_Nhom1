using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shoes.Common.Req
{
    public class SearchProductReq
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public int Id { get; set; }
        public string Type { get; set; }
        public string Keyword { get; set; }
    }
}
