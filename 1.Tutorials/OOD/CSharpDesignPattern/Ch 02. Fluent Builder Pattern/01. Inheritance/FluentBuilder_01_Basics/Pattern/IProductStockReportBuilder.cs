using System;
using System.Collections.Generic;
using System.Text;

namespace FluentBuilder_01_Basics.Pattern
{
    public interface IProductStockReportBuilder
    {
        IProductStockReportBuilder BuildHeader();
        IProductStockReportBuilder BuildBody();
        IProductStockReportBuilder BuildFooter();

        ProductStockReport GetReport();
    }
}
