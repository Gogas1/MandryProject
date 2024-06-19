using Mandry.Interfaces.Helpers;

namespace Mandry.Helpers
{
    public class StringObfuscator : IStringObfuscator
    {
        public string ObfuscateEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("Email cannot be null or empty", nameof(email));
            }

            var emailParts = email.Split('@');
            if (emailParts.Length != 2)
            {
                throw new ArgumentException("Invalid email format", nameof(email));
            }

            var localPart = emailParts[0];
            var domainPart = emailParts[1];
            var domainParts = domainPart.Split('.');
            if (domainParts.Length < 2)
            {
                throw new ArgumentException("Invalid domain format", nameof(email));
            }

            var obfuscatedLocalPart = localPart.Length <= 2 ? new string('*', localPart.Length) : localPart.Substring(0, 2) + new string('*', localPart.Length - 2);
            var obfuscatedDomainPart = domainParts[0].Substring(0, 1) + new string('*', domainParts[0].Length - 1) + "." + string.Join(".", domainParts[1..]);

            return obfuscatedLocalPart + "@" + obfuscatedDomainPart;
        }

        public string ObfuscatePhone(string phone)
        {
            if (string.IsNullOrEmpty(phone))
            {
                throw new ArgumentException("Phone number cannot be null or empty", nameof(phone));
            }
            
            string cleanedPhone = string.Concat(phone.Where(char.IsDigit));

            if (cleanedPhone.Length < 4)
            {
                throw new ArgumentException("Phone number is too short to obfuscate", nameof(phone));
            }

            int visibleDigits = 2;
            string firstPart = cleanedPhone.Substring(0, visibleDigits);
            string lastPart = cleanedPhone.Substring(cleanedPhone.Length - visibleDigits, visibleDigits);
            string middlePart = new string('*', cleanedPhone.Length - (2 * visibleDigits));

            return firstPart + middlePart + lastPart;
        }
    }
}
