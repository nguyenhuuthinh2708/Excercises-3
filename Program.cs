using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dicegame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Khởi động:
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Chào mừng bạn đến với trò chơi Tài-Xỉu");
            int tk = 100;
            int cash = 5;
            Console.Write("\n\tBạn có hai con xúc xắc, lấy tổng của chúng.\n\tNếu lơn hơn 5 thì là \"Tài\", nhỏ hơn 5 là \"Xỉu\", Bằng 5 là trường hợp đặc biệt. ");
            int vanthang = 0;
            int vanthua = 0;
            //Bắt đầu
            do
            {
                Console.WriteLine($"\tBạn có {tk}$ trong tài khoản.\n\tSau mỗi lần đoán nếu bạn đoán đúng/sai tài/xỉu thì thắng +5$/-5$. Đoán trúng số 5 thì cộng gấp 3 (thua thì trừ 5).");
                if (tk == 0)
                {
                    Console.WriteLine("Tài khoản của bạn đã hết. Bạn không thể tiếp tục chơi");
                    break;
                }
                Random rd = new Random();
                int xucxac1 = rd.Next(1,7);
                int xucxac2 = rd.Next(1, 7);
                int tong = xucxac1 + xucxac2;
                Console.WriteLine("Mời bạn đưa ra dự đoán của mình: ");
                string s = Console.ReadLine();
                int nguoichon = 0;
                while (!int.TryParse(s,out nguoichon))
                {
                    Console.WriteLine("Nhập lại");
                    s = Console.ReadLine();
                }
                if (tong > 5)
                {
                    Console.WriteLine($"Kết quả 2 xúc xắc {tong}.\n\tTài!");
                    if (nguoichon == tong)
                    {
                        Console.WriteLine($"Chúc mừng bạn đã chiến thắng.\n\tBạn được cộng thêm {cash}$ vào tài khoản");
                        tk = tk + cash;
                        vanthang++;
                    }
                    else
                    {
                        Console.WriteLine($"Bạn đã thua. \n\tBạn bị trừ {cash}$ trong tài khoản ");
                        tk = tk - cash;
                        vanthua++;
                    }

                }
                else if (tong == 5)
                {
                    Console.WriteLine($"Kết quả 2 xúc xắc {tong}.\n\tĐặc biệt!");
                    if (nguoichon == tong)
                    {
                        Console.WriteLine($"Chúc mừng bạn đã chiến thắng.\n\tBạn được cộng thêm {3*cash}$ vào tài khoản");
                        tk = tk + 3*cash;
                        vanthang++;
                    }
                    else
                    {
                        Console.WriteLine($"Bạn đã thua. \n\tBạn bị trừ {cash}$ trong tài khoản ");
                        tk = tk - cash;
                        vanthua++;
                    }
                }
                else
                {
                    Console.WriteLine($"Kết quả 2 xúc xắc {tong}.\n\tXỉu!");
                    if (nguoichon == tong)
                    {
                        Console.WriteLine($"Chúc mừng bạn đã chiến thắng.\n\tBạn được cộng thêm {cash}$ vào tài khoản");
                        tk = tk + cash;
                        vanthang++;
                    }
                    else
                    {
                        Console.WriteLine($"Bạn đã thua. \n\tBạn bị trừ {cash}$ trong tài khoản ");
                        tk = tk - cash;
                        vanthua++;
                    }
                }
                Console.WriteLine("Bạn còn muốn chơi nữa không? <c/k>");
                string tl = Console.ReadLine();
                if (tl.ToLower().Equals("k"))
                {
                    Console.WriteLine("Tạm biệt, hẹn gặp lại");
                    break;
                }

            }
            while (true);
            //Thống kê
            Console.WriteLine(new string ('-',40));
            Console.WriteLine("Chúc mừng bạn đã hoàn thành trò chơi");
            Console.WriteLine($"Số tiền còn lại trong tài khoản: {tk}$");
            Console.WriteLine($"Số ván thắng: {vanthang}");
            Console.WriteLine($"Số ván thua:{vanthua} ");

            
        }
    }
}
