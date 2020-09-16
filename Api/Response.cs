namespace Api
{
    public class Res
    {
        public static Res<T> Error<T>(string message)
        {
            Res<T> response = new Res<T>
            {
                WasSuccessful = false,
                ErrorMessage = message
            };

            return response;
        }

        public static Res<T> Success<T>()
        {
            Res<T> response = new Res<T>
            {
                WasSuccessful = true,
                ErrorMessage = null
            };

            return response;
        }

        public static Res<T> Data<T>(T data)
        {
            Res<T> response = new Res<T>
            {
                WasSuccessful = true,
                ErrorMessage = null,
                Data = data
            };

            return response;
        }
    }

    public class Res<T>
    {
        public T Data { get; set; }
        public bool WasSuccessful { get; set; }
        public string ErrorMessage { get; set; }
    }
}