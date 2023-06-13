using System.Text;

namespace HW_4_Repka
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            try
            {
                Tale tale = new Tale();
                tale.TalkTale();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}