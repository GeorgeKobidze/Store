﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ExceptionHandler.CustomException.ProductException
{
    public class ProductNotFoundException : BaseException
    {
        public ProductNotFoundException()
        {
            Code = 2;
            UId = Guid.NewGuid();
            ErrorMessage = "Product Not Found";
        }
    }
}
