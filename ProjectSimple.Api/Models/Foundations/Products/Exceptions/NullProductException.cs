//=================================================
//Copyright (c) Coalition of Good-Hearted Engineers 
//Free To Use To Find Comfort and Pease
//=================================================

using Xeptions;

namespace ProjectSimple.Api.Models.Foundations.Products.Exceptions
{
    public class NullProductException:Xeption
    {
        public NullProductException() : base(message:"Product is null") { }
    }
}
