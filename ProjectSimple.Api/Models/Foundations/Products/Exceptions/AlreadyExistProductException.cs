// ---------------------------------------------------
// Copyright (c) Coalition of Good-hearted Engineers
// Free to use to find comfort and pease
// ---------------------------------------------------

using Xeptions;

namespace ProjectSimple.Api.Models.Foundations.Products.Exceptions
{
    public class AlreadyExistProductException: Xeption
    {
        public AlreadyExistProductException(Exception innerException)
            :base(message:"Guest already exist ",innerException)
        { }
    }
}
