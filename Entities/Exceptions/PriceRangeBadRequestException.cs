

namespace Entities.Exceptions
{
    public class PriceRangeBadRequestException : BadRequestException
    {
        public PriceRangeBadRequestException() : 
            base("Max price can't be less than min price.")
        {
        }
    }
}
