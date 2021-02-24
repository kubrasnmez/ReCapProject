using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public class ValitadionTool
    {

        public static class ValidationTool
        {
            public static void Validate(IValidator validator, object entity)
            {
                var context = new ValidationContext<object>(entity); 
                var result = validator.Validate(context);
                if (!result.IsValid) //Eğer sonuç geçerli değilse 
                {
                    throw new ValidationException(result.Errors); //hata fırlat
                }
            }
        }
    }
}
