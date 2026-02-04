namespace RadiShop.Catalog.API.Endpoints.v1
{
    public static class ValidationMessages
    {
        public const string NotNullMessage = "این فیلد نباید مقدار خالی داشته باشد.";
        public const string NotEmptyMessage = "این فیلد نباید خالی باشد.";
        public const string MaximumLengthMessage = "این فیلد نباید بیش از {0} کاراکتر باشد.";
        public const string GreaterThanZeroMessage = "این مقدار باید بیشتر از 0 باشد.";
        public const string LessThanMaximumMessage = "این مقدار باید کمتر از {0} باشد.";
        public const string MinimumLengthMessage = "این فیلد باید حداقل {0} کاراکتر داشته باشد.";
        public const string DuplicateValueMessage = "این مقدار قبلاً استفاده شده است.";
    }


}
