using System;

namespace LegacyApp
{
    public class UserService
    {
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (IsFirstNameValid(firstName) || IsLastNameValid(lastName))
            {
                return false;
            }

            if (IsEmaliValid(email))
            {
                return false;
            } 
            
            if (IsUserOfAge(GetAge(dateOfBirth)))
            {
                return false;
            }

            var clientRepository = new ClientRepository();
            var client = clientRepository.GetById(clientId);

            var user = RegisterUser(firstName, lastName, email, dateOfBirth, client);

            if (IsVeryImportantClient(client))
            {
                SetNoCreditLimit(user);
            }
            else if (IsImportantClient(client))
            {
                using (var userCreditService = new UserCreditService())
                {
                    var creditLimit = CreateCreditLimit(userCreditService, user);
                    creditLimit = DoubleCreditLimit(creditLimit);
                    SetCreditLimit(user, creditLimit);
                }
            }
            else
            {
                user.HasCreditLimit = true;
                using (var userCreditService = new UserCreditService())
                {
                    int creditLimit = CreateCreditLimit(userCreditService, user);
                    SetCreditLimit(user, creditLimit);
                }
            }

            if (IsCreditLimitValid(user))
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }

        private static bool IsCreditLimitValid(User user)
        {
            return user.HasCreditLimit && user.CreditLimit < 500;
        }

        private static int DoubleCreditLimit(int creditLimit)
        {
            creditLimit *=2;
            return creditLimit;
        }

        private static void SetCreditLimit(User user, int creditLimit)
        {
            user.CreditLimit = creditLimit;
        }

        private static int CreateCreditLimit(UserCreditService userCreditService, User user)
        {
            int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
            return creditLimit;
        }

        private static bool IsImportantClient(Client client)
        {
            return client.Type == "ImportantClient";
        }

        private static void SetNoCreditLimit(User user)
        {
            user.HasCreditLimit = false;
        }

        private static bool IsVeryImportantClient(Client client)
        {
            return client.Type == "VeryImportantClient";
        }

        private static User RegisterUser(string firstName, string lastName, string email, DateTime dateOfBirth, Client client)
        {
            return new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };
        }

        private static bool IsUserOfAge(int age)
        {
            return age < 21;
        }

        private static bool GetAccurateAge(DateTime dateOfBirth, DateTime currentDate)
        {
            return currentDate.Month < dateOfBirth.Month || (currentDate.Month == dateOfBirth.Month && currentDate.Day < dateOfBirth.Day);
        }

        private static int GetAge(DateTime dateOfBirth)
        {
            DateTime currentDate = DateTime.Now;
            int age= currentDate.Year - dateOfBirth.Year;
            if (GetAccurateAge(dateOfBirth, currentDate)) age--;
            return age;
        }
        
        private static bool IsEmaliValid(string email)
        {
            return !email.Contains("@") && !email.Contains(".");
        }

        private static bool IsLastNameValid(string lastName)
        {
            return string.IsNullOrEmpty(lastName);
        }

        private static bool IsFirstNameValid(string firstName)
        {
            return string.IsNullOrEmpty(firstName);
        }
    }
}
