using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.CrossCuttingConcerns.Validation.FluentValidation;

namespace Core.Apects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);      //CarValidator ın instanceını oluştur.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];      //CarValidatorun Base typını bul yani AbstractValidator.Bunun generic argümanlarından ilkini bul yani Car.
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);  //Onun parametrelerini bul.Yani Addin alması gerekn parametre car.Bu parametreyle yukarıdaki parametre aynı olmalı
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity); //ValidationTool ile validate ettik.
            }
        }
    }
}
