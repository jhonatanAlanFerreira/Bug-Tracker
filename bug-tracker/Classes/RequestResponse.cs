namespace bug_tracker.Classes
{
    public class RequestResponse
    {
        public string Message { get; set; }
        public bool Error { get; set; } = false;
        public object Data { get; set; }
    }
}