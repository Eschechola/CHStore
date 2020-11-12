namespace CHStore.Application.Core.Utilities
{
    public static class RegexValidators
    {
        public static string CPFRegex = @"/^\d{3}\.\d{3}\.\d{3}\-\d{2}$/";
        public static string CNPJRegex = @"/^\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}$/";
        public static string EmailRegex = @"^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
    }
}
