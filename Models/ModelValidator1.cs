using System.ComponentModel.DataAnnotations;

namespace MiniLibrary.Models
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ModelValidator1 : ValidationAttribute
    {
        private readonly string[] properties;

        public ModelValidator1(params string[] p)
        {
            this.properties = p;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            foreach (var pName in properties)
            {
                var pValue = validationContext.ObjectType.GetProperty(pName)?.GetValue(validationContext.ObjectInstance);

                if (pValue is string str && !string.IsNullOrEmpty(str))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("Name, Surname and Nickname cannot be empty at the same time.");
        }

    }
}
