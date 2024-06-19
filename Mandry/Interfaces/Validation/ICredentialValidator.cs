namespace Mandry.Interfaces.Validation
{
    public interface ICredentialValidator
    {
        ValidationErrors ValidatePassword(string password);
        ValidationErrors ValidatePhone(string phone);
        ValidationErrors ValidateEmail(string email);
        /// <summary>
        /// Validate for empty or null strings.
        /// </summary>
        /// <param name="value">Value to be validated</param>
        /// <param name="nameFor">Subject to be validated</param>
        /// <returns>Returns <see cref="ValidationErrors"/> with validation errors only for empty string</returns>
        ValidationErrors ValidateNotNull(string value, string subject);

        ValidationErrors ValidateBirthDate(DateTime date);
    }

    public class ValidationError
    {
        public ValidationError(string name, string validValue)
        {
            Name = name;
            ValidValue = validValue;
        }

        /// <summary>
        /// Invalid paramater descriptor
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Valid parameter value
        /// </summary>
        public string ValidValue { get; private set; }
    }

    public class ValidationErrors
    {
        public ValidationErrors(string subject, List<ValidationError> errors)
        {
            Subject = subject;
            Errors = errors;
        }

        public bool IsValid
        {
            get
            {
                return !Errors.Any();
            }
        }
        public string Subject { get; private set; }
        public List<ValidationError> Errors { get; private set; }
    }
}
