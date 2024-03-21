using Xeptions;

namespace ProjectSimple.Api.Models.Foundations.Products.Exceptions
{
    public class NullProductException:Xeption
    {
        public NullProductException()
            :base(message:"Product is null")
        { }
        
    }
}
