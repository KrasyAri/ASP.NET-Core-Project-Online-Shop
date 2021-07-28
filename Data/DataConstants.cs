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
            public const int DefaultMaxLength = 20;
            public const int CompanyNameMinLenght = 2;
            public const int CompanyNameMaxLenght = 30;
            public const int BulstatMinLenght = 9;
            public const int BulstatMaxLenght = 15;
            public const int PhoneNumberMinLength = 6;
            public const int PhoneNumberMaxLength = 30;
        }

    }
}
