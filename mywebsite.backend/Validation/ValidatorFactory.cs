using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Ninject;
using Ninject.Parameters;

namespace mywebsite.backend.Validation
{
    public class ValidatorFactory : ValidatorFactoryBase
    {
        private readonly IKernel _kernel;

        public ValidatorFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            var instance = (IValidator) _kernel.Get(validatorType, new IParameter[0]);
            return instance;
        }
    }
}
