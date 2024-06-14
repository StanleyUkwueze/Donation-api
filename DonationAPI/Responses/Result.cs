namespace DonationAPI.Responses
{
    public class Result<T> where T : class
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public T? Value { get; set; }
    }
}
