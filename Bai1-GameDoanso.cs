using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Chào mừng bạn đến với trò chơi đoán số");
            int tk = 100; //Tiền quỹ
            Console.WriteLine($"\tTài khoản của bạn đang có {tk} $\n\tBạn sẽ được cộng/trừ 4/7/10$ khi thắng/thua theo từng level tương ứng");
            int cash;
            int vanthang = 0;
            int vanthua = 0;
            do
            {
                //1. Khởi đông:
                Console.WriteLine("Mời bạn chọn level: \n\t1. Khó: 4 lần chơi\n\t2. Trung bình: 7 lần chơi\n\t3. Dễ: 10 lần chơi");               
                string s = Console.ReadLine();
                int level = 0;
                while (!int.TryParse(s, out level))
                {
                    Console.WriteLine("Nhập lại");
                    s = Console.ReadLine();
                }
                int solanchoi;
                switch (level)
                {
                    case 1:
                        solanchoi = 4;
                        Console.WriteLine("Bạn đã chọn level Khó.\n\tMỗi lần chơi bạn sẽ được cộng/trừ 4$ khi thắng/thua");
                        cash = 4;
                        break;
                    case 2:
                        solanchoi = 7;
                        Console.WriteLine("Bạn đã chọn độ khó Trung bình.\n\tMỗi lần chơi bạn sẽ được cộng/trừ 7$ khi thắng/thua");
                        cash = 7;
                        break;
                    default:
                        solanchoi = 10;
                        Console.WriteLine("Bạn đã chọn độ khó Trung bình.\n\tMỗi lần chơi bạn sẽ được cộng/trừ 10$ khi thắng/thua ");
                        cash = 10;
                        break;
                }
                // 2. Bắt đầu:              
                Random rd = new Random();
                int maychon = rd.Next(1, 101);
                bool thang = false;
                for (int i = 0; i < solanchoi; i++)
                {
                    Console.Write($"{i + 1}. Bạn đoán số mấy [1-100]: ");
                    string x = Console.ReadLine();
                    int nguoichon = 0;
                    while (!int.TryParse(x, out nguoichon))
                    {
                        Console.WriteLine("Nhập lại: ");
                        x = Console.ReadLine();
                    }
                    if (nguoichon == maychon)
                    {
                        thang = true;
                        Console.WriteLine($"Bạn đã đoán đúng. Số máy chọn là {maychon}");
                        tk += cash;
                        vanthang++;
                        break;
                    }
                    else
                    {
                        if (nguoichon > maychon)
                        {
                            Console.WriteLine("Số bạn chọn lớn hơn số máy chọn");
                        }
                        else { Console.WriteLine("Số bạn chọn nhỏ hơn số máy chọn"); }
                    }
                }
                if (!thang)
                {
                    Console.WriteLine($"Máy nghĩ ra số {maychon}. Chúc bạn may mắn lần sau");
                    tk -= cash;
                    vanthua++;
                }
                if (tk == 0)
                {
                    Console.WriteLine("Tài khoản của bạn đã hết. Bạn không thể tiếp tục chơi");
                    break;
                }
                //3. Hỏi người chơi:
                Console.Write("\nBạn có muốn chơi lại không ? (c/k) ");
                string tl = Console.ReadLine();
                if (tl.ToLower().Equals("k"))
                {
                    Console.WriteLine("Cảm ơn, hẹn gặp lại !");
                    break ;
                }
            } while (true);
            // 4. Thống kê:
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Chúc mừng bạn đã hoàn thành trò chơi:");
            Console.WriteLine($"Số tiền còn lại trong tài khoản {tk}");
            Console.WriteLine($"Số ván thắng: {vanthang}");
            Console.WriteLine($"Số ván thua: {vanthua}");
            Console.ReadLine();



        } 
    }
}

