namespace RefinedWay
{
    public static class ChatBotValidator
    {
        public static Validation<string, User> IsUsingBannedWords(User user) => user.Message.Contains("bad") ? 
            Failure<string, User>.FromFailure("Using bad words", user) : Success<string, User>.FromSuccess(user);

        public static Validation<string, User> IsFromBannedIp(User user) => user.Ip.Contains("10.12.3.4") ? 
            Failure<string, User>.FromFailure("From a banned Ip", user) : Success<string, User>.FromSuccess(user);
    }
}
