//==================================================
// Copyright (c) Coalition Of Good-Hearted Engineers
// Free To Use To Find Comfort And Peace
//==================================================

using Xeptions;

namespace ProjectSimple.Api.Models.Foundations.Products.Exceptions
{
    public class ProductValidationException:Xeption
    {
        public ProductValidationException(Xeption innerException)

        :base(message:"Product validation error occurred,fix the errors and try again",
             innerException)
        { }
            
    }
}
