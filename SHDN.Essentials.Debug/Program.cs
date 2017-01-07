using System.Threading;

namespace SHDN.Essentials.Debug
{
    class Program
    {
        static void Main(string[] args)
        {
            new Thread(OnTick).Start();
        }

        private static void OnTick()
        {
            
        }
    }
}
