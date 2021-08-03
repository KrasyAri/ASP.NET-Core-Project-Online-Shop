namespace ASP.NET_Core_Project_Online_Shop.Data
{
    public class DataConstants
    {
        public class Product
        {
            public const int ProductCodeMinLenght = 5;
            public const int ProductCodeMaxLenght = 7;
            public const int ProductNameMinLenght = 5;
            public const int ProductNameMaxLenght = 30;
            public const int DescriptionMinLength = 10;

            public const int DefaultNameMinLenght = 5;
            public const int DefaultNameMaxLenght = 30;

            public const int ProductMinWeight = 15;
            public const int ProductMaxWeight = 1000;
        }


        public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public class TradePartner
        {
            public const int UserIdMaxLength = 40;
            public const int TradePartnerNameMinLength = 3;
            public const int CompanyNameMinLenght = 2;
            public const int CompanyNameMaxLenght = 30;
            public const int BulstatMinLenght = 9;
            public const int BulstatMaxLenght = 15;

            public const int PhoneNumberMinLength = 6;
            public const int PhoneNumberMaxLength = 30;

        }

        public class User
        {
            public const int DefaultMaxLength = 20;
            public const int NamesMinLenght = 2;

            public const int PasswordMinLenght = 8;
            public const int PasswordMaxLenght = 100;

        }

        public class ShippingDetails
        {
            public const int CityMinLenght = 3;
            public const int CityMaxLenght = 20;

            public const int CountryMinLenght = 5;
            public const int CountryMaxLenght = 20;

            public const int AdressMinLenght = 10;

            public const int PhoneNumberMinLength = 6;
            public const int PhoneNumberMaxLength = 30;

            public const int DeliveryCompanyMin = 10;
            public const int DeliveryCompanyMax = 40;
        }

    }
}
