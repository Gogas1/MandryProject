﻿using Mandry.Interfaces.Validation;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Mandry.Validation
{
    public class CredentialValidator : ICredentialValidator
    {
        private readonly CredentialValidatorOptions _validatorOptions;

        public CredentialValidator(CredentialValidatorOptions validatorOptions)
        {
            this._validatorOptions = validatorOptions;
        }

        public ValidationErrors ValidateBirthDate(DateTime date)
        {
            List<ValidationError> errors = new List<ValidationError>();
            ValidationErrors validationErrors = new ValidationErrors("birthDate", errors);

            if (DateTime.Now - date < _validatorOptions.BirthDateMinimalAge)
            {
                errors.Add(new ValidationError("date", _validatorOptions.BirthDateMinimalAge.Days.ToString()));
            }

            return validationErrors;
        }

        public ValidationErrors ValidateEmail(string email)
        {
            //throw new NotImplementedException();
            List<ValidationError> errors = new List<ValidationError>();
            ValidationErrors validationErrors = new ValidationErrors("email", errors);

            if (string.IsNullOrEmpty(email))
            {
                errors.Add(new ValidationError("email", "not-empty"));
            }
            if (!_validatorOptions.EmailIsValidating) return validationErrors;

            if (!Regex.IsMatch(email, _validatorOptions.EmailPattern))
            {
                errors.Add(new ValidationError("email", "not-match"));
            }

            return validationErrors;
        }

        public ValidationErrors ValidateNotNull(string value, string subject)
        {
            List<ValidationError> errors = new List<ValidationError>();
            ValidationErrors validationErrors = new ValidationErrors("string", errors);

            if (string.IsNullOrEmpty(value))
            {
                errors.Add(new ValidationError(subject, "not-empty"));
            }

            return validationErrors;
        }

        public ValidationErrors ValidatePassword(string password)
        {
            List<ValidationError> errors = new List<ValidationError>();
            ValidationErrors validationErrors = new ValidationErrors("password", errors);

            if (string.IsNullOrEmpty(password))
            {
                errors.Add(new ValidationError("password", "not-empty"));
            }
            if (!_validatorOptions.PasswordIsValidating) return validationErrors;

            if (password.Length < _validatorOptions.PasswordMinLength)
            {
                errors.Add(new ValidationError("passwordMinLength", _validatorOptions.PasswordMinLength.ToString()));
            }
            if (password.Length > _validatorOptions.PasswordMaxLength)
            {
                errors.Add(new ValidationError("passwordMaxLength", _validatorOptions.PasswordMaxLength.ToString()));
            }
            if (password.Count(char.IsDigit) < _validatorOptions.PasswordMinDigits)
            {
                errors.Add(new ValidationError("passwordMinDigits", _validatorOptions.PasswordMinDigits.ToString()));
            }
            if (password.Count(char.IsLetter) < _validatorOptions.PasswordMinChars)
            {
                errors.Add(new ValidationError("passwordMinLetters", _validatorOptions.PasswordMinChars.ToString()));
            }
            if (password.Count(_validatorOptions.SpecialCharacters.Contains) < _validatorOptions.PasswordMinSpecChars)
            {
                errors.Add(new ValidationError("passwordMinSpecChars", _validatorOptions.PasswordMinSpecChars.ToString()));
                errors.Add(new ValidationError("passwordSpecCharsList", _validatorOptions.SpecialCharacters));
            }
            if (password.Count(char.IsLower) < _validatorOptions.PasswordMinLowercase)
            {
                errors.Add(new ValidationError("passwordMinLowecase", _validatorOptions.PasswordMinLowercase.ToString()));
            }
            if (password.Count(char.IsUpper) < _validatorOptions.PasswordMinUppercase)
            {
                errors.Add(new ValidationError("passwordMinUppercase", _validatorOptions.PasswordMinUppercase.ToString()));
            }

            return validationErrors;
        }

        /// Проверка на лишние символы и не пустую строку
        public ValidationErrors ValidatePhone(string phone)
        {
            List<ValidationError> errors = new List<ValidationError>();
            ValidationErrors validationErrors = new ValidationErrors("phone", errors);

            if (string.IsNullOrEmpty(phone))
            {
                errors.Add(new ValidationError("phone", "not-empty"));
            }
            if (!_validatorOptions.EmailIsValidating) return validationErrors;

            if (!Regex.IsMatch(phone, _validatorOptions.PhoneAvailableCharacters))
            {
                errors.Add(new ValidationError("phone", "not-valid"));
            }

            return validationErrors;
        }
    }

    public class CredentialValidatorOptions
    {
        #region Password settings
        public bool PasswordIsValidating { get; set; } = true;
        public int PasswordMinDigits { get; set; } = 1;
        public int PasswordMinChars { get; set; } = 1;
        public int PasswordMinSpecChars { get; set; } = 1;
        public int PasswordMinUppercase { get; set; } = 1;
        public int PasswordMinLowercase { get; set; } = 0;
        public int PasswordMinLength { get; set; } = 8;
        public int PasswordMaxLength { get; set; } = 128;
        public string SpecialCharacters { get; set; } = "!@#$%^&*()_-+={[}]|\\:;\"'<,>.?/`~";
        #endregion Password settings

        #region Phone general settings
        public bool PhoneIsValidating { get; set; } = true;
        public string PhoneAvailableCharacters { get; set; } = @"^+[\d]";

        #endregion Phone settings

        #region Email settings
        public bool EmailIsValidating { get; set; } = true;
        public string EmailPattern { get; set; } = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$";

        #endregion Email settings

        #region Birth date settings

        public TimeSpan BirthDateMinimalAge { get; set; } = TimeSpan.FromDays(365 * 18);

        #endregion Birth date settings
    }
}
