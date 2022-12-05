namespace Views.Models
{
    public class State
    {
        public string FullName { get; init; }
        public string Code { get; init; }

        public State(string fullName, string code)
        {
            FullName = fullName;
            Code = code;
        }
    }
}
