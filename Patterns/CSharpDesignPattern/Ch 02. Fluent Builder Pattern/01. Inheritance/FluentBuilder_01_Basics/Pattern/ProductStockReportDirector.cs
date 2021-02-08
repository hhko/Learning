using System;
using System.Collections.Generic;
using System.Text;

namespace FluentBuilder_01_Basics.Pattern
{
    public class ProductStockReportDirector
    {
        private readonly IProductStockReportBuilder _builder;

        public ProductStockReportDirector(IProductStockReportBuilder builder)
        {
            _builder = builder;
        }

        public void BuildStockReport()
        {
            _builder
                .BuildHeader()
                .BuildBody()
                .BuildFooter();
        }
    }
}
