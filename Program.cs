
namespace FinalTestQuestion12
{
    public class Program
    {
        //A method which returns a random integer between 1 to 10000 using
        //Func. This method should return the number. Use Lamba expressions.
        public static Func<int> GetRandomNumber = () =>
        {
            Random randNumber = new Random();
            return randNumber.Next(1, 10001);
        };

        //A method which could take in a Func<int> and return a string which
        //outputs "The Generates Number is: {number"}
        public static string FormatGeneratedNumber(Func<int> randomNumberGenerator) {
            int number = randomNumberGenerator();
            return $"The Generated Number is: {number}";
        }
        public static void Main(string[] args)
        {
            Task<int> randomNumberTask = Task.Factory.StartNew(GetRandomNumber);
            randomNumberTask.ContinueWith(task =>
            {
                string result = FormatGeneratedNumber(GetRandomNumber);
                return result;
            }).ContinueWith(task =>
            {
                Console.WriteLine(task.Result);
            }).Wait();  
   
            //Console.WriteLine("Hello, World!");
        }
    }
}
